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
    public class Danos_Veiculo_ComprovativoController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Danos_Veiculo_Comprovativo
        public IQueryable<Danos_Veiculo_Comprovativo> GetDanos_Veiculo_Comprovativo()
        {
            return db.Danos_Veiculo_Comprovativo;
        }

        // GET: api/Danos_Veiculo_Comprovativo/5
        [ResponseType(typeof(Danos_Veiculo_Comprovativo))]
        public IHttpActionResult GetDanos_Veiculo_Comprovativo(int id)
        {
            Danos_Veiculo_Comprovativo danos_Veiculo_Comprovativo = db.Danos_Veiculo_Comprovativo.Find(id);
            if (danos_Veiculo_Comprovativo == null)
            {
                return NotFound();
            }

            return Ok(danos_Veiculo_Comprovativo);
        }

        // PUT: api/Danos_Veiculo_Comprovativo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDanos_Veiculo_Comprovativo(int id, Danos_Veiculo_Comprovativo danos_Veiculo_Comprovativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danos_Veiculo_Comprovativo.IdDanosVeiculoComprovativo)
            {
                return BadRequest();
            }

            db.Entry(danos_Veiculo_Comprovativo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Danos_Veiculo_ComprovativoExists(id))
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

        // POST: api/Danos_Veiculo_Comprovativo
        [ResponseType(typeof(Danos_Veiculo_Comprovativo))]
        public IHttpActionResult PostDanos_Veiculo_Comprovativo(Danos_Veiculo_Comprovativo danos_Veiculo_Comprovativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Danos_Veiculo_Comprovativo.Add(danos_Veiculo_Comprovativo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = danos_Veiculo_Comprovativo.IdDanosVeiculoComprovativo }, danos_Veiculo_Comprovativo);
        }

        // DELETE: api/Danos_Veiculo_Comprovativo/5
        [ResponseType(typeof(Danos_Veiculo_Comprovativo))]
        public IHttpActionResult DeleteDanos_Veiculo_Comprovativo(int id)
        {
            Danos_Veiculo_Comprovativo danos_Veiculo_Comprovativo = db.Danos_Veiculo_Comprovativo.Find(id);
            if (danos_Veiculo_Comprovativo == null)
            {
                return NotFound();
            }

            db.Danos_Veiculo_Comprovativo.Remove(danos_Veiculo_Comprovativo);
            db.SaveChanges();

            return Ok(danos_Veiculo_Comprovativo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Danos_Veiculo_ComprovativoExists(int id)
        {
            return db.Danos_Veiculo_Comprovativo.Count(e => e.IdDanosVeiculoComprovativo == id) > 0;
        }
    }
}