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
    public class ModeloesController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Modeloes
        public IQueryable<Modelo> GetModeloes()
        {
            return db.Modeloes;
        }

        // GET: api/Modeloes/5
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult GetModelo(int id)
        {
            Modelo modelo = db.Modeloes.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(modelo);
        }

        // PUT: api/Modeloes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModelo(int id, Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelo.IdModelo)
            {
                return BadRequest();
            }

            db.Entry(modelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modeloes
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult PostModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modeloes.Add(modelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = modelo.IdModelo }, modelo);
        }

        // POST: api/Modeloes/AdicionarModelo
        [Route("api/Modeloes/AdicionarModelo")]
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult AdicionarModelo(HttpRequestMessage data)
        {
            var jsontxt = data.Content.ReadAsStringAsync().Result;
            var a = MapperJson.FromJson<ModelJson>(jsontxt);

            var modelo = MapperApp.ModeloAppToRest(a);

            db.Modeloes.Add(modelo);
            db.SaveChanges();

            return Ok(db.Modeloes.OrderByDescending(u => u.IdModelo).FirstOrDefault());
            //return CreatedAtRoute("DefaultApi", new { id = a.Id }, a);
        }

        // POST: api/Modeloes/EditarModelo
        [Route("api/Modeloes/EditarModelo")]
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult EditarModelo(HttpRequestMessage data)
        {
            var jsontxt = data.Content.ReadAsStringAsync().Result;
            var a = MapperJson.FromJson<ModelJson>(jsontxt);

            var modelo = MapperApp.ModeloAppToRest(a);

            //var result = db.Modeloes.SingleOrDefault(b => b.IdModelo == modelo.IdModelo);
            //if (result != null)
            //{
            //    result = modelo;
            //    db.SaveChanges();
            //}
            db.spAlteraModelo(modelo.IdModelo, modelo.IdMarca, modelo.Descricao, modelo.IdCombustivel);

            return Ok(db.Modeloes.SingleOrDefault(b => b.IdModelo == modelo.IdModelo));
            //return CreatedAtRoute("DefaultApi", new { id = a.Id }, a);
        }

        // DELETE: api/Modeloes/5
        [ResponseType(typeof(Modelo))]
        public IHttpActionResult DeleteModelo(int id)
        {
            Modelo modelo = db.Modeloes.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            db.Modeloes.Remove(modelo);
            db.SaveChanges();

            return Ok(modelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeloExists(int id)
        {
            return db.Modeloes.Count(e => e.IdModelo == id) > 0;
        }
    }
}