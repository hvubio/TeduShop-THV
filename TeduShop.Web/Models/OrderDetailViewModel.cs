using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }

        
        public int ProductId { get; set; }

        
        public int Quantity { get; set; }

        
        public virtual ProductViewModel Product { get; set; }

       
        public virtual OrderViewModel Order { get; set; }
    }
}