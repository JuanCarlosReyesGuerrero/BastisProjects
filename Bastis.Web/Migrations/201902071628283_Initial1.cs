namespace Bastis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "ViewMenu", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "CreateOption", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "ReadOption", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "UpdateOption", c => c.Boolean(nullable: false));
            AddColumn("dbo.Permissions", "DeleteOption", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Permissions", "DeleteOption");
            DropColumn("dbo.Permissions", "UpdateOption");
            DropColumn("dbo.Permissions", "ReadOption");
            DropColumn("dbo.Permissions", "CreateOption");
            DropColumn("dbo.Permissions", "ViewMenu");
        }
    }
}
