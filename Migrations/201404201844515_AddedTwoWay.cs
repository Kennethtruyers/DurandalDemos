namespace ProjectPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTwoWay : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributors", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Contributors", new[] { "Project_Id" });
            CreateTable(
                "dbo.ProjectContributors",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        Contributor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.Contributor_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contributors", t => t.Contributor_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.Contributor_Id);
            
            DropColumn("dbo.Contributors", "Project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contributors", "Project_Id", c => c.Int());
            DropForeignKey("dbo.ProjectContributors", "Contributor_Id", "dbo.Contributors");
            DropForeignKey("dbo.ProjectContributors", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectContributors", new[] { "Contributor_Id" });
            DropIndex("dbo.ProjectContributors", new[] { "Project_Id" });
            DropTable("dbo.ProjectContributors");
            CreateIndex("dbo.Contributors", "Project_Id");
            AddForeignKey("dbo.Contributors", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
