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
                "dbo.DataBreachEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
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
                        LastPasswordChange = c.DateTime(nullable: false),
                        CategoryEntity_Id = c.Int(),
                        Profile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryEntities", t => t.CategoryEntity_Id)
                .ForeignKey("dbo.ProfileEntities", t => t.Profile_Id)
                .Index(t => t.CategoryEntity_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.DataBreachEntityCreditCardEntities",
                c => new
                    {
                        DataBreachEntity_Id = c.Int(nullable: false),
                        CreditCardEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataBreachEntity_Id, t.CreditCardEntity_Id })
                .ForeignKey("dbo.DataBreachEntities", t => t.DataBreachEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.CreditCardEntities", t => t.CreditCardEntity_Id, cascadeDelete: true)
                .Index(t => t.DataBreachEntity_Id)
                .Index(t => t.CreditCardEntity_Id);
            
            CreateTable(
                "dbo.PasswordEntityDataBreachEntities",
                c => new
                    {
                        PasswordEntity_Id = c.Int(nullable: false),
                        DataBreachEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PasswordEntity_Id, t.DataBreachEntity_Id })
                .ForeignKey("dbo.PasswordEntities", t => t.PasswordEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.DataBreachEntities", t => t.DataBreachEntity_Id, cascadeDelete: true)
                .Index(t => t.PasswordEntity_Id)
                .Index(t => t.DataBreachEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCardEntities", "Profile_Id", "dbo.ProfileEntities");
            DropForeignKey("dbo.DataBreachEntities", "Profile_Id", "dbo.ProfileEntities");
            DropForeignKey("dbo.PasswordEntities", "Profile_Id", "dbo.ProfileEntities");
            DropForeignKey("dbo.PasswordEntityDataBreachEntities", "DataBreachEntity_Id", "dbo.DataBreachEntities");
            DropForeignKey("dbo.PasswordEntityDataBreachEntities", "PasswordEntity_Id", "dbo.PasswordEntities");
            DropForeignKey("dbo.PasswordEntities", "CategoryEntity_Id", "dbo.CategoryEntities");
            DropForeignKey("dbo.DataBreachEntityCreditCardEntities", "CreditCardEntity_Id", "dbo.CreditCardEntities");
            DropForeignKey("dbo.DataBreachEntityCreditCardEntities", "DataBreachEntity_Id", "dbo.DataBreachEntities");
            DropForeignKey("dbo.CreditCardEntities", "CategoryEntity_Id", "dbo.CategoryEntities");
            DropForeignKey("dbo.CategoryEntities", "ProfileEntity_Id", "dbo.ProfileEntities");
            DropIndex("dbo.PasswordEntityDataBreachEntities", new[] { "DataBreachEntity_Id" });
            DropIndex("dbo.PasswordEntityDataBreachEntities", new[] { "PasswordEntity_Id" });
            DropIndex("dbo.DataBreachEntityCreditCardEntities", new[] { "CreditCardEntity_Id" });
            DropIndex("dbo.DataBreachEntityCreditCardEntities", new[] { "DataBreachEntity_Id" });
            DropIndex("dbo.PasswordEntities", new[] { "Profile_Id" });
            DropIndex("dbo.PasswordEntities", new[] { "CategoryEntity_Id" });
            DropIndex("dbo.DataBreachEntities", new[] { "Profile_Id" });
            DropIndex("dbo.CreditCardEntities", new[] { "Profile_Id" });
            DropIndex("dbo.CreditCardEntities", new[] { "CategoryEntity_Id" });
            DropIndex("dbo.CategoryEntities", new[] { "ProfileEntity_Id" });
            DropTable("dbo.PasswordEntityDataBreachEntities");
            DropTable("dbo.DataBreachEntityCreditCardEntities");
            DropTable("dbo.PasswordEntities");
            DropTable("dbo.DataBreachEntities");
            DropTable("dbo.CreditCardEntities");
            DropTable("dbo.ProfileEntities");
            DropTable("dbo.CategoryEntities");
        }
    }
}
