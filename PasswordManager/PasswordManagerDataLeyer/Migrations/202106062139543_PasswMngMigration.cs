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
                    })
                .PrimaryKey(t => t.Name);
            
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
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.Categories", t => t.Name)
                .Index(t => t.Name);
            
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
                    })
                .PrimaryKey(t => t.PasswordId)
                .ForeignKey("dbo.Categories", t => t.Category_Name)
                .Index(t => t.Category_Name);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passwords", "Category_Name", "dbo.Categories");
            DropForeignKey("dbo.CreditCards", "Name", "dbo.Categories");
            DropIndex("dbo.Passwords", new[] { "Category_Name" });
            DropIndex("dbo.CreditCards", new[] { "Name" });
            DropTable("dbo.Profiles");
            DropTable("dbo.Passwords");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Categories");
        }
    }
}
