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
using Desafio3._1.Models;

namespace Desafio3._1.Controllers
{
    public class VideosController : ApiController
    {
        private Desafio3_1Context db = new Desafio3_1Context();

        // GET: api/Videos
        public IQueryable<Video> GetVideos()
        {
            return db.Videos;
        }

        // GET: api/Videos/5
        [ResponseType(typeof(Video))]
        public IHttpActionResult GetVideo(int id)
        {
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }

        // PUT: api/Videos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideo(int id, Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != video.Id)
            {
                return BadRequest();
            }

            db.Entry(video).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
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

        // POST: api/Videos
        [ResponseType(typeof(Video))]
        public IHttpActionResult PostVideo(Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Videos.Add(video);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = video.Id }, video);
        }

        // DELETE: api/Videos/5
        [ResponseType(typeof(Video))]
        public IHttpActionResult DeleteVideo(int id)
        {
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return NotFound();
            }

            db.Videos.Remove(video);
            db.SaveChanges();

            return Ok(video);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideoExists(int id)
        {
            return db.Videos.Count(e => e.Id == id) > 0;
        }
    }
}