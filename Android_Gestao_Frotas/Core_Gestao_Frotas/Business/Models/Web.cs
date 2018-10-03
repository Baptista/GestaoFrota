using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Gestao_Frotas.Business.Models
{
    public class Web : BaseModel
    {

    }

    public class WebBrand
    {
        public int IdMarca { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public List<object> Modeloes { get; set; }
    }

    public class WebFuel
    {
        public int IdCombustivel { get; set; }
        public string Descricao { get; set; }
        public List<object> Modeloes { get; set; }
    }

    public class WebTypology
    {
        public int IdTipologia { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public List<object> Veiculoes { get; set; }
    }

    public class WebModel
    {
        public int IdModelo { get; set; }
        public int IdMarca { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int IdCombustivel { get; set; }
        public object Combustivel { get; set; }
        public object Marca { get; set; }
        public List<object> Veiculoes { get; set; }
    }

    public class WebVehicle
    {
        public int IdVeiculo { get; set; }
        public int IdModelo { get; set; }
        public int IdTipologia { get; set; }
        public int? IdUtilizador { get; set; }
        public string Matricula { get; set; }
        public bool Disponivel { get; set; }
        public double KmsIniciais { get; set; }
        public double KmsContrato { get; set; }
        public bool Ativo { get; set; }
        public List<object> Danos_Veiculo { get; set; }
        public object Modelo { get; set; }
        public List<object> Pedido_Marcacao_Historico { get; set; }
        public object Tipologia { get; set; }
        public object Utilizador { get; set; }
    }

    public class WebVehicleDelivery
    {
        public int IdVeiculoEntrega { get; set; }
        public int IdPedidoMarcacaoHistorico { get; set; }
        public DateTime Data { get; set; }
        public double Kms { get; set; }
        public object Pedido_Marcacao_Historico { get; set; }
    }

    public class WebDamageVehicle
    {
        public int IdDanosVeiculo { get; set; }
        public int? IdPedidoMarcacaoHistorico { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int IdVeiculo { get; set; }
        public List<object> Danos_Veiculo_Comprovativo { get; set; }
        public object Pedido_Marcacao_Historico { get; set; }
        public object Veiculo { get; set; }
    }

    public class WebDamageVehicleDocument
    {
        public int IdDanosVeiculoComprovativo { get; set; }
        public int IdDanosVeiculo { get; set; }
        public string Documento { get; set; }
        public string FormatoDocumento { get; set; }
        public string NomeDocumento { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }
        public object Danos_Veiculo { get; set; }
    }

    public class WebConfiguration
    {
        public int IdConfiguracao { get; set; }
        public string Parametro { get; set; }
        public string Descricao { get; set; }
    }

    public class WebProfile
    {
        public int IdPerfil { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public List<object> Perfil_Permissao { get; set; }
        public List<object> Utilizadors { get; set; }
    }

    public class WebPermission
    {
        public int IdPermissao { get; set; }
        public string Descricao { get; set; }
        public List<object> Perfil_Permissao { get; set; }
    }

    public class WebProfilePermission
    {
        public int IdPerfilPermissao { get; set; }
        public int IdPerfil { get; set; }
        public int IdPermissao { get; set; }
        public bool Ativo { get; set; }
        public object Perfil { get; set; }
        public object Permissao { get; set; }
    }

    public class WebUser
    {
        public int IdUtilizador { get; set; }
        public int IdPerfil { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public bool Ativo { get; set; }
        public List<object> Pedido_Marcacao { get; set; }
        public List<object> Pedido_Marcacao_Historico { get; set; }
        public object Perfil { get; set; }
        public List<object> Veiculoes { get; set; }
    }

    public class WebRequestJustificationType
    {
        public int IdTipoJustificacaoPedido { get; set; }
        public string Descricao { get; set; }
        public List<object> Justificacao_Pedido_Marcacao { get; set; }
    }

    public class WebRequestState
    {
        public int IdEstadoPedidoMarcacao { get; set; }
        public string Descricao { get; set; }
        public List<object> Pedido_Marcacao_Historico { get; set; }
    }

    public class WebRequest
    {
        public int IdPedidoMarcacao { get; set; }
        public int IdUtilizador { get; set; }
        public DateTime DataPedido { get; set; }
        public List<object> Justificacao_Pedido_Marcacao { get; set; }
        public List<object> Justificacao_Pedido_Marcacao1 { get; set; }
        public List<object> Pedido_Marcacao_Historico { get; set; }
        public object Utilizador { get; set; }
    }

    public class WebRequestJustification
    {
        public int IdJustificacaoPedidoMarcacao { get; set; }
        public int IdTipoJustificacaoPedido { get; set; }
        public int IdPedidoMarcacao { get; set; }
        public string Justificacao { get; set; }
        public int IdPedidoMarcacaoConflito { get; set; }
        public object Pedido_Marcacao { get; set; }
        public object Tipo_Justificacao_Pedido { get; set; }
        public object Pedido_Marcacao1 { get; set; }
    }

    public class WebRequestHistory
    {
    public int IdPedidoMarcacaoHistorico { get; set; }
    public int IdPedidoMarcacao { get; set; }
    public int IdEstadoPedidoMarcacao { get; set; }
    public int IdVeiculo { get; set; }
    public int IdUtilizador { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public List<object> Danos_Veiculo { get; set; }
    public object Estado_Pedido_Marcacao { get; set; }
    public object Pedido_Marcacao { get; set; }
    public object Utilizador { get; set; }
    public object Veiculo { get; set; }
    public List<object> Veiculo_Entrega { get; set; }
    }

    public class LoginJson
    {
        public string User { get; set; }

        public string Password { get; set; }
    }

}
