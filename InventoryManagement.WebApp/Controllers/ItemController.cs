using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassDemo.Models;
using System.Text;
using InventoryManagement.WebApp.Models;

namespace ClassDemo.Controllers
{
    public class ItemController : Controller
    {
        private readonly Context _context;

        public List<Item> Quote { get; set; } = new List<Item>();

        public ItemController(Context context)
        {
            _context = context;
        }

        // GET: Inventory List
        public async Task<IActionResult> Index(string search)
        {
            string path = Environment.CurrentDirectory.ToString() + "/Inventory.db";

            bool fileExist = System.IO.File.Exists(path);

            if (search != null)
            {
                string searchUpper = search.ToUpper();
                if (searchUpper != "")
                {
                    return View(_context.Inventory.Where(x => x.Name.Contains(searchUpper) || searchUpper == null).ToList());
                }
            }

            if (!fileExist)
            {
                _context.Database.EnsureCreated();
            }

            if (_context.Inventory.Count() == 0)
            {
                var items = new Item[]
{
                new Item{ Name = "MICROPHONE",RetailPrice = 99.99m,Cost = 68.25m},
                new Item{ Name = "GUITAR",RetailPrice = 999.99m,Cost = 450m},
                new Item{ Name = "CABLE",RetailPrice = 18.99m,Cost = 7.89m},
                new Item{ Name = "MICROPHONE STAND",RetailPrice = 25.99m,Cost = 13.24m},
                new Item{ Name = "MICROPHONE CLIP",RetailPrice = 5.25m,Cost = 2.50m},
                new Item{ Name = "GUITAR STAND",RetailPrice = 19.99m,Cost = 10.24m},
                new Item{ Name = "GUITAR AMP",RetailPrice = 1299.99m,Cost = 650.25m}
};
                foreach (Item item in items)
                {
                    // changed from _context.Add(item);
                    _context.Inventory.Add(item);
                }
                _context.SaveChanges();
            }

            return _context.Inventory != null ?
                    View(await _context.Inventory.Where(s => s.IsDeleted == false).ToListAsync()) :
                    Problem("Entity set 'Context.Inventory'  is null.");
        }


        // GET: Deleted Items List
        public async Task<IActionResult> Deleted()
        {
            return _context.Inventory != null ?
                    View(await _context.Inventory.Where(s => s.IsDeleted == true).ToListAsync()) :
                    Problem("Entity set 'Context.Inventory'  is null.");
        }

        // GET: Item Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }

            var item = await _context.Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: CREATE ITEM View
        public IActionResult Create()
        {
            return View();
        }

        // POST: CREATE ITEM
        //Here I am checking to ensure that item.name s that have not been deleted or currently exist in the _context are not repeated. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RetailPrice,IsDeleted,CreatedDate,UpdatedDate,Cost")] Item item)
        {
            if (ModelState.IsValid)
            {
                foreach (Item x in _context.Inventory)
                {
                    if (item.Name == x.Name && x.IsDeleted == true)
                    {
                        ModelState.AddModelError("", "This item exists! Please reinstate from the Deleted list.");
                        return View(x);
                    } else if (item.Name == x.Name && x.IsDeleted == false)
                    {
                        ModelState.AddModelError("", "This item already exists.");
                        return View(x);
                    }
                }
                item.Name = item.Name.ToUpper();
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Item to Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }

            var item = await _context.Inventory.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,RetailPrice,IsDeleted,CreatedDate,UpdatedDate,Cost")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Get item to DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }

            var item = await _context.Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: DELETE ITEM
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inventory == null)
            {
                return Problem("Entity set 'Context.Inventory'  is null.");
            }
            var item = await _context.Inventory.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = !item.IsDeleted;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ITEM TO REINSTATE
        public async Task<IActionResult> Reinstate(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }

            var item = await _context.Inventory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: REINSTATE ITEM
        [HttpPost, ActionName("Reinstate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReinstateConfirmed(int id)
        {
            if (_context.Inventory == null)
            {
                return Problem("Entity set 'Context.Inventory'  is null.");
            }
            var item = await _context.Inventory.FindAsync(id);
            if (item != null)
            {
                item.IsDeleted = !item.IsDeleted;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
          return (_context.Inventory?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // EXPORT CSV FILE OF INVENTORY
        [HttpPost]
        public FileResult Export()
        {
            //Context i = new Context();
            List<object> j = (from item in _context.Inventory.Where(s => s.IsDeleted == false).ToList()
                              select new[] { item.Id.ToString(),
                                                            item.Name.ToString(),
                                                            item.RetailPrice.ToString(),
                                                            item.CreatedDate.ToString(),
                                                            item.UpdatedDate.ToString(),
                                                            item.Cost.ToString(),
                                }).ToList<object>();

            //Insert the Column Names.
            j.Insert(0, new string[6] { "ID","Item","RetailPrice","CreatedDate","UpdatedDate","Cost" });

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < j.Count; i++)
            {
                string[] item = (string[])j[i];
                for (int x = 0; x < item.Length; x++)
                {
                    //Append data with separator.
                    sb.Append(item[x] + ',');
                }

                //Append new line character.
                sb.Append("\r\n");

            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", $"Inventory.{DateTime.Now}.csv");
        }

        public void AddItemToQuoteLogic(Item x)
        {
            var item = _context.Inventory.Find(x.Id);
            x.QuoteItems.Add(new QuoteItem { QuoteId = 1, ItemId = x.Id });
            _context.SaveChanges();
        }

        // POST: REINSTATE ITEM
        [HttpPost, ActionName("AddItemToQuote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItemToQuote(int id)
        {
            if (_context.Inventory == null)
            {
                return Problem("Entity set 'Context.Inventory'  is null.");
            }
            var item = await _context.Inventory.FindAsync(id);
            if (item != null)
            {
                AddItemToQuoteLogic(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
