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
    public class Perfil_PermissaoController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Perfil_Permissao
        public IQueryable<Perfil_Permissao> GetPerfil_Permissao()
        {
            return db.Perfil_Permissao;
        }

        // GET: api/Perfil_Permissao/5
        [ResponseType(typeof(Perfil_Permissao))]
        public IHttpActionResult GetPerfil_Permissao(int id)
        {
            Perfil_Permissao perfil_Permissao = db.Perfil_Permissao.Find(id);
            if (perfil_Permissao == null)
            {
                return NotFound();
            }

            return Ok(perfil_Permissao);
        }

        // PUT: api/Perfil_Permissao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfil_Permissao(int id, Perfil_Permissao perfil_Permissao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil_Permissao.IdPerfilPermissao)
            {
                return BadRequest();
            }

            db.Entry(perfil_Permissao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Perfil_PermissaoExists(id))
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

        // POST: api/Perfil_Permissao
        [ResponseType(typeof(Perfil_Permissao))]
        public IHttpActionResult PostPerfil_Permissao(Perfil_Permissao perfil_Permissao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Perfil_Permissao.Add(perfil_Permissao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perfil_Permissao.IdPerfilPermissao }, perfil_Permissao);
        }

        // DELETE: api/Perfil_Permissao/5
        [ResponseType(typeof(Perfil_Permissao))]
        public IHttpActionResult DeletePerfil_Permissao(int id)
        {
            Perfil_Permissao perfil_Permissao = db.Perfil_Permissao.Find(id);
            if (perfil_Permissao == null)
            {
                return NotFound();
            }

            db.Perfil_Permissao.Remove(perfil_Permissao);
            db.SaveChanges();

            return Ok(perfil_Permissao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Perfil_PermissaoExists(int id)
        {
            return db.Perfil_Permissao.Count(e => e.IdPerfilPermissao == id) > 0;
        }
    }
}