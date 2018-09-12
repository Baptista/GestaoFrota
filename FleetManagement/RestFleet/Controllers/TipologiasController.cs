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
using RestFleet.Models;

namespace RestFleet.Controllers
{
    public class TipologiasController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Tipologias
        public IQueryable<Tipologia> GetTipologias()
        {
            return db.Tipologias;
        }

        // GET: api/Tipologias/5
        [ResponseType(typeof(Tipologia))]
        public IHttpActionResult GetTipologia(int id)
        {
            Tipologia tipologia = db.Tipologias.Find(id);
            if (tipologia == null)
            {
                return NotFound();
            }

            return Ok(tipologia);
        }

        // PUT: api/Tipologias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipologia(int id, Tipologia tipologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipologia.IdTipologia)
            {
                return BadRequest();
            }

            db.Entry(tipologia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipologiaExists(id))
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

        // POST: api/Tipologias
        [ResponseType(typeof(Tipologia))]
        public IHttpActionResult PostTipologia(Tipologia tipologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipologias.Add(tipologia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipologia.IdTipologia }, tipologia);
        }

        // DELETE: api/Tipologias/5
        [ResponseType(typeof(Tipologia))]
        public IHttpActionResult DeleteTipologia(int id)
        {
            Tipologia tipologia = db.Tipologias.Find(id);
            if (tipologia == null)
            {
                return NotFound();
            }

            db.Tipologias.Remove(tipologia);
            db.SaveChanges();

            return Ok(tipologia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipologiaExists(int id)
        {
            return db.Tipologias.Count(e => e.IdTipologia == id) > 0;
        }
    }
}