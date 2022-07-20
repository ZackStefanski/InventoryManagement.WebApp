using ClassDemo.Models;

namespace InventoryManagement.WebApp.Models
{
    public class Quote
    {
        public Quote()
        {
            QuoteItems = new List<QuoteItem>();
            Items = new List<Item>();
        }
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public List<QuoteItem> QuoteItems { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
