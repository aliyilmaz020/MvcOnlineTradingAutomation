namespace MvcOnlineTradingAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateToDatetime_Message : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Date", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
