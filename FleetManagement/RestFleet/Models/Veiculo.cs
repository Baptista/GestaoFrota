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
    
    public partial class Veiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Veiculo()
        {
            this.Danos_Veiculo = new HashSet<Danos_Veiculo>();
            this.Pedido_Marcacao_Historico = new HashSet<Pedido_Marcacao_Historico>();
        }
    
        public int IdVeiculo { get; set; }
        public int IdModelo { get; set; }
        public int IdTipologia { get; set; }
        public Nullable<int> IdUtilizador { get; set; }
        public string Matricula { get; set; }
        public bool Disponivel { get; set; }
        public decimal KmsIniciais { get; set; }
        public decimal KmsContrato { get; set; }
        public bool Ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Danos_Veiculo> Danos_Veiculo { get; set; }
        public virtual Modelo Modelo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Marcacao_Historico> Pedido_Marcacao_Historico { get; set; }
        public virtual Tipologia Tipologia { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}