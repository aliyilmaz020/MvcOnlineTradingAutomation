namespace MvcOnlineTradingAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeenum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeeCity", c => c.String(maxLength: 13, unicode: false));
            AddColumn("dbo.Employees", "EmployeePhone", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmployeePhone");
            DropColumn("dbo.Employees", "EmployeeCity");
        }
    }
}
