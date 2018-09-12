using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Gestao_Frotas_Desktop.NovoPedido;
using Gestao_Frotas_Desktop.LoginMenu;
using Gestao_Frotas_Desktop.Marcacoes;
using Gestao_Frotas_Desktop.Relatorios;

namespace Gestao_Frotas_Desktop
{
    public partial class FrmMenu : Form
    {

        int indextabela = -1;

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Justificacao_Pedido_Marcacao' table. You can move, or remove it, as needed.
            //this.justificacao_Pedido_MarcacaoTableAdapter.Fill(this.dataSet1.Justificacao_Pedido_Marcacao);
            // TODO: This line of code loads data into the 'dataSet1.Utilizador' table. You can move, or remove it, as needed.
            //this.utilizadorTableAdapter.Fill(this.dataSet1.Utilizador);
            // TODO: This line of code loads data into the 'dataSet1.Veiculo' table. You can move, or remove it, as needed.
            //this.veiculoTableAdapter.Fill(this.dataSet1.Veiculo);
            // TODO: This line of code loads data into the 'dataSet1.Pedido_Marcacao_Historico' table. You can move, or remove it, as needed.
            //this.pedido_Marcacao_HistoricoTableAdapter.Fill(this.dataSet1.Pedido_Marcacao_Historico);
            ReloadData();
        }

        private void ReloadData()
        {

            indextabela = -1;
            label2.Visible = true;
            this.Update();

            dgvpedidos.Rows.Clear();
            dgvpedidos.Enabled = false;

            var contagem = spListaPedidoMarcacoesTableAdapter.GetData(null).Count;
            var db = spListaPedidoMarcacoesTableAdapter.GetData(null);

            for (int i = 0; i < contagem; i++)
            {

                Bitmap a = new Bitmap(Properties.Resources.error);
                var b = 0;

                if (db.Rows[i][5].ToString() == "Pendente")
                {

                    a = Properties.Resources.pendente;
                    b = 0;
                    var idpedidomarcacaohistorico = db.Rows[i][0].ToString();
                    var Owner = db.Rows[i][1].ToString();
                    var Veiculo = db.Rows[i][2].ToString();
                    var datainicio = db.Rows[i][3].ToString();
                    var datafim = db.Rows[i][4].ToString();
                    dgvpedidos.Rows.Add(idpedidomarcacaohistorico, a, Veiculo, Owner, datainicio, datafim, b);

                }
                else if (db.Rows[i][5].ToString() == "Aprovado")
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
                    var idpedidomarcacaohistorico = db.Rows[i][0].ToString();
                    var Owner = db.Rows[i][1].ToString();
                    var Veiculo = db.Rows[i][2].ToString();
                    var datainicio = db.Rows[i][3].ToString();
                    var datafim = db.Rows[i][4].ToString();
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

            label2.Visible = false;
            this.Update();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.frm.Show();
        }

        private void utilizadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmutilizadores = new FrmUtilizadores();
            frmutilizadores.ShowDialog();
        }

        private void veículosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Global.optionVehicle = 0;
            var frmVeiculos = new frmVeiculos();
            frmVeiculos.ShowDialog();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.optionVehicle = 1;
            var frmVeiculos = new frmVeiculos();
            frmVeiculos.ShowDialog();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.optionVehicle = 2;
            var frmVeiculos = new frmVeiculos();
            frmVeiculos.ShowDialog();
        }

        private void tipologiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.optionVehicle = 3;
            var frmVeiculos = new frmVeiculos();
            frmVeiculos.ShowDialog();
        }

        private void novoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmNovoPedido = new FrmNovoPedido();
            frmNovoPedido.ShowDialog();
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

        private void dgvpedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void disponibilizarVeículoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void históricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.typesearch = 0;
            var frmMarcacoes = new FrmMarcacoes();
            frmMarcacoes.ShowDialog();
        }

        private void porAprovarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.typesearch = 1;
            var frmMarcacoes = new FrmMarcacoes();
            frmMarcacoes.ShowDialog();
        }

        private void porDisponíbilizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.typesearch = 2;
            var frmMarcacoes = new FrmMarcacoes();
            frmMarcacoes.ShowDialog();
        }

        private void emCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.typesearch = 3;
            var frmMarcacoes = new FrmMarcacoes();
            frmMarcacoes.ShowDialog();
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmRelatorio = new FrmRelatorio();
            frmRelatorio.ShowDialog();
        }
    }
}
