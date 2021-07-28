namespace FoodWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUSerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignupLogins",
                c => new
                    {
                        userid = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.userid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SignupLogins");
        }
    }
}
