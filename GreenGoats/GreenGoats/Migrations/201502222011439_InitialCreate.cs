namespace GreenGoats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        Title = c.String(),
                        Year = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Author", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerFirst = c.String(nullable: false, maxLength: 50),
                        CustomerLast = c.String(nullable: false, maxLength: 50),
                        CustomerAddress = c.String(),
                        CustomerEmail = c.String(),
                        Lot_LotID = c.Int(),
                        Goat_GoatID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Lot", t => t.Lot_LotID)
                .ForeignKey("dbo.Goat", t => t.Goat_GoatID)
                .Index(t => t.Lot_LotID)
                .Index(t => t.Goat_GoatID);
            
            CreateTable(
                "dbo.Goat",
                c => new
                    {
                        GoatID = c.Int(nullable: false, identity: true),
                        GoatName = c.String(),
                        GoatColor = c.String(),
                        GoatType = c.String(),
                        GoatGender = c.String(),
                        Lot_LotID = c.Int(),
                    })
                .PrimaryKey(t => t.GoatID)
                .ForeignKey("dbo.Lot", t => t.Lot_LotID)
                .Index(t => t.Lot_LotID);
            
            CreateTable(
                "dbo.Lot",
                c => new
                    {
                        LotID = c.Int(nullable: false, identity: true),
                        GoatID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        GoatName = c.String(nullable: false, maxLength: 50),
                        CustomerFirst = c.String(nullable: false, maxLength: 50),
                        CustomerLast = c.String(nullable: false, maxLength: 50),
                        LotAddress = c.String(nullable: false, maxLength: 50),
                        LotDescription = c.String(),
                    })
                .PrimaryKey(t => t.LotID);
            
            CreateTable(
                "dbo.Pasture",
                c => new
                    {
                        PastureID = c.Int(nullable: false, identity: true),
                        GoatID = c.Int(nullable: false),
                        Field = c.String(),
                    })
                .PrimaryKey(t => t.PastureID)
                .ForeignKey("dbo.Goat", t => t.GoatID, cascadeDelete: true)
                .Index(t => t.GoatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "Goat_GoatID", "dbo.Goat");
            DropForeignKey("dbo.Pasture", "GoatID", "dbo.Goat");
            DropForeignKey("dbo.Goat", "Lot_LotID", "dbo.Lot");
            DropForeignKey("dbo.Customer", "Lot_LotID", "dbo.Lot");
            DropForeignKey("dbo.Book", "AuthorID", "dbo.Author");
            DropIndex("dbo.Pasture", new[] { "GoatID" });
            DropIndex("dbo.Goat", new[] { "Lot_LotID" });
            DropIndex("dbo.Customer", new[] { "Goat_GoatID" });
            DropIndex("dbo.Customer", new[] { "Lot_LotID" });
            DropIndex("dbo.Book", new[] { "AuthorID" });
            DropTable("dbo.Pasture");
            DropTable("dbo.Lot");
            DropTable("dbo.Goat");
            DropTable("dbo.Customer");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
