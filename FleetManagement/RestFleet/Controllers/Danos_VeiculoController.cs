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
    public class Danos_VeiculoController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Danos_Veiculo
        public IQueryable<Danos_Veiculo> GetDanos_Veiculo()
        {
            return db.Danos_Veiculo;
        }

        // GET: api/Danos_Veiculo/5
        [ResponseType(typeof(Danos_Veiculo))]
        public IHttpActionResult GetDanos_Veiculo(int id)
        {
            Danos_Veiculo danos_Veiculo = db.Danos_Veiculo.Find(id);
            if (danos_Veiculo == null)
            {
                return NotFound();
            }

            return Ok(danos_Veiculo);
        }

        // PUT: api/Danos_Veiculo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDanos_Veiculo(int id, Danos_Veiculo danos_Veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danos_Veiculo.IdDanosVeiculo)
            {
                return BadRequest();
            }

            db.Entry(danos_Veiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Danos_VeiculoExists(id))
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

        // POST: api/Danos_Veiculo
        [ResponseType(typeof(Danos_Veiculo))]
        public IHttpActionResult PostDanos_Veiculo(Danos_Veiculo danos_Veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Danos_Veiculo.Add(danos_Veiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = danos_Veiculo.IdDanosVeiculo }, danos_Veiculo);
        }

        // DELETE: api/Danos_Veiculo/5
        [ResponseType(typeof(Danos_Veiculo))]
        public IHttpActionResult DeleteDanos_Veiculo(int id)
        {
            Danos_Veiculo danos_Veiculo = db.Danos_Veiculo.Find(id);
            if (danos_Veiculo == null)
            {
                return NotFound();
            }

            db.Danos_Veiculo.Remove(danos_Veiculo);
            db.SaveChanges();

            return Ok(danos_Veiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Danos_VeiculoExists(int id)
        {
            return db.Danos_Veiculo.Count(e => e.IdDanosVeiculo == id) > 0;
        }
    }
}