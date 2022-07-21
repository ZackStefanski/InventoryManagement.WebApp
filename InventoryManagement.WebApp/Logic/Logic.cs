namespace InventoryManagement.WebApp.Logic
{
    public class Logic
    {
        public static Context _context = new Context();

        public void PopulateDBandData()
        {
            string path = Environment.CurrentDirectory.ToString() + "/Inventory.db";

            bool fileExist = System.IO.File.Exists(path);

            if (!fileExist)
            {
                _context.Database.EnsureCreated();
            }
        }
    }
}
