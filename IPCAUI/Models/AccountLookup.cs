using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPCAUI.Models
{
    

    public class AccountLookup
    {
        public List<Product> Products = new List<Product>();
        public List<Category> Categories = new List<Category>();

        public void InitData()
        {
            Products.Add(new Product() { ProductName = "Sir Rodney's Scones", CategoryID = 3, UnitPrice = 10 });
            Products.Add(new Product() { ProductName = "Gustaf's Knäckebröd", CategoryID = 5, UnitPrice = 21 });
            Products.Add(new Product() { ProductName = "Tunnbröd", CategoryID = 5, UnitPrice = 9 });
            Products.Add(new Product() { ProductName = "Guaraná Fantástica", CategoryID = 1, UnitPrice = 4.5m });
            Products.Add(new Product() { ProductName = "NuNuCa Nuß-Nougat-Creme", CategoryID = 3, UnitPrice = 14 });
            Products.Add(new Product() { ProductName = "Gumbär Gummibärchen", CategoryID = 3, UnitPrice = 31.23m });
            Products.Add(new Product() { ProductName = "Rössle Sauerkraut", CategoryID = 7, UnitPrice = 45.6m });
            Products.Add(new Product() { ProductName = "Thüringer Rostbratwurst", CategoryID = 6, UnitPrice = 123.79m });
            Products.Add(new Product() { ProductName = "Nord-Ost Matjeshering", CategoryID = 8, UnitPrice = 25.89m });
            Products.Add(new Product() { ProductName = "Gorgonzola Telino", CategoryID = 4, UnitPrice = 12.5m });

            Categories.Add(new Category() { ID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" });
            Categories.Add(new Category() { ID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" });
            Categories.Add(new Category() { ID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" });
            Categories.Add(new Category() { ID = 4, CategoryName = "Dairy Products", Description = "Cheeses" });
            Categories.Add(new Category() { ID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" });
            Categories.Add(new Category() { ID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" });
            Categories.Add(new Category() { ID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" });
            Categories.Add(new Category() { ID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" });
        }
    }       

    public class Product
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }
    }

    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class SeriesLookup
    {
        public List<string> Series;

        public SeriesLookup()
        {
            Series = new List<string> { "Main"};
        }
    }

    public class GroupLookup
    {
        public List<string> Group;

        public GroupLookup()
        {
            Group = new List<string> { "Main" };
        }
    }
}
