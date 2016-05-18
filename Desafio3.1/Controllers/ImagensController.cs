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
    public class ImagensController : ApiController
    {
        private Desafio3_1Context db = new Desafio3_1Context();

        // GET: api/Imagens
        public IQueryable<Imagen> GetImagens()
        {
            return db.Imagens;
        }

        // GET: api/Imagens/5
        [ResponseType(typeof(Imagen))]
        public IHttpActionResult GetImagen(int id)
        {
            Imagen imagen = db.Imagens.Find(id);
            if (imagen == null)
            {
                return NotFound();
            }

            return Ok(imagen);
        }

        // PUT: api/Imagens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImagen(int id, Imagen imagen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imagen.Id)
            {
                return BadRequest();
            }

            db.Entry(imagen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenExists(id))
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

        // POST: api/Imagens
        [ResponseType(typeof(Imagen))]
        public IHttpActionResult PostImagen(Imagen imagen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Imagens.Add(imagen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imagen.Id }, imagen);
        }

        // DELETE: api/Imagens/5
        [ResponseType(typeof(Imagen))]
        public IHttpActionResult DeleteImagen(int id)
        {
            Imagen imagen = db.Imagens.Find(id);
            if (imagen == null)
            {
                return NotFound();
            }

            db.Imagens.Remove(imagen);
            db.SaveChanges();

            return Ok(imagen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImagenExists(int id)
        {
            return db.Imagens.Count(e => e.Id == id) > 0;
        }
    }
}