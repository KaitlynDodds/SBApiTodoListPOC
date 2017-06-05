using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SBApiTodoListPOC.Models;

namespace SBApiTodoListPOC.Controllers
{
    public class ProjectTasksController : ApiController
    {
        private SBApiTodoListPOCContext db = new SBApiTodoListPOCContext();

        // GET: api/ProjectTasks
        public IQueryable<ProjectTask> GetProjectTasks()
        {
            return db.ProjectTasks;
        }

        // GET: api/ProjectTasks/5
        [ResponseType(typeof(ProjectTask))]
        public async Task<IHttpActionResult> GetProjectTask(int id)
        {
            ProjectTask projectTask = await db.ProjectTasks.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            return Ok(projectTask);
        }

        // PUT: api/ProjectTasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProjectTask(int id, ProjectTask projectTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectTask.Id)
            {
                return BadRequest();
            }

            db.Entry(projectTask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTaskExists(id))
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

        // POST: api/ProjectTasks
        [ResponseType(typeof(ProjectTask))]
        public async Task<IHttpActionResult> PostProjectTask(ProjectTask projectTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProjectTasks.Add(projectTask);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = projectTask.Id }, projectTask);
        }

        // DELETE: api/ProjectTasks/5
        [ResponseType(typeof(ProjectTask))]
        public async Task<IHttpActionResult> DeleteProjectTask(int id)
        {
            ProjectTask projectTask = await db.ProjectTasks.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }

            db.ProjectTasks.Remove(projectTask);
            await db.SaveChangesAsync();

            return Ok(projectTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectTaskExists(int id)
        {
            return db.ProjectTasks.Count(e => e.Id == id) > 0;
        }
    }
}