using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop.NovoPedido
{
    public partial class FrmNovoPedido : Form
    {

        DateTime DataInicio;
        DateTime DataFim;

        public FrmNovoPedido()
        {
            InitializeComponent();

        }

        private void FrmNovoPedido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Justificacao_Pedido_Marcacao' table. You can move, or remove it, as needed.
            //this.justificacao_Pedido_MarcacaoTableAdapter.Fill(this.dataSet1.Justificacao_Pedido_Marcacao);
            // TODO: This line of code loads data into the 'dataSet1.Pedido_Marcacao' table. You can move, or remove it, as needed.
            //this.pedido_MarcacaoTableAdapter.Fill(this.dataSet1.Pedido_Marcacao);
            // TODO: This line of code loads data into the 'dataSet1.Pedido_Marcacao_Historico' table. You can move, or remove it, as needed.
            //this.pedido_Marcacao_HistoricoTableAdapter.Fill(this.dataSet1.Pedido_Marcacao_Historico);
            // TODO: This line of code loads data into the 'dataSet1.Pedido_Marcacao_Historico' table. You can move, or remove it, as needed.
            //this.pedido_Marcacao_HistoricoTableAdapter.Fill(this.dataSet1.Pedido_Marcacao_Historico);
            Global.VeiculoSelecionado = null;
            dtpDataFim.Value = DateTime.Now.AddDays(1);
            CheckClock();
            //MessageBox.Show(DataInicio.ToString());
        }

        private void CheckClock()
        {
            if (cbstate.Checked == false)
            {
                DataInicio = dtpDataInicio.Value.Date + dtpHoraInicio.Value.TimeOfDay;
                DataFim = dtpDataFim.Value.Date + dtpHoraFim.Value.TimeOfDay;

                if (DataFim > DataInicio)
                {
                    bttVehicle.Enabled = true;
                }
                else
                {
                    bttVehicle.Enabled = false;
                }

                BttAdd.Enabled = false;
            }
            else
            {
                DataInicio = dtpDataInicio.Value.Date + dtpHoraInicio.Value.TimeOfDay;
                if (DataInicio > DateTime.Now)
                {
                    bttVehicle.Enabled = true;
                }
                else
                {
                    bttVehicle.Enabled = false;
                }

                BttAdd.Enabled = false;
            }

        }

        private void dtpDataInicio_ValueChanged(object sender, EventArgs e)
        {
            CheckClock();
            Global.VeiculoSelecionado = null;
            Changefacts();
        }

        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            CheckClock();
            Global.VeiculoSelecionado = null;
            Changefacts();
        }

        private void dtpDataFim_ValueChanged(object sender, EventArgs e)
        {
            CheckClock();
            Global.VeiculoSelecionado = null;
            Changefacts();
        }

        private void dtpHoraFim_ValueChanged(object sender, EventArgs e)
        {
            CheckClock();
            Global.VeiculoSelecionado = null;
            Changefacts();
        }

        private void cbstate_CheckedChanged(object sender, EventArgs e)
        {
            gbFim.Visible = (!cbstate.Checked);
            CheckClock();
            Global.VeiculoSelecionado = null;
            Changefacts();
        }

        private void bttVehicle_Click(object sender, EventArgs e)
        {
            Global.VeiculoSelecionado = null;

            if (bttVehicle.Enabled == true)
            {
                bttVehicle.Text = "Carregando...";
                bttVehicle.Enabled = false;

                if (cbstate.Checked == true)
                {
                    Global.DataInicioMarcacao = DataInicio;
                    Global.DataFimMarcacao = DateTime.MaxValue;
                }
                else if (cbstate.Checked == false)
                {
                    Global.DataInicioMarcacao = DataInicio;
                    Global.DataFimMarcacao = DataFim;
                }

                var frmNovoPedidoVeiculo = new FrmPedidoVeiculo();
                frmNovoPedidoVeiculo.ShowDialog();

                bttVehicle.Text = "Escolher Veículo";
                bttVehicle.Enabled = true;

                Changefacts();
            }
        }

        private void Changefacts()
        {
            if (Global.VeiculoSelecionado != null)
            {
                pbprivateimage.Visible = true;
                labelprivateveiculo.Visible = true;
                labelprivateowner.Visible = true;
                labelkmsprivate.Visible = true;
                bttVehicle.Visible = false;
                labelprivateveiculo.Text = Global.VeiculoSelecionado.Veiculo;
                labelprivateowner.Text = "Owner: " + Global.VeiculoSelecionado.Owner;
                labelkmsprivate.Text = "Kms Contracto: " + Global.VeiculoSelecionado.Kmscontracto.ToString() + " Kms Iniciais: " + Global.VeiculoSelecionado.Kmsiniciais + "\nMatricula: " + Global.VeiculoSelecionado.Matricula;
                BttAdd.Enabled = true;
            }
            else
            {
                pbprivateimage.Visible = false;
                labelprivateveiculo.Visible = false;
                labelprivateowner.Visible = false;
                labelkmsprivate.Visible = false;
                bttVehicle.Visible = true;
                BttAdd.Enabled = false;
            }
        }

        private void BttAdd_ClickAsync(object sender, EventArgs e)
        {
            SendrequestAsync();
        }

        private async void SendrequestAsync()
        {
            if (BttAdd.Enabled == true && Global.VeiculoSelecionado != null)
            {
                BttAdd.Text = "Comunicando...";
                BttAdd.Enabled = false;

                HttpClient client = new HttpClient();
                var values = new Dictionary<string, string>
                {
                   { "idutilizador", Global.user.Id.ToString() },
                   { "datainicio", DataInicio.ToString("yyyy-MM-dd HH:mm:ss.fff") },
                   { "datafim", DataFim.ToString("yyyy-MM-dd HH:mm:ss.fff") }
                };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://213.32.71.49/frota/example/existesobreposicao", content);
                var responseString = await response.Content.ReadAsStringAsync();

                if (responseString == "ok")
                {

                    pedido_MarcacaoTableAdapter.InsertQuery(Global.user.Id, DateTime.Now.ToString());
                    var latestpedido = pedido_MarcacaoTableAdapter.GetDataByHigher();
                    var idpedidomarcacao2 = Convert.ToInt32(latestpedido.Rows[0][0].ToString());
                    pedido_Marcacao_HistoricoTableAdapter.InsertQuery(idpedidomarcacao2, Global.VeiculoSelecionado.idveiculo, Global.user.Id, DataInicio.ToString(),DataFim.ToString());
                    MessageBox.Show("Pedido Marcação Realizado!", "Pedido Marcação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {

                    var a = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RootObject>>(responseString);
                    Global.Sobreposicao = new SobreposicaoPedido();
                    Global.Sobreposicao.idpedidomarcacaohistorico = Convert.ToInt32(a[0].IdPedidoMarcacaoHistorico);
                    Global.Sobreposicao.idpedidomarcacao = Convert.ToInt32(a[0].IdPedidoMarcacao);
                    Global.Sobreposicao.idveiculo = Convert.ToInt32(a[0].IdVeiculo);
                    var detalheveiculo = spDetalheVeiculoTableAdapter.GetData(Global.Sobreposicao.idveiculo);
                    Global.Sobreposicao.veiculo = detalheveiculo.Rows[0][3].ToString() + " - " + detalheveiculo.Rows[0][5].ToString() + " - " + detalheveiculo.Rows[0][7].ToString() + " - "  + detalheveiculo.Rows[0][12].ToString();

                    Global.Sobreposicao.datainicio = DateTime.Parse(a[0].DataInicio);
                    Global.Sobreposicao.datafim = DateTime.Parse(a[0].DataFim);

                    var frmSobreposicao = new FrmSobreposicao();
                    frmSobreposicao.ShowDialog();

                    if (Global.Justification != "")
                    {
                        pedido_MarcacaoTableAdapter.InsertQuery(Global.user.Id, DateTime.Now.ToString());
                        var latestpedido = pedido_MarcacaoTableAdapter.GetDataByHigher();
                        var idpedidomarcacao = Convert.ToInt32(latestpedido.Rows[0][0].ToString());
                        justificacao_Pedido_MarcacaoTableAdapter.InsertAddQuery(idpedidomarcacao, Global.Justification, Global.Sobreposicao.idpedidomarcacao);
                        pedido_Marcacao_HistoricoTableAdapter.InsertQuery(idpedidomarcacao, Global.VeiculoSelecionado.idveiculo, Global.user.Id, DataInicio.ToString(), DataFim.ToString());
                        MessageBox.Show("Pedido Marcação Realizado!", "Pedido Marcação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
                BttAdd.Text = "Realizar Pedido...";
                BttAdd.Enabled = true;
            }
        }

        public class RootObject
        {
            public string IdPedidoMarcacaoHistorico { get; set; }
            public string IdPedidoMarcacao { get; set; }
            public string IdEstadoPedidoMarcacao { get; set; }
            public string IdVeiculo { get; set; }
            public string IdUtilizador { get; set; }
            public string Ativo { get; set; }
            public string DataInicio { get; set; }
            public string DataFim { get; set; }
        }

    }
}
