using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.Data.Entities
{
    public class ProductLocation
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Location { get; set; }

        [MaxLength(20)]
        public string LocationType { get; set; }

        public List<Stock> Items { get; set; }
    }
}
