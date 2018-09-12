using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Frotas_Desktop
{
    public class Global
    {

        public static FrmLogin frm;

        public static User user;
        public static Brand brand;
        public static Model model;
        public static Typology typology;
        public static Vehicle vehicle;
        public static DamageVehicleDocument danoComprovativoEdit;
        public static DamageVehicle danoEdit;
        public static RequestHistory pedidomarcacaohistoricodamage;

        public static List<DamageVehicleDocument> danoComprovativo;
        public static List<DamageVehicle> dano;

        public static int optionVehicle;

        public static int NewOrEdit;
        public static int NewOrEditDeep;
        public static int DeepIndex;

        public static User userEdit;

        public static DateTime DataInicioMarcacao;
        public static DateTime DataFimMarcacao;

        public static VeiculoSelected VeiculoSelecionado;

        public static SobreposicaoPedido Sobreposicao;

        public static string Justification;

        public static int typesearch;

    }

    public class VeiculoSelected
    {
        public int idveiculo;

        public string Veiculo;

        public int Kmscontracto;

        public int Kmsiniciais;

        public string Matricula;

        public string Owner;

    }

    public class SobreposicaoPedido
    {
        public int idpedidomarcacaohistorico;

        public int idpedidomarcacao;

        public int idveiculo;

        public string veiculo;

        public DateTime datainicio;

        public DateTime datafim;

    }

}
