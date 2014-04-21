using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectFinder.Models;
using RefactorThis.GraphDiff;

namespace ProjectFinder.Api
{
    public class ProjectsController : ApiController
    {
        private ProjectPlannerContext db = new ProjectPlannerContext();

        public IQueryable<Project> GetProjects()
        {
	        return db.Projects;
        }

        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> GetProject(int id)
        {
            Project project = await db.Projects.Include("Contributors").SingleOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

	        project.Contributors.ForEach(c => db.Contributors.Attach(c));

	        db.UpdateGraph(project, map => map.AssociatedCollection(p => p.Contributors));

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> DeleteProject(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            await db.SaveChangesAsync();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.Id == id) > 0;
        }
    }
}