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
    
    public partial class spListaVeiculos_Result
    {
        public int IdVeiculo { get; set; }
        public string Veiculo { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
        public int IdModelo { get; set; }
        public string Modelo { get; set; }
        public int IdTipologia { get; set; }
        public string Tipologia { get; set; }
        public int IdCombustivel { get; set; }
        public string Combustivel { get; set; }
        public Nullable<int> IdUtilizador { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public decimal KmsIniciais { get; set; }
        public Nullable<int> KmsContrato { get; set; }
        public bool Ativo { get; set; }
        public bool Disponivel { get; set; }
    }
}
