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
    
    public partial class Utilizador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilizador()
        {
            this.Pedido_Marcacao = new HashSet<Pedido_Marcacao>();
            this.Pedido_Marcacao_Historico = new HashSet<Pedido_Marcacao_Historico>();
            this.Veiculoes = new HashSet<Veiculo>();
        }
    
        public int IdUtilizador { get; set; }
        public int IdPerfil { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public bool Ativo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Marcacao> Pedido_Marcacao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_Marcacao_Historico> Pedido_Marcacao_Historico { get; set; }
        public virtual Perfil Perfil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veiculo> Veiculoes { get; set; }
    }
}
