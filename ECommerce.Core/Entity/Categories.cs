using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float TaxPercentage { get; set; }
    }
}
