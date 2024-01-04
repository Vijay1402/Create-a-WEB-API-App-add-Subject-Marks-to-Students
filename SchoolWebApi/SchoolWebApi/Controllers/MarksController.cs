using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SchoolWebApi.Models;

namespace SchoolWebApi.Controllers
{
    public class MarksController : ApiController
    {
        private marksEntities db = new marksEntities();

        // GET: api/Marks
        public IQueryable<Mark> GetMarks()
        {
            return db.Marks;
        }

        // GET: api/Marks/5
        [ResponseType(typeof(Mark))]
        public IHttpActionResult GetMark(int id)
        {
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return NotFound();
            }

            return Ok(mark);
        }

        // PUT: api/Marks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMark(int id, Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mark.MId)
            {
                return BadRequest();
            }

            db.Entry(mark).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkExists(id))
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

        // POST: api/Marks
        [ResponseType(typeof(Mark))]
        public IHttpActionResult PostMark(Mark mark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marks.Add(mark);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MarkExists(mark.MId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mark.MId }, mark);
        }

        // DELETE: api/Marks/5
        [ResponseType(typeof(Mark))]
        public IHttpActionResult DeleteMark(int id)
        {
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return NotFound();
            }

            db.Marks.Remove(mark);
            db.SaveChanges();

            return Ok(mark);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarkExists(int id)
        {
            return db.Marks.Count(e => e.MId == id) > 0;
        }
    }
}