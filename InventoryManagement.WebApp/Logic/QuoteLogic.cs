using ClassDemo.Models;

namespace InventoryManagement.WebApp.Logic
{
    public class QuoteLogic
    {
        public static Context _context = new Context();

        public List<Item> Quote;

        public Item findItemForQuote(int id)
        {

            /*
            Outputs: item
            Inputs: id
            Constraints:
            Edge Cases:
            ------------
            ++ PSEUDOCODE ++
            get item id
            find item id in _context
            retrieve item info
            */
            
            Item? quoteItem = _context.Inventory.Find(_context.Inventory, id);

            return quoteItem == null ? throw new Exception("item is null") : quoteItem;
        }
        public void addItemToQuote(Item x)
        {
            Quote.Add(x);
        }
        public void removeItemFromQuote(Item x)
        {
            Quote.Remove(x);
        }

        public string displayQuoteAsList()
        {
            if (Quote.Count == 0 || Quote.Count == null)
            {
                return "no items here!";
            } 
            return Quote.ToString();
        }
    }
}
