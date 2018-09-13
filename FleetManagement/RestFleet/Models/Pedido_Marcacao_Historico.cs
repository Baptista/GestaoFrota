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
    
    public partial class Pedido_Marcacao_Historico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido_Marcacao_Historico()
        {
            this.Danos_Veiculo = new HashSet<Danos_Veiculo>();
            this.Veiculo_Entrega = new HashSet<Veiculo_Entrega>();
        }
    
        public int IdPedidoMarcacaoHistorico { get; set; }
        public int IdPedidoMarcacao { get; set; }
        public int IdEstadoPedidoMarcacao { get; set; }
        public int IdVeiculo { get; set; }
        public int IdUtilizador { get; set; }
        public bool Ativo { get; set; }
        public System.DateTime DataInicio { get; set; }
        public System.DateTime DataFim { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Danos_Veiculo> Danos_Veiculo { get; set; }
        public virtual Estado_Pedido_Marcacao Estado_Pedido_Marcacao { get; set; }
        public virtual Pedido_Marcacao Pedido_Marcacao { get; set; }
        public virtual Utilizador Utilizador { get; set; }
        public virtual Veiculo Veiculo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veiculo_Entrega> Veiculo_Entrega { get; set; }
    }
}
