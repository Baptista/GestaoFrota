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
    public class Justificacao_Pedido_MarcacaoController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Justificacao_Pedido_Marcacao
        public IQueryable<Justificacao_Pedido_Marcacao> GetJustificacao_Pedido_Marcacao()
        {
            return db.Justificacao_Pedido_Marcacao;
        }

        // GET: api/Justificacao_Pedido_Marcacao/5
        [ResponseType(typeof(Justificacao_Pedido_Marcacao))]
        public IHttpActionResult GetJustificacao_Pedido_Marcacao(int id)
        {
            Justificacao_Pedido_Marcacao justificacao_Pedido_Marcacao = db.Justificacao_Pedido_Marcacao.Find(id);
            if (justificacao_Pedido_Marcacao == null)
            {
                return NotFound();
            }

            return Ok(justificacao_Pedido_Marcacao);
        }

        // PUT: api/Justificacao_Pedido_Marcacao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJustificacao_Pedido_Marcacao(int id, Justificacao_Pedido_Marcacao justificacao_Pedido_Marcacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != justificacao_Pedido_Marcacao.IdJustificacaoPedidoMarcacao)
            {
                return BadRequest();
            }

            db.Entry(justificacao_Pedido_Marcacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Justificacao_Pedido_MarcacaoExists(id))
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

        // POST: api/Justificacao_Pedido_Marcacao
        [ResponseType(typeof(Justificacao_Pedido_Marcacao))]
        public IHttpActionResult PostJustificacao_Pedido_Marcacao(Justificacao_Pedido_Marcacao justificacao_Pedido_Marcacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Justificacao_Pedido_Marcacao.Add(justificacao_Pedido_Marcacao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = justificacao_Pedido_Marcacao.IdJustificacaoPedidoMarcacao }, justificacao_Pedido_Marcacao);
        }

        // DELETE: api/Justificacao_Pedido_Marcacao/5
        [ResponseType(typeof(Justificacao_Pedido_Marcacao))]
        public IHttpActionResult DeleteJustificacao_Pedido_Marcacao(int id)
        {
            Justificacao_Pedido_Marcacao justificacao_Pedido_Marcacao = db.Justificacao_Pedido_Marcacao.Find(id);
            if (justificacao_Pedido_Marcacao == null)
            {
                return NotFound();
            }

            db.Justificacao_Pedido_Marcacao.Remove(justificacao_Pedido_Marcacao);
            db.SaveChanges();

            return Ok(justificacao_Pedido_Marcacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Justificacao_Pedido_MarcacaoExists(int id)
        {
            return db.Justificacao_Pedido_Marcacao.Count(e => e.IdJustificacaoPedidoMarcacao == id) > 0;
        }
    }
}