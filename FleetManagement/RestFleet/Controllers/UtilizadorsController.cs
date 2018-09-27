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
using Newtonsoft.Json;
using RestFleet.Mappers;
using RestFleet.Models;
using static RestFleet.Mappers.MapperJson;

namespace RestFleet.Controllers
{
    public class UtilizadorsController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Utilizadors
        public IQueryable<Utilizador> GetUtilizadors()
        {
            return db.Utilizadors;
        }

        // GET: api/Utilizadors/5
        [ResponseType(typeof(Utilizador))]
        public IHttpActionResult GetUtilizador(int id)
        {
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return Ok(utilizador);
        }

        // PUT: api/Utilizadors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUtilizador(int id, Utilizador utilizador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != utilizador.IdUtilizador)
            {
                return BadRequest();
            }

            db.Entry(utilizador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizadorExists(id))
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

        // POST: api/Utilizadors
        [ResponseType(typeof(Utilizador))]
        public IHttpActionResult PostUtilizador(Utilizador utilizador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Utilizadors.Add(utilizador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = utilizador.IdUtilizador }, utilizador);
        }

        // POST: api/Utilizadors/AdicionarUtilizador
        [Route("api/Utilizadors/AdicionarUtilizador")]
        [ResponseType(typeof(Utilizador))]
        public IHttpActionResult AdicionarUtilizador(HttpRequestMessage data)
        {
            var jsontxt = data.Content.ReadAsStringAsync().Result;
            var a = MapperJson.FromJson<UserJson>(jsontxt);

            var utilizador = MapperApp.UtilizadorAppToRest(a);

            db.Utilizadors.Add(utilizador);
            db.SaveChanges();

            return Ok(db.Utilizadors.OrderByDescending(u => u.IdUtilizador).FirstOrDefault());
            //return CreatedAtRoute("DefaultApi", new { id = utilizador.IdUtilizador }, utilizador);
        }

        // POST: api/Utilizadors/login
        //[ResponseType(typeof(Utilizador))]
        [Route("api/Utilizadors/Login")]
        [HttpPost]
        public IHttpActionResult Login(HttpRequestMessage data)
        {
            var jsontxt = data.Content.ReadAsStringAsync().Result;
            var a = MapperJson.FromJson<LoginJson>(jsontxt);

            Utilizador utilizador = db.Utilizadors.FirstOrDefault(x => x.Username == a.User && x.Password == a.Password);

            if (utilizador == null)
            {
                return NotFound();
            }

            return Ok(utilizador);
        }

        // GET: api/Utilizadors/passworddefault
        [Route("api/Utilizadors/passworddefault")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public IHttpActionResult passworddefault()
        {
            return Ok(db.spObtemPasswordDefault());
        }

        // DELETE: api/Utilizadors/5
        [ResponseType(typeof(Utilizador))]
        public IHttpActionResult DeleteUtilizador(int id)
        {
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            db.Utilizadors.Remove(utilizador);
            db.SaveChanges();

            return Ok(utilizador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UtilizadorExists(int id)
        {
            return db.Utilizadors.Count(e => e.IdUtilizador == id) > 0;
        }
    }
}