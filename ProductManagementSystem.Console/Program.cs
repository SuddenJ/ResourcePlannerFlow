using ProductManagement.Console.Operations;
using ProductManagementSystem.Console.Operations;
using ProductManagementSystem.Data;

using var db = new ProductManagementContext();

IList<string> operations = new List<string>()
{
    "p1 Create Product",
    "p2 Read Product by Id",
    "p3 Update Product by Id",
    "p4 Delete Product by Id",
    "p5 Find Products with Name Containing",
    " ",
    "l1 Create Location",
    "l2 List Location",
    "l3 Delete Location",
        " ",
    "s1 Receipt stock",
    "s2 Remove stock",
    "s3 View stock holding"
};

foreach (string operation in operations)
{
    Console.WriteLine(operation);
}

while (true)
{
    Console.Write("What operation would you like to perform? Enter a function: ");
    string operation = (Console.ReadLine());

    if (operation == "p1")
    {
        ProductOperations.CreateProduct(db);  //these methods are in ProductOperations.cs
    }                                          //ctrl + (click on method name) to go to method
    else if (operation == "p2")
    {
        ProductOperations.ReadProduct(db);
    }
    else if (operation == "p3")
    {
        ProductOperations.UpdateProduct(db);
    }
    else if (operation == "p4")
    {
        ProductOperations.DeleteProduct(db);
    }
    else if (operation == "p5")
    {
        ProductOperations.ReadProductsWithNameContaining(db);
    }
    if (operation == "l1")
    {
        ProductLocationOperations.CreateLocation(db);
    }
    if (operation == "l2")
    {
        ProductLocationOperations.ListLocation(db);
    }
    if (operation == "l3")
    {
        ProductLocationOperations.DeleteLocation(db);
    }
    if (operation == "s1")
    {
        StockOperations.AddStock(db);
    }
    if (operation == "s2")
    {
        StockOperations.DeleteStock(db);
    }
    if (operation == "s3")
    { 
        StockOperations.ListStock(db);
    }
}