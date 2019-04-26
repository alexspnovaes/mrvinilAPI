namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 8000, unicode: false),
                        ClientUniqueId = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disk",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderCashBackItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ValueCachBack = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PerCachBack = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderItem_Id = c.Guid(),
                        OrderCashBack_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderItem", t => t.OrderItem_Id)
                .ForeignKey("dbo.OrderCashBack", t => t.OrderCashBack_Id)
                .Index(t => t.OrderItem_Id)
                .Index(t => t.OrderCashBack_Id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Disk_Id = c.Guid(),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disk", t => t.Disk_Id)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Disk_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.OrderCashBack",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderCashbackValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Number = c.String(maxLength: 8000, unicode: false),
                        Client_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.Client_Id)
                .Index(t => t.Client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderCashBackItem", "OrderCashBack_Id", "dbo.OrderCashBack");
            DropForeignKey("dbo.OrderCashBack", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.Order", "Client_Id", "dbo.Client");
            DropForeignKey("dbo.OrderCashBackItem", "OrderItem_Id", "dbo.OrderItem");
            DropForeignKey("dbo.OrderItem", "Disk_Id", "dbo.Disk");
            DropIndex("dbo.Order", new[] { "Client_Id" });
            DropIndex("dbo.OrderCashBack", new[] { "Order_Id" });
            DropIndex("dbo.OrderItem", new[] { "Order_Id" });
            DropIndex("dbo.OrderItem", new[] { "Disk_Id" });
            DropIndex("dbo.OrderCashBackItem", new[] { "OrderCashBack_Id" });
            DropIndex("dbo.OrderCashBackItem", new[] { "OrderItem_Id" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderCashBack");
            DropTable("dbo.OrderItem");
            DropTable("dbo.OrderCashBackItem");
            DropTable("dbo.Disk");
            DropTable("dbo.Client");
        }
    }
}
