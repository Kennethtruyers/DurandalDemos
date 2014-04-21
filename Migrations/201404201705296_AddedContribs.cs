namespace ProjectPlanner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContribs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contributors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Picture = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributors", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Contributors", new[] { "Project_Id" });
            DropTable("dbo.Contributors");
        }
    }
}
