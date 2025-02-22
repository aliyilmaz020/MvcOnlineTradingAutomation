namespace MvcOnlineTradingAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Sender = c.String(maxLength: 50, unicode: false),
                        Receiver = c.String(maxLength: 50, unicode: false),
                        Subject = c.String(maxLength: 50, unicode: false),
                        Content = c.String(maxLength: 50, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
