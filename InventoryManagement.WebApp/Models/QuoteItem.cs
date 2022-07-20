using ClassDemo.Models;

namespace InventoryManagement.WebApp.Models
{
    public class QuoteItem
    {
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
