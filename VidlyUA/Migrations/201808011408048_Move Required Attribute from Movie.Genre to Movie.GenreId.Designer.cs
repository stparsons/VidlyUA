// <auto-generated />
namespace VidlyUA.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class MoveRequiredAttributefromMovieGenretoMovieGenreId : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(MoveRequiredAttributefromMovieGenretoMovieGenreId));
        
        string IMigrationMetadata.Id
        {
            get { return "201808011408048_Move Required Attribute from Movie.Genre to Movie.GenreId"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
