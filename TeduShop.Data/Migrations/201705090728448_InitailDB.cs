using System.Data.Entity.Migrations;

namespace TeduShop.Data.Migrations
{
    public partial class InitailDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Footers",
                    c => new
                    {
                        Id = c.String(false, 50),
                        Content = c.String(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.MenuGroups",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 50)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Menus",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 50),
                        Url = c.String(false, 250),
                        DisplayOrder = c.Int(),
                        GroupId = c.Int(false),
                        Target = c.String(maxLength: 10),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuGroups", t => t.GroupId, true)
                .Index(t => t.GroupId);

            CreateTable(
                    "dbo.OrderDetails",
                    c => new
                    {
                        OrderId = c.Int(false),
                        ProductId = c.Int(false),
                        Quantity = c.Int(false)
                    })
                .PrimaryKey(t => new {t.OrderId, t.ProductId})
                .ForeignKey("dbo.Orders", t => t.ProductId, true)
                .ForeignKey("dbo.Products", t => t.OrderId, true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);

            CreateTable(
                    "dbo.Orders",
                    c => new
                    {
                        Id = c.Int(false, true),
                        CustomerName = c.String(false, 250),
                        CustomerAddress = c.String(false, 250),
                        CustomerEmail = c.String(false, 250),
                        CustomerMobile = c.String(false, 50),
                        CustomerMessage = c.String(maxLength: 250),
                        PaymentMethod = c.String(false, 250),
                        PaymentStatus = c.String(false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Products",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 256),
                        Alias = c.String(false, 256, unicode: false),
                        CategoryId = c.Int(false),
                        DisplayOrder = c.Int(false),
                        Image = c.String(false, 256),
                        MoreImages = c.String(storeType: "xml"),
                        Price = c.Decimal(precision: 18, scale: 2),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Warranty = c.Int(),
                        Description = c.String(maxLength: 256),
                        Content = c.String(),
                        HomeFlag = c.Boolean(),
                        HotFlag = c.Boolean(),
                        ViewCount = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryId, true)
                .Index(t => t.CategoryId);

            CreateTable(
                    "dbo.ProductCategories",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false),
                        Alias = c.String(false),
                        Description = c.String(),
                        ParentId = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(),
                        HomeFlag = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Pages",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 256),
                        Alias = c.String(false, 256, unicode: false),
                        Content = c.String(false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.PostCategories",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false),
                        Alias = c.String(false, 256, unicode: false),
                        Description = c.String(),
                        ParentId = c.Int(),
                        DisplayOrder = c.Int(),
                        Image = c.String(false),
                        HomeFlag = c.Boolean(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(),
                        MetaKeyword = c.String(maxLength: 256),
                        MetaDescription = c.String(maxLength: 256),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Posts",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false),
                        Alias = c.String(false, 256, unicode: false),
                        Decsription = c.String(),
                        CategoryId = c.Int(false),
                        Image = c.String(),
                        Content = c.String(),
                        HomeFlag = c.Boolean(false),
                        HotFlag = c.Boolean(false),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostCategories", t => t.CategoryId, true)
                .Index(t => t.CategoryId);

            CreateTable(
                    "dbo.PostTags",
                    c => new
                    {
                        PostId = c.Int(false),
                        TagId = c.String(false, 50, unicode: false)
                    })
                .PrimaryKey(t => new {t.PostId, t.TagId})
                .ForeignKey("dbo.Posts", t => t.PostId, true)
                .ForeignKey("dbo.Tags", t => t.TagId, true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);

            CreateTable(
                    "dbo.Tags",
                    c => new
                    {
                        Id = c.String(false, 50, unicode: false),
                        Name = c.String(false, 250),
                        Type = c.String(false, 50)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.ProductTags",
                    c => new
                    {
                        ProductId = c.Int(false),
                        TagId = c.String(false, 50, unicode: false)
                    })
                .PrimaryKey(t => new {t.ProductId, t.TagId})
                .ForeignKey("dbo.Products", t => t.ProductId, true)
                .ForeignKey("dbo.Tags", t => t.TagId, true)
                .Index(t => t.ProductId)
                .Index(t => t.TagId);

            CreateTable(
                    "dbo.Sildes",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 256),
                        Decsription = c.String(maxLength: 256),
                        Image = c.String(false, 256),
                        Url = c.String(maxLength: 265),
                        DisplayOrder = c.Int(),
                        Status = c.Int(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.SupportOnlines",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 50),
                        Department = c.String(false, 50),
                        Skype = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Yahoo = c.String(maxLength: 50),
                        Facebook = c.String(maxLength: 50),
                        Status = c.Boolean(false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.SystemConfigs",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Code = c.String(false, 50, unicode: false),
                        StringValue = c.String(maxLength: 50),
                        IntValue = c.Int()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.VisitorStatistics",
                    c => new
                    {
                        Id = c.Int(false, true),
                        VisitedDate = c.DateTime(false),
                        IpAddress = c.String(false, 50)
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PostTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.PostTags", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.PostCategories");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Orders");
            DropForeignKey("dbo.Menus", "GroupId", "dbo.MenuGroups");
            DropIndex("dbo.ProductTags", new[] {"TagId"});
            DropIndex("dbo.ProductTags", new[] {"ProductId"});
            DropIndex("dbo.PostTags", new[] {"TagId"});
            DropIndex("dbo.PostTags", new[] {"PostId"});
            DropIndex("dbo.Posts", new[] {"CategoryId"});
            DropIndex("dbo.Products", new[] {"CategoryId"});
            DropIndex("dbo.OrderDetails", new[] {"ProductId"});
            DropIndex("dbo.OrderDetails", new[] {"OrderId"});
            DropIndex("dbo.Menus", new[] {"GroupId"});
            DropTable("dbo.VisitorStatistics");
            DropTable("dbo.SystemConfigs");
            DropTable("dbo.SupportOnlines");
            DropTable("dbo.Sildes");
            DropTable("dbo.ProductTags");
            DropTable("dbo.Tags");
            DropTable("dbo.PostTags");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.Pages");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuGroups");
            DropTable("dbo.Footers");
        }
    }
}