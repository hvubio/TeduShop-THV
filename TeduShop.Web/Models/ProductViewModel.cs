﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public string Alias { get; set; }

        
        public int CategoryId { get; set; }

        public int DisplayOrder { get; set; }

        public string Image { get; set; }


        public string MoreImages { get; set; }

        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }

      
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        
        public virtual ProductCategoryViewModel ProductCategory { get; set; }

        public virtual IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }

        public virtual IEnumerable<ProductTagViewModel> ProductTags { get; set; }
    }
}