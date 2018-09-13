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
    public class ConfiguracaosController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Configuracaos
        public IQueryable<Configuracao> GetConfiguracaos()
        {
            return db.Configuracaos;
        }

        // GET: api/Configuracaos/5
        [ResponseType(typeof(Configuracao))]
        public IHttpActionResult GetConfiguracao(int id)
        {
            Configuracao configuracao = db.Configuracaos.Find(id);
            if (configuracao == null)
            {
                return NotFound();
            }

            return Ok(configuracao);
        }

        // PUT: api/Configuracaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfiguracao(int id, Configuracao configuracao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configuracao.IdConfiguracao)
            {
                return BadRequest();
            }

            db.Entry(configuracao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguracaoExists(id))
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

        // POST: api/Configuracaos
        [ResponseType(typeof(Configuracao))]
        public IHttpActionResult PostConfiguracao(Configuracao configuracao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Configuracaos.Add(configuracao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = configuracao.IdConfiguracao }, configuracao);
        }

        // DELETE: api/Configuracaos/5
        [ResponseType(typeof(Configuracao))]
        public IHttpActionResult DeleteConfiguracao(int id)
        {
            Configuracao configuracao = db.Configuracaos.Find(id);
            if (configuracao == null)
            {
                return NotFound();
            }

            db.Configuracaos.Remove(configuracao);
            db.SaveChanges();

            return Ok(configuracao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfiguracaoExists(int id)
        {
            return db.Configuracaos.Count(e => e.IdConfiguracao == id) > 0;
        }
    }
}