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
    public class PermissaosController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Permissaos
        public IQueryable<Permissao> GetPermissaos()
        {
            return db.Permissaos;
        }

        // GET: api/Permissaos/5
        [ResponseType(typeof(Permissao))]
        public IHttpActionResult GetPermissao(int id)
        {
            Permissao permissao = db.Permissaos.Find(id);
            if (permissao == null)
            {
                return NotFound();
            }

            return Ok(permissao);
        }

        // PUT: api/Permissaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPermissao(int id, Permissao permissao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permissao.IdPermissao)
            {
                return BadRequest();
            }

            db.Entry(permissao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissaoExists(id))
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

        // POST: api/Permissaos
        [ResponseType(typeof(Permissao))]
        public IHttpActionResult PostPermissao(Permissao permissao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Permissaos.Add(permissao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permissao.IdPermissao }, permissao);
        }

        // DELETE: api/Permissaos/5
        [ResponseType(typeof(Permissao))]
        public IHttpActionResult DeletePermissao(int id)
        {
            Permissao permissao = db.Permissaos.Find(id);
            if (permissao == null)
            {
                return NotFound();
            }

            db.Permissaos.Remove(permissao);
            db.SaveChanges();

            return Ok(permissao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermissaoExists(int id)
        {
            return db.Permissaos.Count(e => e.IdPermissao == id) > 0;
        }
    }
}