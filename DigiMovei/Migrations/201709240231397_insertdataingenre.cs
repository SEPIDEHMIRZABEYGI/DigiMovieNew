namespace DigiMovei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertdataingenre : DbMigration
    {
        public override void Up()
        {

            Sql("insert into [Genres]([ID],[Name]) Values(1,N'????')");
            Sql("insert into [Genres]([ID],[Name]) Values(2,N'??????')");
            Sql("insert into [Genres]([ID],[Name]) Values(3,N'???????')");
            Sql("insert into [Genres]([ID],[Name]) Values(4,N'????')");
            Sql("insert into [Genres]([ID],[Name]) Values(5,N'???????')");
        }
        
        public override void Down()
        {
        }
    }
}
