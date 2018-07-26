namespace VidlyUA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreData : DbMigration
    {
        public override void Up()
        {
            Sql( "SET IDENTITY_INSERT Genres ON" );
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql( "INSERT INTO Genres (Id, Name) VALUES (2, 'Comedy')" );
            Sql( "INSERT INTO Genres (Id, Name) VALUES (3, 'Family')" );
            Sql( "INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')" );
            Sql( "SET IDENTITY_INSERT Genres OFF" );
        }
        
        public override void Down()
        {
        }
    }
}
