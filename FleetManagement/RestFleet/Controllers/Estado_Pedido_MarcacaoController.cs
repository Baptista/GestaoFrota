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
    public class Estado_Pedido_MarcacaoController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Estado_Pedido_Marcacao
        public IQueryable<Estado_Pedido_Marcacao> GetEstado_Pedido_Marcacao()
        {
            return db.Estado_Pedido_Marcacao;
        }

        // GET: api/Estado_Pedido_Marcacao/5
        [ResponseType(typeof(Estado_Pedido_Marcacao))]
        public IHttpActionResult GetEstado_Pedido_Marcacao(int id)
        {
            Estado_Pedido_Marcacao estado_Pedido_Marcacao = db.Estado_Pedido_Marcacao.Find(id);
            if (estado_Pedido_Marcacao == null)
            {
                return NotFound();
            }

            return Ok(estado_Pedido_Marcacao);
        }

        // PUT: api/Estado_Pedido_Marcacao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstado_Pedido_Marcacao(int id, Estado_Pedido_Marcacao estado_Pedido_Marcacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estado_Pedido_Marcacao.IdEstadoPedidoMarcacao)
            {
                return BadRequest();
            }

            db.Entry(estado_Pedido_Marcacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Estado_Pedido_MarcacaoExists(id))
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

        // POST: api/Estado_Pedido_Marcacao
        [ResponseType(typeof(Estado_Pedido_Marcacao))]
        public IHttpActionResult PostEstado_Pedido_Marcacao(Estado_Pedido_Marcacao estado_Pedido_Marcacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estado_Pedido_Marcacao.Add(estado_Pedido_Marcacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estado_Pedido_Marcacao.IdEstadoPedidoMarcacao }, estado_Pedido_Marcacao);
        }

        // DELETE: api/Estado_Pedido_Marcacao/5
        [ResponseType(typeof(Estado_Pedido_Marcacao))]
        public IHttpActionResult DeleteEstado_Pedido_Marcacao(int id)
        {
            Estado_Pedido_Marcacao estado_Pedido_Marcacao = db.Estado_Pedido_Marcacao.Find(id);
            if (estado_Pedido_Marcacao == null)
            {
                return NotFound();
            }

            db.Estado_Pedido_Marcacao.Remove(estado_Pedido_Marcacao);
            db.SaveChanges();

            return Ok(estado_Pedido_Marcacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Estado_Pedido_MarcacaoExists(int id)
        {
            return db.Estado_Pedido_Marcacao.Count(e => e.IdEstadoPedidoMarcacao == id) > 0;
        }
    }
}