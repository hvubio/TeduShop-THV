namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitailDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Posts", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Posts", "UpdatedBy", c => c.String());
            AddColumn("dbo.Posts", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "MetaDescription", c => c.String(maxLength: 256));
            AlterColumn("dbo.PostCategories", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostCategories", "Image", c => c.String(nullable: false));
            DropColumn("dbo.Posts", "MetaDescription");
            DropColumn("dbo.Posts", "MetaKeyword");
            DropColumn("dbo.Posts", "UpdatedBy");
            DropColumn("dbo.Posts", "UpdatedDate");
            DropColumn("dbo.Posts", "CreatedBy");
            DropColumn("dbo.Posts", "CreatedDate");
        }
    }
}
