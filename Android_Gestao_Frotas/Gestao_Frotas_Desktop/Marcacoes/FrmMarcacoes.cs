using Core_Gestao_Frotas.Business.Models;
using Gestao_Frotas_Desktop.LoginMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop.Marcacoes
{
    public partial class FrmMarcacoes : Form
    {

        int indextabela = -1;
        List<int> listidsusers = new List<int>();
        List<int> listidvehicles = new List<int>();


        public FrmMarcacoes()
        {
            InitializeComponent();
        }

        private void FrmMarcacoes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Justificacao_Pedido_Marcacao' table. You can move, or remove it, as needed.
            //this.justificacao_Pedido_MarcacaoTableAdapter.Fill(this.dataSet1.Justificacao_Pedido_Marcacao);
            // TODO: This line of code loads data into the 'dataSet1.Pedido_Marcacao_Historico' table. You can move, or remove it, as needed.
            //this.pedido_Marcacao_HistoricoTableAdapter.Fill(this.dataSet1.Pedido_Marcacao_Historico);
            // TODO: This line of code loads data into the 'dataSet1.Pedido_Marcacao_Historico' table. You can move, or remove it, as needed.
            //this.pedido_Marcacao_HistoricoTableAdapter.Fill(this.dataSet1.Pedido_Marcacao_Historico);
            // TODO: This line of code loads data into the 'dataSet1.spListaVeiculos' table. You can move, or remove it, as needed.
            //this.spListaVeiculosTableAdapter.Fill(this.dataSet1.spListaVeiculos);
            // TODO: This line of code loads data into the 'dataSet1.spListaVeiculoDescricao' table. You can move, or remove it, as needed.
            //this.spListaVeiculoDescricaoTableAdapter.Fill(this.dataSet1.spListaVeiculoDescricao);
            // TODO: This line of code loads data into the 'dataSet1.Veiculo' table. You can move, or remove it, as needed.
            //this.veiculoTableAdapter.Fill(this.dataSet1.Veiculo);
            // TODO: This line of code loads data into the 'dataSet1.Utilizador' table. You can move, or remove it, as needed.
            //this.utilizadorTableAdapter.Fill(this.dataSet1.Utilizador);
            //dtpinicio.Value = dtpinicio.MinDate;
            //dtpfim.Value = dtpfim.MaxDate;

            var utilizadores = utilizadorTableAdapter.GetData();
            var veiculos = spListaVeiculoDescricaoTableAdapter.GetData();

            cbutilizador.Items.Add("Todos");
            listidsusers.Add(-1);
            for (int i = 0; i < utilizadores.Count; i++)
            {
                listidsusers.Add(Convert.ToInt32(utilizadores.Rows[i][0].ToString()));
                cbutilizador.Items.Add(utilizadores.Rows[i][2].ToString() + " (" + utilizadores.Rows[i][3].ToString() + ")");
            }
            cbutilizador.SelectedIndex = 0;

            cbveiculo.Items.Add("Todos");
            cbveiculo.Items.Add("Empresa");
            listidvehicles.Add(-1);
            listidvehicles.Add(-1);
            for (int i = 0; i < veiculos.Count; i++)
            {
                listidvehicles.Add(Convert.ToInt32(veiculos.Rows[i][0].ToString()));
                cbveiculo.Items.Add(veiculos.Rows[i][1].ToString());
            }
            cbveiculo.SelectedIndex = 0;

            if (Global.typesearch == 0)
            {
                cbestado.SelectedIndex = 0;
            }else if (Global.typesearch == 1)
            {
                cbestado.SelectedIndex = 3;
            }
            else if (Global.typesearch == 2)
            {
                cbestado.SelectedIndex = 2;
            }
            else if (Global.typesearch == 3)
            {
                cbestado.SelectedIndex = 1;
            }

            ReloadData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gbdatas.Visible = checkBox1.Checked;
        }

        private void ReloadData()
        {

            indextabela = -1;
            label7.Visible = true;
            this.Update();

            //requestHistories.Clear();
            dgvpedidos.Rows.Clear();
            dgvpedidos.Enabled = false;

            var db = spListaPedidoMarcacoesExtraTableAdapter.GetData(null);
            List<VeiculoSearch> veiculos = new List<VeiculoSearch>();

            for (int i = 0; i < db.Count; i++)
            {
                veiculos.Add(new VeiculoSearch
                {
                    idpedidomarcacaohistorico = Convert.ToInt32(db.Rows[i][0].ToString()),
                    owner = db.Rows[i][1].ToString(),
                    veiculo = db.Rows[i][2].ToString(),
                    datainicio = DateTime.Parse(db.Rows[i][3].ToString()),
                    datafim = DateTime.Parse(db.Rows[i][4].ToString()),
                    estadopedido = db.Rows[i][5].ToString(),
                    idutilizador = Convert.ToInt32(db.Rows[i][6].ToString()),
                    idveiculo = Convert.ToInt32(db.Rows[i][7].ToString()),
                    ownerveiculo = db.Rows[i][8].ToString()
                });
            }

            if (cbutilizador.SelectedIndex != 0)
            {
                veiculos = veiculos.Where(v => v.idutilizador == listidsusers[cbutilizador.SelectedIndex]).ToList();
            }

            if (cbveiculo.SelectedIndex != 0)
            {
                if (cbveiculo.SelectedIndex == 1)
                {
                    veiculos = veiculos.Where(v => v.ownerveiculo == "").ToList();
                }else if (cbveiculo.SelectedIndex > 1)
                {
                    veiculos = veiculos.Where(v => v.idveiculo == listidvehicles[cbveiculo.SelectedIndex]).ToList();
                }
            }

            if (checkBox1.Checked == true)
            {
                veiculos = veiculos.Where(v => v.datainicio >= dtpinicio.Value).ToList();
                veiculos = veiculos.Where(v => v.datafim <= dtpfim.Value).ToList();
            }

            if (cbestado.SelectedIndex != 0)
            {
                if (cbestado.SelectedIndex == 1)
                {
                    veiculos = veiculos.Where(v => v.estadopedido == "Aprovado").ToList();
                }else if (cbestado.SelectedIndex == 2)
                {
                    veiculos = veiculos.Where(v => v.estadopedido == "Aprovado").ToList();
                    veiculos = veiculos.Where(v => v.datafim <= DateTime.Now).ToList();
                }
                else if (cbestado.SelectedIndex == 3)
                {
                    veiculos = veiculos.Where(v => v.estadopedido == "Pendente").ToList();
                }
                else if (cbestado.SelectedIndex == 4)
                {
                    veiculos = veiculos.Where(v => v.estadopedido == "Cancelado").ToList();
                }
                else if (cbestado.SelectedIndex == 5)
                {
                    veiculos = veiculos.Where(v => v.estadopedido == "Terminado").ToList();
                }
            }

            for (int i = 0; i < veiculos.Count; i++)
            {

                Bitmap a = new Bitmap(Properties.Resources.error);
                var b = 0;

                if (veiculos[i].estadopedido == "Pendente")
                {

                    a = Properties.Resources.pendente;
                    b = 0;
                    var idpedidomarcacaohistorico = veiculos[i].idpedidomarcacaohistorico;
                    var Owner = veiculos[i].owner;
                    var Veiculo = veiculos[i].veiculo;
                    var datainicio = veiculos[i].datainicio;
                    var datafim = veiculos[i].datafim;
                    dgvpedidos.Rows.Add(idpedidomarcacaohistorico, a, Veiculo, Owner, datainicio, datafim, b);

                }
                else if (veiculos[i].estadopedido == "Aprovado")
                {
                    var data = DateTime.Parse(spListaPedidoMarcacoesTableAdapter.GetData(null).Rows[i][4].ToString());
                    if (data <= DateTime.Now)
                    {
                        a = Properties.Resources.entrega;
                        b = 1;
                    }
                    else
                    {
                        a = Properties.Resources.curso;
                        b = 2;
                    }
                    var idpedidomarcacaohistorico = veiculos[i].idpedidomarcacaohistorico;
                    var Owner = veiculos[i].owner;
                    var Veiculo = veiculos[i].veiculo;
                    var datainicio = veiculos[i].datainicio;
                    var datafim = veiculos[i].datafim;
                    dgvpedidos.Rows.Add(idpedidomarcacaohistorico, a, Veiculo, Owner, datainicio, datafim, b);
                }else if (veiculos[i].estadopedido == "Cancelado")
                {
                    a = Properties.Resources.cancel;
                    b = 3;
                    var idpedidomarcacaohistorico = veiculos[i].idpedidomarcacaohistorico;
                    var Owner = veiculos[i].owner;
                    var Veiculo = veiculos[i].veiculo;
                    var datainicio = veiculos[i].datainicio;
                    var datafim = veiculos[i].datafim;
                    dgvpedidos.Rows.Add(idpedidomarcacaohistorico, a, Veiculo, Owner, datainicio, datafim, b);
                }else if (veiculos[i].estadopedido == "Terminado")
                {
                    a = Properties.Resources.calendar_check;
                    b = 4;
                    var idpedidomarcacaohistorico = veiculos[i].idpedidomarcacaohistorico;
                    var Owner = veiculos[i].owner;
                    var Veiculo = veiculos[i].veiculo;
                    var datainicio = veiculos[i].datainicio;
                    var datafim = veiculos[i].datafim;
                    dgvpedidos.Rows.Add(idpedidomarcacaohistorico, a, Veiculo, Owner, datainicio, datafim, b);
                }
            }

            for (int i = 0; i < dgvpedidos.Columns.Count; i++)
                if (dgvpedidos.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvpedidos.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvpedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpedidos.MultiSelect = false;
            dgvpedidos.Enabled = true;
            dgvpedidos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            label7.Visible = false;
            this.Update();

        }

        private void bttclean_Click(object sender, EventArgs e)
        {
            cbutilizador.SelectedIndex = 0;
            cbveiculo.SelectedIndex = 0;
            cbestado.SelectedIndex = 0;
            checkBox1.Checked = false;
            ReloadData();
        }

        private void dgvpedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indextabela = dgvpedidos.CurrentCell.RowIndex;
            if (indextabela != -1)
            {
                var type = Convert.ToInt32(dgvpedidos.Rows[indextabela].Cells[6].Value.ToString());
                if (type == 0)
                {
                    contextMenuStrip1.Items[0].Visible = true;
                    contextMenuStrip1.Items[1].Visible = true;
                    contextMenuStrip1.Items[2].Visible = false;
                    contextMenuStrip1.Items[3].Visible = false;
                }
                else if (type == 1)
                {
                    contextMenuStrip1.Items[0].Visible = false;
                    contextMenuStrip1.Items[1].Visible = false;
                    contextMenuStrip1.Items[2].Visible = false;
                    contextMenuStrip1.Items[3].Visible = true;
                }
                else if (type == 2)
                {
                    contextMenuStrip1.Items[0].Visible = false;
                    contextMenuStrip1.Items[1].Visible = false;
                    contextMenuStrip1.Items[2].Visible = true;
                    contextMenuStrip1.Items[3].Visible = false;
                }else if (type == 3)
                {
                    contextMenuStrip1.Items[0].Visible = false;
                    contextMenuStrip1.Items[1].Visible = false;
                    contextMenuStrip1.Items[2].Visible = false;
                    contextMenuStrip1.Items[3].Visible = false;
                }
                else if (type == 4)
                {
                    contextMenuStrip1.Items[0].Visible = false;
                    contextMenuStrip1.Items[1].Visible = false;
                    contextMenuStrip1.Items[2].Visible = false;
                    contextMenuStrip1.Items[3].Visible = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        public class VeiculoSearch
        {
            public int idpedidomarcacaohistorico;

            public string owner;

            public string veiculo;

            public DateTime datainicio;

            public DateTime datafim;

            public string estadopedido;

            public int idutilizador;

            public int idveiculo;

            public string ownerveiculo;

        }

        private void disponibilizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (indextabela != -1)
            {
                var ownertarget = dgvpedidos.Rows[indextabela].Cells[3].Value.ToString();
                var veiculotarget = dgvpedidos.Rows[indextabela].Cells[2].Value.ToString();
                var idpedidomarcacaohistoricotarget = Convert.ToInt32(dgvpedidos.Rows[indextabela].Cells[0].Value.ToString());

                //Disponibiliza pedido
                DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende actualizar o pedido de marcação de " + ownertarget + " para o veículo " + veiculotarget + "?", "Aprovar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    var pedidomarcacaohistoricotarget = pedido_Marcacao_HistoricoTableAdapter.GetDataById(idpedidomarcacaohistoricotarget);
                    //var idpedidomarcacaoget = Convert.ToInt32(pedidomarcacaohistoricotarget.Rows[0][1].ToString());

                    Global.VeiculoSelecionado = new VeiculoSelected();
                    Global.VeiculoSelecionado.idveiculo = Convert.ToInt32(pedidomarcacaohistoricotarget.Rows[0][3].ToString());
                    Global.VeiculoSelecionado.Veiculo = veiculotarget;

                    Global.pedidomarcacaohistoricodamage = new Core_Gestao_Frotas.Business.Models.RequestHistory
                    {
                        Id = Convert.ToInt32(pedidomarcacaohistoricotarget.Rows[0][0].ToString()),
                        Request = new Core_Gestao_Frotas.Business.Models.Request
                        {
                            Id = Convert.ToInt32(pedidomarcacaohistoricotarget.Rows[0][1].ToString()),
                            IsIncomplete = true
                        },
                        RequestState = new Core_Gestao_Frotas.Business.Models.RequestState
                        {
                            Id = Convert.ToInt32(pedidomarcacaohistoricotarget.Rows[0][2].ToString()),
                            IsIncomplete = true
                        },
                        Vehicle = new Core_Gestao_Frotas.Business.Models.Vehicle
                        {
                            Id = Convert.ToInt32(pedidomarcacaohistoricotarget.Rows[0][3].ToString()),
                            IsIncomplete = true
                        },
                        User = new Core_Gestao_Frotas.Business.Models.User
                        {
                            Id = Convert.ToInt32(pedidomarcacaohistoricotarget.Rows[0][4].ToString()),
                            IsIncomplete = true
                        },
                        Active = (bool)(pedidomarcacaohistoricotarget.Rows[0][5].ToString() == "1" ? true : false),
                        StartDate = DateTime.Parse(pedidomarcacaohistoricotarget.Rows[0][6].ToString()),
                        EndDate = DateTime.Parse(pedidomarcacaohistoricotarget.Rows[0][7].ToString()),
                        IsIncomplete = false
                    };

                    var frmDisponibilizar = new FrmDisponibilizar();
                    frmDisponibilizar.ShowDialog();

                    //pedido_Marcacao_HistoricoTableAdapter.CancelaPedidoMarcacaoQuery(idpedidomarcacaohistoricotarget);
                    //justificacao_Pedido_MarcacaoTableAdapter.InsertTerminaPedidoAddQuery(idpedidomarcacaoget, Global.Justification, idpedidomarcacaoget);

                    //MessageBox.Show("Pedido Terminado!", "Pedido Marcação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadData();
                }
            }
        }

        private void aprovarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (indextabela != -1)
            {
                var ownertarget = dgvpedidos.Rows[indextabela].Cells[3].Value.ToString();
                var veiculotarget = dgvpedidos.Rows[indextabela].Cells[2].Value.ToString();
                var idpedidomarcacaohistoricotarget = Convert.ToInt32(dgvpedidos.Rows[indextabela].Cells[0].Value.ToString());

                //Aprovar pedido
                DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende aprovar o pedido de marcação de " + ownertarget + " para o veículo " + veiculotarget + "?", "Aprovar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    pedido_Marcacao_HistoricoTableAdapter.spAprovaPedidoMarcacao(idpedidomarcacaohistoricotarget);
                    MessageBox.Show("Pedido Aprovado!", "Pedido Marcação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadData();
                }
            }
        }

        private void cancelarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (indextabela != -1)
            {
                var ownertarget = dgvpedidos.Rows[indextabela].Cells[3].Value.ToString();
                var veiculotarget = dgvpedidos.Rows[indextabela].Cells[2].Value.ToString();
                var idpedidomarcacaohistoricotarget = Convert.ToInt32(dgvpedidos.Rows[indextabela].Cells[0].Value.ToString());

                //Cancelar Pedido pedido
                DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende Cancelar o pedido de marcação de " + ownertarget + " para o veículo " + veiculotarget + "?", "Aprovar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {

                    pedido_Marcacao_HistoricoTableAdapter.CancelaPedidoMarcacaoQuery(idpedidomarcacaohistoricotarget);

                    MessageBox.Show("Pedido Cancelado!", "Pedido Marcação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadData();
                }
            }
        }

        private void terminarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (indextabela != -1)
            {
                var ownertarget = dgvpedidos.Rows[indextabela].Cells[3].Value.ToString();
                var veiculotarget = dgvpedidos.Rows[indextabela].Cells[2].Value.ToString();
                var idpedidomarcacaohistoricotarget = Convert.ToInt32(dgvpedidos.Rows[indextabela].Cells[0].Value.ToString());

                //Terminar pedido
                DialogResult dialogResult = MessageBox.Show("Tem a certeza que pretende terminar o pedido de marcação de " + ownertarget + " para o veículo " + veiculotarget + "?", "Aprovar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    var pedidomarcacaohistoricotarget = pedido_Marcacao_HistoricoTableAdapter.GetDataById(idpedidomarcacaohistoricotarget);
                    var idpedidomarcacaoget = Convert.ToInt32(pedidomarcacaohistoricotarget.Rows[0][1].ToString());

                    Global.VeiculoSelecionado = new VeiculoSelected();
                    Global.VeiculoSelecionado.Veiculo = veiculotarget;

                    var frmJustificacao = new FrmJustificacao();
                    frmJustificacao.ShowDialog();

                    pedido_Marcacao_HistoricoTableAdapter.CancelaPedidoMarcacaoQuery(idpedidomarcacaohistoricotarget);
                    justificacao_Pedido_MarcacaoTableAdapter.InsertTerminaPedidoAddQuery(idpedidomarcacaoget, Global.Justification, idpedidomarcacaoget);

                    MessageBox.Show("Pedido Terminado!", "Pedido Marcação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadData();
                }
            }
        }
    }
}
