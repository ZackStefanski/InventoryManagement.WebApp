using ClassDemo.Models;

namespace InventoryManagement.WebApp.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
