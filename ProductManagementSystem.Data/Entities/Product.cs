using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public int SKU { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal AverageCost { get; set; }

        public List<Stock> Items { get; set; }
    }
}
