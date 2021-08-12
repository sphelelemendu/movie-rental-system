namespace MovieApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Name) values ('Comedy')");
            Sql("insert into Genres (Name) values ('Rcomantic Comedy')");
            Sql("insert into Genres (Name) values ('Action')");
            Sql("insert into Genres (Name) values ('War')");
            Sql("insert into Genres (Name) values ('Drama')");

        }
        
        public override void Down()
        {
        }
    }
}
