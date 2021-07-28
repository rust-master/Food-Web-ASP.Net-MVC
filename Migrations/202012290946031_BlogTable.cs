namespace FoodWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogModels",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        BlogTitle = c.String(nullable: false),
                        BlogDate = c.DateTime(nullable: false),
                        BlogAutherName = c.String(nullable: false),
                        BlogDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogModels");
        }
    }
}
