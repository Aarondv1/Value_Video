namespace Value_Video.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableBirthdateAddedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
