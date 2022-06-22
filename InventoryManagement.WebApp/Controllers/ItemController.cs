using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassDemo.Models;

namespace ClassDemo.Controllers
{
    public class ItemController : Controller
    {
        private readonly Context _context;

        public ItemController(Context context)
        {
            _context = context;
        }

        // GET: Inventory List
        public async Task<IActionResult> Index()
        {
            _context.Database.EnsureCreated(); 

            return _context.Inventory != null ?
                    View(await _context.Inventory.Where(s => s.IsDeleted == false).ToListAsync()) :
                    Problem("Entity set 'Context.Inventory'  is null.");
        }

        // GET: Deleted Items List
        public async Task<IActionResult> Deleted()
        {
            _context.Database.EnsureCreated();

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

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,RetailPrice,IsDeleted,CreatedDate,UpdatedDate,Cost")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Item/Edit/5
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
                //_context.Inventory.Remove(item);
                item.IsDeleted = !item.IsDeleted;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Get item to REINSTATE
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

        // WORKING ON THIS ONE //
        // POST: Reinstate Item
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id, [Bind("Id,Name,Cost")] Item item)
        //{
        //    if (id != item.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            item.IsDeleted = true;
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ItemExists(item.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(item);
        //}

        private bool ItemExists(int id)
        {
          return (_context.Inventory?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
