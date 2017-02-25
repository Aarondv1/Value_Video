namespace Value_Video.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSubscribedAddedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribed");
        }
    }
}
