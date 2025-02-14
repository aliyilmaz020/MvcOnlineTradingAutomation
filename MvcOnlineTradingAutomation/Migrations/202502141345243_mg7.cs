namespace MvcOnlineTradingAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Status");
        }
    }
}
