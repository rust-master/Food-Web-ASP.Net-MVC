namespace FoodWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceOrderMg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateInvoice = c.DateTime(),
                        Total_Bill = c.Single(nullable: false),
                        FKUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SignupLogins", t => t.FKUserID)
                .Index(t => t.FKUserID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        Unit_Price = c.Int(nullable: false),
                        Order_Bill = c.Single(nullable: false),
                        Order_Date = c.DateTime(),
                        FkProdId = c.Int(),
                        FkInvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceModels", t => t.FkInvoiceID)
                .ForeignKey("dbo.Products", t => t.FkProdId)
                .Index(t => t.FkProdId)
                .Index(t => t.FkInvoiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "FkProdId", "dbo.Products");
            DropForeignKey("dbo.Orders", "FkInvoiceID", "dbo.InvoiceModels");
            DropForeignKey("dbo.InvoiceModels", "FKUserID", "dbo.SignupLogins");
            DropIndex("dbo.Orders", new[] { "FkInvoiceID" });
            DropIndex("dbo.Orders", new[] { "FkProdId" });
            DropIndex("dbo.InvoiceModels", new[] { "FKUserID" });
            DropTable("dbo.Orders");
            DropTable("dbo.InvoiceModels");
        }
    }
}
