namespace DigiMovei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categoryproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            AddColumn("dbo.Movies", "Category_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Category_Id");
            AddForeignKey("dbo.Movies", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            DropIndex("dbo.Movies", new[] { "Category_Id" });
            DropColumn("dbo.Movies", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
