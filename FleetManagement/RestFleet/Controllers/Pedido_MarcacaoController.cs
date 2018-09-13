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
    public class Pedido_MarcacaoController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Pedido_Marcacao
        public IQueryable<Pedido_Marcacao> GetPedido_Marcacao()
        {
            return db.Pedido_Marcacao;
        }

        // GET: api/Pedido_Marcacao/5
        [ResponseType(typeof(Pedido_Marcacao))]
        public IHttpActionResult GetPedido_Marcacao(int id)
        {
            Pedido_Marcacao pedido_Marcacao = db.Pedido_Marcacao.Find(id);
            if (pedido_Marcacao == null)
            {
                return NotFound();
            }

            return Ok(pedido_Marcacao);
        }

        // PUT: api/Pedido_Marcacao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedido_Marcacao(int id, Pedido_Marcacao pedido_Marcacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido_Marcacao.IdPedidoMarcacao)
            {
                return BadRequest();
            }

            db.Entry(pedido_Marcacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pedido_MarcacaoExists(id))
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

        // POST: api/Pedido_Marcacao
        [ResponseType(typeof(Pedido_Marcacao))]
        public IHttpActionResult PostPedido_Marcacao(Pedido_Marcacao pedido_Marcacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pedido_Marcacao.Add(pedido_Marcacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedido_Marcacao.IdPedidoMarcacao }, pedido_Marcacao);
        }

        // DELETE: api/Pedido_Marcacao/5
        [ResponseType(typeof(Pedido_Marcacao))]
        public IHttpActionResult DeletePedido_Marcacao(int id)
        {
            Pedido_Marcacao pedido_Marcacao = db.Pedido_Marcacao.Find(id);
            if (pedido_Marcacao == null)
            {
                return NotFound();
            }

            db.Pedido_Marcacao.Remove(pedido_Marcacao);
            db.SaveChanges();

            return Ok(pedido_Marcacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Pedido_MarcacaoExists(int id)
        {
            return db.Pedido_Marcacao.Count(e => e.IdPedidoMarcacao == id) > 0;
        }
    }
}