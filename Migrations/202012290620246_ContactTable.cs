namespace FoodWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactModels",
                c => new
                    {
                        contactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.contactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactModels");
        }
    }
}
