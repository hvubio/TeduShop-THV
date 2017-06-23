using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeduShop.Model.Models;

namespace TeduShop.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TeduShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeduShopDbContext context)
        {
            CreatProductCategorySample(context);
            //  This method will be called after migrating to the latest version.
//            var  manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeduShopDbContext()));
//            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TeduShopDbContext()));
//
//            var user = new ApplicationUser
//            {
//                UserName = "tedu",
//                Email =  "tedu.international@gmail.com",
//                EmailConfirmed = true,
//                Brithday = DateTime.Now,
//                FullName = "Technology Education"
//            };
//
//            manager.Create(user, "123654$");
//
//            if (!roleManager.Roles.Any())
//            {
//                roleManager.Create(new IdentityRole {Name = "Admin"});
//                roleManager.Create(new IdentityRole {Name = "User"});
//            }
//
//            var adminUser = manager.FindByEmail("tedu.international@gmail.com");
//
//            manager.AddToRoles(adminUser.Id, new string[] {"Admin", "User"});

            
            
        }

        public void CreatProductCategorySample(TeduShopDbContext context)
        {
            if (!context.ProductCategories.Any())
            {
                List<ProductCategory> listProductCategories = new List<ProductCategory>()
                {
                    new ProductCategory() {Name = "Điện Lạnh",Alias = "dien-lanh",Status = true},
                    new ProductCategory() {Name = "Viễn thông", Alias = "vien-thong",Status = true},
                    new ProductCategory() {Name = "Nhà bếp", Alias = "nha-bep",Status = true},
                    new ProductCategory() {Name = "Tin học", Alias = "tin-hoc",Status = true}
                };

                context.ProductCategories.AddRange(listProductCategories);
                context.SaveChanges();
            }
            
        }
    }
}