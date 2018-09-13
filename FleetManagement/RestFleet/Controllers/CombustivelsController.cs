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
    public class CombustivelsController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Combustivels
        public IQueryable<Combustivel> GetCombustivels()
        {
            return db.Combustivels;
        }

        // GET: api/Combustivels/5
        [ResponseType(typeof(Combustivel))]
        public IHttpActionResult GetCombustivel(int id)
        {
            Combustivel combustivel = db.Combustivels.Find(id);
            if (combustivel == null)
            {
                return NotFound();
            }

            return Ok(combustivel);
        }

        // PUT: api/Combustivels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCombustivel(int id, Combustivel combustivel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != combustivel.IdCombustivel)
            {
                return BadRequest();
            }

            db.Entry(combustivel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CombustivelExists(id))
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

        // POST: api/Combustivels
        [ResponseType(typeof(Combustivel))]
        public IHttpActionResult PostCombustivel(Combustivel combustivel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Combustivels.Add(combustivel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = combustivel.IdCombustivel }, combustivel);
        }

        // DELETE: api/Combustivels/5
        [ResponseType(typeof(Combustivel))]
        public IHttpActionResult DeleteCombustivel(int id)
        {
            Combustivel combustivel = db.Combustivels.Find(id);
            if (combustivel == null)
            {
                return NotFound();
            }

            db.Combustivels.Remove(combustivel);
            db.SaveChanges();

            return Ok(combustivel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CombustivelExists(int id)
        {
            return db.Combustivels.Count(e => e.IdCombustivel == id) > 0;
        }
    }
}