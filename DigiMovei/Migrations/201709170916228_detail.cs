namespace DigiMovei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class detail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Int(nullable: false));
        }
    }
}
