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
using RestFleet.Mappers;
using RestFleet.Models;
using static RestFleet.Mappers.MapperJson;

namespace RestFleet.Controllers
{
    public class VeiculoesController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Veiculoes
        public IQueryable<Veiculo> GetVeiculoes()
        {
            return db.Veiculoes;
        }

        // GET: api/Veiculoes/5
        [ResponseType(typeof(Veiculo))]
        public IHttpActionResult GetVeiculo(int id)
        {
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        // PUT: api/Veiculoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVeiculo(int id, Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != veiculo.IdVeiculo)
            {
                return BadRequest();
            }

            db.Entry(veiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
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

        // POST: api/Veiculoes
        [ResponseType(typeof(Veiculo))]
        public IHttpActionResult PostVeiculo(Veiculo veiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Veiculoes.Add(veiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = veiculo.IdVeiculo }, veiculo);
        }

        // POST: api/Veiculoes/AdicionarVeiculo
        [Route("api/Veiculoes/AdicionarVeiculo")]
        [ResponseType(typeof(Veiculo))]
        public IHttpActionResult AdicionarVeiculo(HttpRequestMessage data)
        {
            var jsontxt = data.Content.ReadAsStringAsync().Result;
            var a = MapperJson.FromJson<VehicleJson>(jsontxt);

            var veiculo = MapperApp.VeiculoAppToRest(a);

            db.Veiculoes.Add(veiculo);
            db.SaveChanges();

            return Ok(db.Veiculoes.OrderByDescending(u => u.IdVeiculo).FirstOrDefault());
            //return CreatedAtRoute("DefaultApi", new { id = veiculo.IdVeiculo }, veiculo);
        }

        // POST: api/Veiculoes/EditarVeiculo
        [Route("api/Veiculoes/EditarVeiculo")]
        [ResponseType(typeof(Veiculo))]
        public IHttpActionResult EditarVeiculo(HttpRequestMessage data)
        {
            var jsontxt = data.Content.ReadAsStringAsync().Result;
            var a = MapperJson.FromJson<VehicleJson>(jsontxt);

            var veiculo = MapperApp.VeiculoAppToRest(a);

            db.spAlteraVeiculo(veiculo.IdVeiculo, veiculo.IdModelo, veiculo.IdTipologia, veiculo.Matricula, veiculo.IdUtilizador, veiculo.KmsIniciais, veiculo.KmsContrato);

            return Ok(db.Veiculoes.SingleOrDefault(b => b.IdVeiculo == veiculo.IdVeiculo));
            //return CreatedAtRoute("DefaultApi", new { id = veiculo.IdVeiculo }, veiculo);
        }

        // DELETE: api/Veiculoes/5
        [ResponseType(typeof(Veiculo))]
        public IHttpActionResult DeleteVeiculo(int id)
        {
            Veiculo veiculo = db.Veiculoes.Find(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            db.Veiculoes.Remove(veiculo);
            db.SaveChanges();

            return Ok(veiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VeiculoExists(int id)
        {
            return db.Veiculoes.Count(e => e.IdVeiculo == id) > 0;
        }
    }
}