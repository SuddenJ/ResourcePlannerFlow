using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Data.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public ProductLocation ProductLocation { get; set; }
        
        public int Quantity { get; set; }
    }
}

