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
    public class Pedido_Marcacao_HistoricoController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Pedido_Marcacao_Historico
        public IQueryable<Pedido_Marcacao_Historico> GetPedido_Marcacao_Historico()
        {
            return db.Pedido_Marcacao_Historico;
        }

        // GET: api/Pedido_Marcacao_Historico/5
        [ResponseType(typeof(Pedido_Marcacao_Historico))]
        public IHttpActionResult GetPedido_Marcacao_Historico(int id)
        {
            Pedido_Marcacao_Historico pedido_Marcacao_Historico = db.Pedido_Marcacao_Historico.Find(id);
            if (pedido_Marcacao_Historico == null)
            {
                return NotFound();
            }

            return Ok(pedido_Marcacao_Historico);
        }

        // PUT: api/Pedido_Marcacao_Historico/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedido_Marcacao_Historico(int id, Pedido_Marcacao_Historico pedido_Marcacao_Historico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido_Marcacao_Historico.IdPedidoMarcacaoHistorico)
            {
                return BadRequest();
            }

            db.Entry(pedido_Marcacao_Historico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pedido_Marcacao_HistoricoExists(id))
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

        // POST: api/Pedido_Marcacao_Historico
        [ResponseType(typeof(Pedido_Marcacao_Historico))]
        public IHttpActionResult PostPedido_Marcacao_Historico(Pedido_Marcacao_Historico pedido_Marcacao_Historico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedido_Marcacao_Historico.Add(pedido_Marcacao_Historico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedido_Marcacao_Historico.IdPedidoMarcacaoHistorico }, pedido_Marcacao_Historico);
        }

        // DELETE: api/Pedido_Marcacao_Historico/5
        [ResponseType(typeof(Pedido_Marcacao_Historico))]
        public IHttpActionResult DeletePedido_Marcacao_Historico(int id)
        {
            Pedido_Marcacao_Historico pedido_Marcacao_Historico = db.Pedido_Marcacao_Historico.Find(id);
            if (pedido_Marcacao_Historico == null)
            {
                return NotFound();
            }

            db.Pedido_Marcacao_Historico.Remove(pedido_Marcacao_Historico);
            db.SaveChanges();

            return Ok(pedido_Marcacao_Historico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pedido_Marcacao_HistoricoExists(int id)
        {
            return db.Pedido_Marcacao_Historico.Count(e => e.IdPedidoMarcacaoHistorico == id) > 0;
        }
    }
}