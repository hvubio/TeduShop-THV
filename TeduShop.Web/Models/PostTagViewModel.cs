using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class PostTagViewModel
    {
        
        public int PostId { get; set; }

       
        public string TagId { get; set; }

       
        public virtual PostViewModel Post { get; set; }

        
        public virtual TagViewModel Tag { get; set; }
    }
}