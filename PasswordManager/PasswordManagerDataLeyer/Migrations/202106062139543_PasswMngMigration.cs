namespace PasswordManagerDataLeyer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswMngMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Profile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileId)
                .Index(t => t.Profile_ProfileId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Number = c.Long(nullable: false),
                        Name = c.String(maxLength: 128),
                        Type = c.String(),
                        CCVCode = c.Short(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        Profile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.Categories", t => t.Name)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileId)
                .Index(t => t.Name)
                .Index(t => t.Profile_ProfileId);
            
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        PasswordId = c.Int(nullable: false, identity: true),
                        Pass = c.String(),
                        Site = c.String(),
                        User = c.String(),
                        Note = c.String(),
                        Strength = c.String(),
                        LastModificationDate = c.DateTime(nullable: false),
                        Category_Name = c.String(maxLength: 128),
                        Profile_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.PasswordId)
                .ForeignKey("dbo.Categories", t => t.Category_Name)
                .ForeignKey("dbo.Profiles", t => t.Profile_ProfileId)
                .Index(t => t.Category_Name)
                .Index(t => t.Profile_ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passwords", "Profile_ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Passwords", "Category_Name", "dbo.Categories");
            DropForeignKey("dbo.CreditCards", "Profile_ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.CreditCards", "Name", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Profile_ProfileId", "dbo.Profiles");
            DropIndex("dbo.Passwords", new[] { "Profile_ProfileId" });
            DropIndex("dbo.Passwords", new[] { "Category_Name" });
            DropIndex("dbo.CreditCards", new[] { "Profile_ProfileId" });
            DropIndex("dbo.CreditCards", new[] { "Name" });
            DropIndex("dbo.Categories", new[] { "Profile_ProfileId" });
            DropTable("dbo.Passwords");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Profiles");
            DropTable("dbo.Categories");
        }
    }
}
