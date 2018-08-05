namespace EShop.DataAcces.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressDetails",
                c => new
                    {
                        AddressDetailID = c.Int(nullable: false, identity: true),
                        AdresDetay = c.String(),
                        CountyID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressDetailID)
                .ForeignKey("dbo.Counties", t => t.CountyID)
                .Index(t => t.CountyID);
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        CountyID = c.Int(nullable: false, identity: true),
                        CountyName = c.String(),
                        CityID = c.Int(),
                    })
                .PrimaryKey(t => t.CountyID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        Discount = c.Int(nullable: false),
                        ResimID = c.Int(),
                    })
                .PrimaryKey(t => t.BrandID)
                .ForeignKey("dbo.Resims", t => t.ResimID)
                .Index(t => t.ResimID);
            
            CreateTable(
                "dbo.Resims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ImageType = c.Int(nullable: false),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CategoryID = c.Int(),
                        BrandID = c.Int(),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        UstKategoriID = c.Int(),
                        BrandID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        UserID = c.Int(),
                        AddressDetailID = c.Int(),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.AddressDetails", t => t.AddressDetailID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.AddressDetailID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        RoleID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TeslimAlan = c.String(),
                        OrderState = c.Boolean(nullable: false),
                        AddressDetailID = c.Int(),
                        CustomerID = c.Int(),
                        CartID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.AddressDetails", t => t.AddressDetailID)
                .ForeignKey("dbo.Carts", t => t.CartID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.AddressDetailID)
                .Index(t => t.CustomerID)
                .Index(t => t.CartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CartID", "dbo.Carts");
            DropForeignKey("dbo.Orders", "AddressDetailID", "dbo.AddressDetails");
            DropForeignKey("dbo.Carts", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Customers", "AddressDetailID", "dbo.AddressDetails");
            DropForeignKey("dbo.Brands", "ResimID", "dbo.Resims");
            DropForeignKey("dbo.Resims", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.AddressDetails", "CountyID", "dbo.Counties");
            DropForeignKey("dbo.Counties", "CityID", "dbo.Cities");
            DropIndex("dbo.Orders", new[] { "CartID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "AddressDetailID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Customers", new[] { "AddressDetailID" });
            DropIndex("dbo.Customers", new[] { "UserID" });
            DropIndex("dbo.Carts", new[] { "CustomerID" });
            DropIndex("dbo.Categories", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Resims", new[] { "ProductID" });
            DropIndex("dbo.Brands", new[] { "ResimID" });
            DropIndex("dbo.Counties", new[] { "CityID" });
            DropIndex("dbo.AddressDetails", new[] { "CountyID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Resims");
            DropTable("dbo.Brands");
            DropTable("dbo.Cities");
            DropTable("dbo.Counties");
            DropTable("dbo.AddressDetails");
        }
    }
}
