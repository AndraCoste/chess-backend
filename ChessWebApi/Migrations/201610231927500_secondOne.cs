namespace ChessWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ShowInMenu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "ShowInMenu");
        }
    }
}
