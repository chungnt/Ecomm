using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Data.Models
{
    public class ProductSearchFilterModel : SearchFilterModel
    {
        public string? Sku { get; set; }
        public string? Name { get; set; }
    }
}
