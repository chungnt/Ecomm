using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm.Data.Models
{
    public class SearchModel<T>
    {
        public int Total { get; set; }
        public SearchPagingModel Paging { get; set; } = new SearchPagingModel();
        public SearchFilterModel? Filters { get; set; }
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}
