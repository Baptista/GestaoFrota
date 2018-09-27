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
    public class MarcasController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Marcas
        public IQueryable<Marca> GetMarcas()
        {
            return db.Marcas;
        }

        // GET: api/Marcas/5
        [ResponseType(typeof(Marca))]
        public IHttpActionResult GetMarca(int id)
        {
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        // PUT: api/Marcas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarca(int id, Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marca.IdMarca)
            {
                return BadRequest();
            }

            db.Entry(marca).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marcas
        [ResponseType(typeof(Marca))]
        public IHttpActionResult PostMarca(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marcas.Add(marca);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = marca.IdMarca }, marca);
        }

        // POST: api/Marcas/AdicionarMarca
        [Route("api/Marcas/AdicionarMarca")]
        [ResponseType(typeof(Marca))]
        public IHttpActionResult AdicionarMarca(HttpRequestMessage data)
        {
            var jsontxt = data.Content.ReadAsStringAsync().Result;
            var a = MapperJson.FromJson<BrandJson>(jsontxt);

            var marca = MapperApp.MarcaAppToRest(a);

            db.Marcas.Add(marca);
            db.SaveChanges();

            return Ok(db.Marcas.OrderByDescending(u => u.IdMarca).FirstOrDefault());
            //return CreatedAtRoute("DefaultApi", new { id = a.IdMarca }, a);
        }

        // POST: api/Marcas/EditarMarca
        [Route("api/Marcas/EditarMarca")]
        [ResponseType(typeof(Marca))]
        public IHttpActionResult EditarMarca(HttpRequestMessage data)
        {
            var jsontxt = data.Content.ReadAsStringAsync().Result;
            var a = MapperJson.FromJson<BrandJson>(jsontxt);

            var marca = MapperApp.MarcaAppToRest(a);

            //var result = db.Marcas.SingleOrDefault(b => b.IdMarca == marca.IdMarca);
            ////db.Marcas.Add
            //if (result != null)
            //{
            //    result = marca;
            //    db.SaveChanges();
            //}
            db.spAlteraMarca(marca.IdMarca, marca.Descricao);

            return Ok(db.Marcas.SingleOrDefault(b => b.IdMarca == marca.IdMarca));
            //return CreatedAtRoute("DefaultApi", new { id = a.IdMarca }, a);
        }

        // DELETE: api/Marcas/5
        [ResponseType(typeof(Marca))]
        public IHttpActionResult DeleteMarca(int id)
        {
            Marca marca = db.Marcas.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            db.Marcas.Remove(marca);
            db.SaveChanges();

            return Ok(marca);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarcaExists(int id)
        {
            return db.Marcas.Count(e => e.IdMarca == id) > 0;
        }
    }
}