using System.Data.Entity;

namespace ProjectFinder.Models
{
    public class ProjectPlannerContext : DbContext
    {
        public ProjectPlannerContext() : base("name=ProjectPlannerContext")
        {
        }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Contributor> Contributors { get; set; }
    }
}
