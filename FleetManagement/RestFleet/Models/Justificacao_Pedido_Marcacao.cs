//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestFleet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Justificacao_Pedido_Marcacao
    {
        public int IdJustificacaoPedidoMarcacao { get; set; }
        public int IdTipoJustificacaoPedido { get; set; }
        public int IdPedidoMarcacao { get; set; }
        public string Justificacao { get; set; }
        public int IdPedidoMarcacaoConflito { get; set; }
    
        public virtual Pedido_Marcacao Pedido_Marcacao { get; set; }
        public virtual Tipo_Justificacao_Pedido Tipo_Justificacao_Pedido { get; set; }
        public virtual Pedido_Marcacao Pedido_Marcacao1 { get; set; }
    }
}
