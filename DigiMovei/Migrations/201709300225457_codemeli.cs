namespace DigiMovei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class codemeli : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "NationalCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "NationalCode");
        }
    }
}
