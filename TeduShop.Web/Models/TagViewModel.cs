﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeduShop.Web.Models
{
    public class TagViewModel
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
       
        public string Type { get; set; }

        public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }

        public virtual IEnumerable<ProductTagViewModel> ProductTags { get; set; }
    }
}