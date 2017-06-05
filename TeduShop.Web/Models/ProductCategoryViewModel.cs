using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Alias { get; set; }

        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public int? HomeFlag { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}