using System.Collections.Generic;
using System.Linq;

namespace TeduShop.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { set; get; }

        public int Count => Items != null ? Items.Count() : 0;

        public int TotalPage { set; get; }

        public int TotalCount { get; set; }

        public IEnumerable<T> Items { set; get; }
    }
}