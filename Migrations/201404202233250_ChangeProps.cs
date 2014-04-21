namespace ProjectPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "TagList", c => c.String());
            DropColumn("dbo.Projects", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Projects", "TagList");
        }
    }
}
