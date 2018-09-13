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
    public class Veiculo_EntregaController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Veiculo_Entrega
        public IQueryable<Veiculo_Entrega> GetVeiculo_Entrega()
        {
            return db.Veiculo_Entrega;
        }

        // GET: api/Veiculo_Entrega/5
        [ResponseType(typeof(Veiculo_Entrega))]
        public IHttpActionResult GetVeiculo_Entrega(int id)
        {
            Veiculo_Entrega veiculo_Entrega = db.Veiculo_Entrega.Find(id);
            if (veiculo_Entrega == null)
            {
                return NotFound();
            }

            return Ok(veiculo_Entrega);
        }

        // PUT: api/Veiculo_Entrega/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVeiculo_Entrega(int id, Veiculo_Entrega veiculo_Entrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veiculo_Entrega.IdVeiculoEntrega)
            {
                return BadRequest();
            }

            db.Entry(veiculo_Entrega).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Veiculo_EntregaExists(id))
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

        // POST: api/Veiculo_Entrega
        [ResponseType(typeof(Veiculo_Entrega))]
        public IHttpActionResult PostVeiculo_Entrega(Veiculo_Entrega veiculo_Entrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Veiculo_Entrega.Add(veiculo_Entrega);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = veiculo_Entrega.IdVeiculoEntrega }, veiculo_Entrega);
        }

        // DELETE: api/Veiculo_Entrega/5
        [ResponseType(typeof(Veiculo_Entrega))]
        public IHttpActionResult DeleteVeiculo_Entrega(int id)
        {
            Veiculo_Entrega veiculo_Entrega = db.Veiculo_Entrega.Find(id);
            if (veiculo_Entrega == null)
            {
                return NotFound();
            }

            db.Veiculo_Entrega.Remove(veiculo_Entrega);
            db.SaveChanges();

            return Ok(veiculo_Entrega);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Veiculo_EntregaExists(int id)
        {
            return db.Veiculo_Entrega.Count(e => e.IdVeiculoEntrega == id) > 0;
        }
    }
}