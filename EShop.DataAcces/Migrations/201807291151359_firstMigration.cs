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
                        ID = c.Int(nullable: false, identity: true),
                        AdresDetay = c.String(),
                        County_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Counties", t => t.County_ID)
                .Index(t => t.County_ID);
            
            CreateTable(
                "dbo.Counties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CountyName = c.String(),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .Index(t => t.City_ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        Discount = c.Int(nullable: false),
                        Image_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resims", t => t.Image_ID)
                .Index(t => t.Image_ID);
            
            CreateTable(
                "dbo.Resims",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ImageType = c.Int(nullable: false),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Brand_ID = c.Int(),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Brands", t => t.Brand_ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Brand_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                        UstKategoriID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        CreatedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        AddressDetail_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AddressDetails", t => t.AddressDetail_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.AddressDetail_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TeslimAlan = c.String(),
                        OrderState = c.Boolean(nullable: false),
                        AddressDetail_ID = c.Int(),
                        Cart_CartID = c.Int(),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AddressDetails", t => t.AddressDetail_ID)
                .ForeignKey("dbo.Carts", t => t.Cart_CartID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.AddressDetail_ID)
                .Index(t => t.Cart_CartID)
                .Index(t => t.Customer_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Cart_CartID", "dbo.Carts");
            DropForeignKey("dbo.Orders", "AddressDetail_ID", "dbo.AddressDetails");
            DropForeignKey("dbo.Carts", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_ID", "dbo.Roles");
            DropForeignKey("dbo.Customers", "AddressDetail_ID", "dbo.AddressDetails");
            DropForeignKey("dbo.Brands", "Image_ID", "dbo.Resims");
            DropForeignKey("dbo.Resims", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Products", "Brand_ID", "dbo.Brands");
            DropForeignKey("dbo.AddressDetails", "County_ID", "dbo.Counties");
            DropForeignKey("dbo.Counties", "City_ID", "dbo.Cities");
            DropIndex("dbo.Orders", new[] { "Customer_ID" });
            DropIndex("dbo.Orders", new[] { "Cart_CartID" });
            DropIndex("dbo.Orders", new[] { "AddressDetail_ID" });
            DropIndex("dbo.Users", new[] { "Role_ID" });
            DropIndex("dbo.Customers", new[] { "User_ID" });
            DropIndex("dbo.Customers", new[] { "AddressDetail_ID" });
            DropIndex("dbo.Carts", new[] { "Customer_ID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropIndex("dbo.Products", new[] { "Brand_ID" });
            DropIndex("dbo.Resims", new[] { "Product_ID" });
            DropIndex("dbo.Brands", new[] { "Image_ID" });
            DropIndex("dbo.Counties", new[] { "City_ID" });
            DropIndex("dbo.AddressDetails", new[] { "County_ID" });
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
