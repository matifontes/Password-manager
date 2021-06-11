namespace PasswordManagerDataLeyer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswMngMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProfileEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProfileEntities", t => t.ProfileEntity_Id)
                .Index(t => t.ProfileEntity_Id);
            
            CreateTable(
                "dbo.ProfileEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CreditCardEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        CCVCode = c.Short(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        CategoryEntity_Id = c.Int(),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryEntities", t => t.CategoryEntity_Id)
                .ForeignKey("dbo.ProfileEntities", t => t.Profile_Id)
                .Index(t => t.CategoryEntity_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.PasswordEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Site = c.String(),
                        User = c.String(),
                        Password = c.String(),
                        Note = c.String(),
                        Strength = c.String(),
                        LastModificationDate = c.DateTime(nullable: false),
                        CategoryEntity_Id = c.Int(),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryEntities", t => t.CategoryEntity_Id)
                .ForeignKey("dbo.ProfileEntities", t => t.Profile_Id)
                .Index(t => t.CategoryEntity_Id)
                .Index(t => t.Profile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PasswordEntities", "Profile_Id", "dbo.ProfileEntities");
            DropForeignKey("dbo.PasswordEntities", "CategoryEntity_Id", "dbo.CategoryEntities");
            DropForeignKey("dbo.CreditCardEntities", "Profile_Id", "dbo.ProfileEntities");
            DropForeignKey("dbo.CreditCardEntities", "CategoryEntity_Id", "dbo.CategoryEntities");
            DropForeignKey("dbo.CategoryEntities", "ProfileEntity_Id", "dbo.ProfileEntities");
            DropIndex("dbo.PasswordEntities", new[] { "Profile_Id" });
            DropIndex("dbo.PasswordEntities", new[] { "CategoryEntity_Id" });
            DropIndex("dbo.CreditCardEntities", new[] { "Profile_Id" });
            DropIndex("dbo.CreditCardEntities", new[] { "CategoryEntity_Id" });
            DropIndex("dbo.CategoryEntities", new[] { "ProfileEntity_Id" });
            DropTable("dbo.PasswordEntities");
            DropTable("dbo.CreditCardEntities");
            DropTable("dbo.ProfileEntities");
            DropTable("dbo.CategoryEntities");
        }
    }
}
