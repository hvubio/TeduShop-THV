using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TeduShop.Model.Models;
using TeduShop.Web.Models;

namespace TeduShop.Web.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<OrderDetail, OrderDetailViewModel>();
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                cfg.CreateMap<ProductTag, ProductTagViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();

            });
        }
    }
}