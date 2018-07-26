namespace VidlyUA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerBirthDateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDateTime");
        }
    }
}
