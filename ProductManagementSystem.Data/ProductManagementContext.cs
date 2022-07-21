using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Data;

public class ProductManagementContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductLocation> ProductLocation { get; set; }
    public DbSet<Stock> Stock { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source=localhost;Initial Catalog=ProductManagementSystem;Integrated Security=SSPI;");

        


}   


