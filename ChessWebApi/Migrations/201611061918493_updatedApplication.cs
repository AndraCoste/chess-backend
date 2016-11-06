namespace ChessWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "BirthDate", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Applications", "University", c => c.String(unicode: false));
            AddColumn("dbo.Applications", "Legitimated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applications", "Legitimated");
            DropColumn("dbo.Applications", "University");
            DropColumn("dbo.Applications", "BirthDate");
        }
    }
}
