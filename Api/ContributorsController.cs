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
    public class ContributorsController : ApiController
    {
        private ProjectPlannerContext db = new ProjectPlannerContext();

        // GET: api/Contributors
        public IQueryable<Contributor> GetContributors()
        {
            return db.Contributors;
        }

        // GET: api/Contributors/5
        [ResponseType(typeof(Contributor))]
        public async Task<IHttpActionResult> GetContributor(int id)
        {
            Contributor contributor = await db.Contributors.FindAsync(id);
            if (contributor == null)
            {
                return NotFound();
            }

            return Ok(contributor);
        }

        // PUT: api/Contributors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContributor(int id, Contributor contributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contributor.Id)
            {
                return BadRequest();
            }

			contributor.Projects.ForEach(p => db.Projects.Attach(p));

	        db.UpdateGraph(contributor, map => map.AssociatedCollection(c => c.Projects));
			
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributorExists(id))
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

        // POST: api/Contributors
        [ResponseType(typeof(Contributor))]
        public async Task<IHttpActionResult> PostContributor(Contributor contributor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contributors.Add(contributor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contributor.Id }, contributor);
        }

        // DELETE: api/Contributors/5
        [ResponseType(typeof(Contributor))]
        public async Task<IHttpActionResult> DeleteContributor(int id)
        {
            Contributor contributor = await db.Contributors.FindAsync(id);
            if (contributor == null)
            {
                return NotFound();
            }

            db.Contributors.Remove(contributor);
            await db.SaveChangesAsync();

            return Ok(contributor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContributorExists(int id)
        {
            return db.Contributors.Count(e => e.Id == id) > 0;
        }
    }
}