namespace InventoryManagement.WebApp.Models
{
    public class Employee
    {
        public Employee()
        {
            Quotes = new List<Quote>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set;}

    }
}
