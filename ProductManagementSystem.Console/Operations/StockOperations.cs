using ProductManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementSystem.Console.Operations
{
    public class StockOperations
    {
        private static void WriteStockList(Stock item)  
        {
            System.Console.WriteLine($"Location: {item.ProductLocation.Location}");
            System.Console.WriteLine($"Product Name: {item.Product.Name}");
            System.Console.WriteLine($"Product SKU: {item.Product.SKU}");
            System.Console.WriteLine($"Product Quantity: {item.Quantity}");
            System.Console.WriteLine($"Average cost: {item.Product.AverageCost}");
        }


        public static void AddStock(ProductManagementContext db)
        {
            System.Console.WriteLine("Receipt Product");

            System.Console.Write("What Product ID would you like to receipt: ");
            int idProduct = int.Parse(System.Console.ReadLine());

            Product? product = db.Product.FirstOrDefault(x => x.Id == idProduct);  //This is a LINQ expression 'FirstOrDefault' it finds the first instance of product id that matches or returns null.

            if (product == null)
            {
                System.Console.WriteLine($"Product with Id {idProduct} not found!");
            }
            else
            {
                // Tested and working up until this point where a new instance of product must be added
                System.Console.WriteLine($"Product Name: {product.Name}");
            }

            System.Console.WriteLine("Into which location");
            int idLocation = int.Parse(System.Console.ReadLine());

            ProductLocation? location = db.ProductLocation.FirstOrDefault(x => x.Id == idLocation);
            if (location == null)
            {
                System.Console.WriteLine($"Location with Id {idLocation} not found!");
            }
            else
            {
                // Tested and working up until this point where a new instance of product must be added
                
                System.Console.WriteLine($"Location name Name: {location.Location}");
            }

            // Create a quntity to receipt
            int quantityReceipt;
            do
            {
                System.Console.Write("Quantity received: ");
                quantityReceipt = int.Parse(System.Console.ReadLine());
                if (quantityReceipt <= 0) System.Console.WriteLine("Value must be greater than 0.");
            }
            while (quantityReceipt <= 0);

            // check if average cost needs updating
            decimal stockPrice = db.Stock.Include(x => x.Product).FirstOrDefault(x => x.Id == idLocation).Product.AverageCost;
            System.Console.WriteLine($"Average cost: {stockPrice} does the average cost need updating?");

            string upDatePrice;
            do
            {
                System.Console.Write("does the average cost need updating, answer   y = yes   or   n = no  ");
                upDatePrice = (System.Console.ReadLine());
            }
            while (upDatePrice != "y" && upDatePrice != "n");

            if (upDatePrice == "y")
            {
                System.Console.Write("Enter new price in decimal format: ");
                decimal newPrice = decimal.Parse(System.Console.ReadLine());
                db.Stock.Include(x => x.Product).FirstOrDefault(x => x.Id == idLocation).Product.AverageCost = newPrice;
            }

            // This part should be to make a new instance of Stock
            if (location != null && product != null)
            {
                Stock newStock = new Stock()
                {
                    Product = product,
                    ProductLocation = location,
                    Quantity = quantityReceipt


                };
                db.Add(newStock);  //add row to "stock" to DB
                db.SaveChanges();   //saves changes to DB

            }

        }

        public static void ListStock(ProductManagementContext db)
        {
            foreach (Stock i in db.Stock.Include(x => x.Product).Include(x => x.ProductLocation))
            {
                WriteStockList(i);
            }

        }

        public static void DeleteStock(ProductManagementContext db)
        {
            System.Console.WriteLine("Remove Stock");

            System.Console.Write("What is the stock Id you would like to delete: ");
            int stockid = int.Parse(System.Console.ReadLine());

            Stock? stock = db.Stock.FirstOrDefault(x => x.Id == stockid);

            if (stock == null)
            {
                System.Console.WriteLine($"Product with Id {stockid} not found!");
            }
            else
            {
                System.Console.WriteLine("You are deleting the following product:");
                WriteStockList(stock);

                db.Remove(stock);
                db.SaveChanges();
            }
        }


    }

}
