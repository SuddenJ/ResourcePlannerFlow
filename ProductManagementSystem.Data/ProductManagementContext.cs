using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Data;

public class ProductManagementContext : DbContext
{
    // Update when on computer with SQL not installed
    private bool _sqlNotAvailable = true;

    public DbSet<Product> Product { get; set; }
    public DbSet<ProductLocation> ProductLocation { get; set; }
    public DbSet<Stock> Stock { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (_sqlNotAvailable)
        {
            options.UseInMemoryDatabase("ProductManagementSystem");
        } 
        else
        {
            options.UseSqlServer("Data Source=localhost;Initial Catalog=ProductManagementSystem;Integrated Security=SSPI;");
        }
    }

        


}   


