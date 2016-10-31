namespace ChessWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phoneToApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "Phone", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "Phone");
        }
    }
}
