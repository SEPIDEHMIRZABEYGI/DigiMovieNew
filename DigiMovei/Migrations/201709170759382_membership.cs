namespace DigiMovei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membership : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSubscribedToNewsLetter = c.Int(nullable: false),
                        MembershipTypeID = c.Byte(nullable: false),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeID, cascadeDelete: true)
                .Index(t => t.MembershipTypeID);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(),
                        DurationInMonth = c.Byte(nullable: false),
                        SignupFee = c.Short(nullable: false),
                        DiscountRent = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeID", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeID" });
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
