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
                        Name = c.String(nullable: false, maxLength: 128),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.ProfileEntities", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
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
                        Number = c.Long(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        CCVCode = c.Short(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.ProfileEntities", t => t.Profile_Id)
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
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProfileEntities", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PasswordEntities", "Profile_Id", "dbo.ProfileEntities");
            DropForeignKey("dbo.CreditCardEntities", "Profile_Id", "dbo.ProfileEntities");
            DropForeignKey("dbo.CategoryEntities", "Profile_Id", "dbo.ProfileEntities");
            DropIndex("dbo.PasswordEntities", new[] { "Profile_Id" });
            DropIndex("dbo.CreditCardEntities", new[] { "Profile_Id" });
            DropIndex("dbo.CategoryEntities", new[] { "Profile_Id" });
            DropTable("dbo.PasswordEntities");
            DropTable("dbo.CreditCardEntities");
            DropTable("dbo.ProfileEntities");
            DropTable("dbo.CategoryEntities");
        }
    }
}
