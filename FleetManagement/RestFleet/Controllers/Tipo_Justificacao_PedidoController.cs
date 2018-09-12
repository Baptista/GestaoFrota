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
    public class Tipo_Justificacao_PedidoController : ApiController
    {
        private gestaofrotasEntities db = new gestaofrotasEntities();

        // GET: api/Tipo_Justificacao_Pedido
        public IQueryable<Tipo_Justificacao_Pedido> GetTipo_Justificacao_Pedido()
        {
            return db.Tipo_Justificacao_Pedido;
        }

        // GET: api/Tipo_Justificacao_Pedido/5
        [ResponseType(typeof(Tipo_Justificacao_Pedido))]
        public IHttpActionResult GetTipo_Justificacao_Pedido(int id)
        {
            Tipo_Justificacao_Pedido tipo_Justificacao_Pedido = db.Tipo_Justificacao_Pedido.Find(id);
            if (tipo_Justificacao_Pedido == null)
            {
                return NotFound();
            }

            return Ok(tipo_Justificacao_Pedido);
        }

        // PUT: api/Tipo_Justificacao_Pedido/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipo_Justificacao_Pedido(int id, Tipo_Justificacao_Pedido tipo_Justificacao_Pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipo_Justificacao_Pedido.IdTipoJustificacaoPedido)
            {
                return BadRequest();
            }

            db.Entry(tipo_Justificacao_Pedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tipo_Justificacao_PedidoExists(id))
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

        // POST: api/Tipo_Justificacao_Pedido
        [ResponseType(typeof(Tipo_Justificacao_Pedido))]
        public IHttpActionResult PostTipo_Justificacao_Pedido(Tipo_Justificacao_Pedido tipo_Justificacao_Pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tipo_Justificacao_Pedido.Add(tipo_Justificacao_Pedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipo_Justificacao_Pedido.IdTipoJustificacaoPedido }, tipo_Justificacao_Pedido);
        }

        // DELETE: api/Tipo_Justificacao_Pedido/5
        [ResponseType(typeof(Tipo_Justificacao_Pedido))]
        public IHttpActionResult DeleteTipo_Justificacao_Pedido(int id)
        {
            Tipo_Justificacao_Pedido tipo_Justificacao_Pedido = db.Tipo_Justificacao_Pedido.Find(id);
            if (tipo_Justificacao_Pedido == null)
            {
                return NotFound();
            }

            db.Tipo_Justificacao_Pedido.Remove(tipo_Justificacao_Pedido);
            db.SaveChanges();

            return Ok(tipo_Justificacao_Pedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tipo_Justificacao_PedidoExists(int id)
        {
            return db.Tipo_Justificacao_Pedido.Count(e => e.IdTipoJustificacaoPedido == id) > 0;
        }
    }
}