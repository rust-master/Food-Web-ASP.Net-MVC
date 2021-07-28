namespace FoodWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        adminid = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.adminid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminLogins");
        }
    }
}
