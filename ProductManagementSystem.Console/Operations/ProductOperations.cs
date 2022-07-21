using ProductManagementSystem.Data;
using ProductManagementSystem.Data.Entities;

namespace ProductManagement.Console.Operations;

public class ProductOperations
{
    public static void CreateProduct(ProductManagementContext db)
    {
        System.Console.WriteLine("Creating Product");
        var productData = GetProductData();  //this links to the GetProductData method below

        Product myProduct = new Product()  //creates a new intance of Product
        {
            Name = productData.name,
            SKU = productData.sku,
            Description = productData.desc,
            AverageCost = productData.price
        };

        db.Add(myProduct);  //add row to "product" to DB
        db.SaveChanges();   //saves changes to DB
    }

    public static void ReadProduct(ProductManagementContext db)  // This is a method to read products
    {                                                            // Prompts the user for Id   
        System.Console.WriteLine("Reading Product");

        System.Console.Write("What is the product Id you would like to read: ");
        int id = int.Parse(System.Console.ReadLine());

        Product? product = db.Product.FirstOrDefault(x => x.Id == id);  //This is a LINQ expression 'FirstOrDefault' it finds the first instance of product id that matches or returns null.

        if (product == null)
        {
            System.Console.WriteLine($"Product with Id {id} not found!");
        }
        else
        {
            WriteProduct(product);
        }
    }

    private static void WriteProduct(Product product)  //this is the product details
    {
        System.Console.WriteLine($"Product Name: {product.Name}");
        System.Console.WriteLine($"Product SKU: {product.SKU}");
        System.Console.WriteLine($"Product Description: {product.Description}");
        System.Console.WriteLine($"Product Price: ${product.AverageCost}");
    }

    private static (string name, int sku, string desc, decimal price) GetProductData()  // this Method helps update or create products 
    {
        System.Console.Write("Enter a Product Name: ");
        string name = System.Console.ReadLine();

        System.Console.Write("Enter a Product SKU: ");
        string sku = System.Console.ReadLine();
        int skuN = sku == "" ? -1 : int.Parse(sku);

        System.Console.Write("Enter a Product Description: ");
        string description = System.Console.ReadLine();

        System.Console.WriteLine("Enter a Product Price: ");
        string price = System.Console.ReadLine();
        decimal priceNumber = price == "" ? -1 : decimal.Parse(price);

        return (name, skuN, description, priceNumber);
    }

    public static void UpdateProduct(ProductManagementContext db)
    {
        System.Console.WriteLine("Updating Product");

        System.Console.Write("What is the product Id you would like to update: ");
        int id = int.Parse(System.Console.ReadLine());  

        Product? product = db.Product.FirstOrDefault(x => x.Id == id);  //Get product by ID similar to others below

        if (product == null)
        {
            System.Console.WriteLine($"Product with Id {id} not found!");
        }
        else
        {
            System.Console.WriteLine("You are updating the following product:");
            WriteProduct(product);

            System.Console.WriteLine("Enter nothing if you do not wish to update a field...");
            var productData = GetProductData();

            product.Name = productData.name == "" ? product.Name : productData.name;    // This is the part where "-1" tells us there was "" input
            product.SKU = productData.sku == -1 ? product.SKU : productData.sku;
            product.Description = productData.desc == "" ? product.Description : productData.desc;
            product.AverageCost = productData.price == -1 ? product.AverageCost : productData.price;

            db.SaveChanges();  //save changes
        }
    }

    public static void DeleteProduct(ProductManagementContext db)
    {
        System.Console.WriteLine("Deleting Product");

        System.Console.Write("What is the product Id you would like to delete: ");
        int id = int.Parse(System.Console.ReadLine());

        Product? product = db.Product.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            System.Console.WriteLine($"Product with Id {id} not found!");
        }
        else
        {
            System.Console.WriteLine("You are deleting the following product:");
            WriteProduct(product);

            db.Remove(product);
            db.SaveChanges();
        }
    }

    public static void ReadProductsWithNameContaining(ProductManagementContext db)
    {
        System.Console.WriteLine("Reading Product with Name Containing");

        System.Console.Write("What would you like the product name to contain: ");
        string partName = System.Console.ReadLine();

        IList<Product> products = db.Product.Where(x => x.Name.Contains(partName)).ToList();  //Reads data and uses the 'Where' to find any instance of the name sting containing the input

        System.Console.Write($"Found {products.Count} products");
        foreach (Product product in products)
        {
            WriteProduct(product);
        }
    }
}