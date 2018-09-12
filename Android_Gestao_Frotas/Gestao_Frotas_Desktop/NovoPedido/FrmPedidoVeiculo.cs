using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop.NovoPedido
{
    public partial class FrmPedidoVeiculo : Form
    {

        int indextable = -1;
        int indexVeiculos = -1;

        public FrmPedidoVeiculo()
        {
            InitializeComponent();
        }

        private void FrmPedidoVeiculo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Veiculo' table. You can move, or remove it, as needed.
            //this.veiculoTableAdapter.Fill(this.dataSet1.Veiculo);
            // TODO: This line of code loads data into the 'dataSet1.Pedido_Marcacao_Historico' table. You can move, or remove it, as needed.
            //this.pedido_Marcacao_HistoricoTableAdapter.Fill(this.dataSet1.Pedido_Marcacao_Historico);
            var dados = pedido_Marcacao_HistoricoTableAdapter.GetDataByBusy(Global.DataInicioMarcacao.ToString(), Global.DataFimMarcacao.ToString());
            var todosveiculos = veiculoTableAdapter.GetDataBySemiDisponivel();

            for (int i = 0; i < todosveiculos.Count; i++)
            {
                var idveiculo = todosveiculos.Rows[i][0].ToString();

                var isOccupied = dados.Any(request => request.IdVeiculo.ToString() == idveiculo);
                if (!isOccupied)
                {
                    var vehicleget = spDetalheVeiculoTableAdapter.GetData(Convert.ToInt32(idveiculo));

                    var veiculo = vehicleget.Rows[0][1].ToString() + " - " + vehicleget.Rows[0][5].ToString() + " - " + vehicleget.Rows[0][7].ToString();
                    var matricula = vehicleget.Rows[0][12].ToString();
                    var owner = vehicleget.Rows[0][11].ToString();
                    var combustivel = vehicleget.Rows[0][9].ToString();
                    var estado = Convert.ToBoolean(vehicleget.Rows[0][15]);

                    var kmscontracto = vehicleget.Rows[0][14].ToString();
                    var kmsiniciais = vehicleget.Rows[0][13].ToString();

                    if (estado == true)
                    {
                        dgveiculos.Rows.Add(idveiculo, Properties.Resources.car_test, veiculo, matricula, owner, combustivel, "Ativo", kmscontracto, kmsiniciais);
                    }
                    else
                    {
                        dgveiculos.Rows.Add(idveiculo, Properties.Resources.car_test, veiculo, matricula, owner, combustivel, "Inativo", kmscontracto, kmsiniciais);
                    }

                }

                for (int o = 0; o < dgveiculos.Columns.Count; o++)
                    if (dgveiculos.Columns[o] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dgveiculos.Columns[o]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        break;
                    }

                dgveiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgveiculos.MultiSelect = false;
                dgveiculos.Enabled = true;

                ChangeColorStateVeiculos();

            }


        }

        private void ChangeColorStateVeiculos()
        {
            for (int i = 0; i < dgveiculos.Rows.Count; i++)
            {
                if (dgveiculos.Rows[i].Cells[6].Value.ToString() == "Ativo")
                {
                    dgveiculos.Rows[i].Cells[6].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
                }
                else
                {
                    dgveiculos.Rows[i].Cells[6].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed };
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgveiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgveiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexVeiculos = Convert.ToInt32(dgveiculos.Rows[dgveiculos.CurrentRow.Index].Cells[0].Value.ToString());
            indextable = dgveiculos.CurrentCell.RowIndex;
            ShowDetails();
        }

        private void ShowDetails()
        {
            if (indextable != -1)
            {
                groupBox1.Visible = true;
                txtdetalheveiculo.Text = dgveiculos.Rows[indextable].Cells[2].Value.ToString();
                txtdetalhecontracto.Text = "Kms Contrato: " + dgveiculos.Rows[indextable].Cells[7].Value.ToString();
                txtdetalheiniciais.Text = "Kms Iniciais: " + dgveiculos.Rows[indextable].Cells[8].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (indextable != -1)
            {
                Global.VeiculoSelecionado = new VeiculoSelected();
                Global.VeiculoSelecionado.idveiculo = Convert.ToInt32(dgveiculos.Rows[indextable].Cells[0].Value.ToString());
                Global.VeiculoSelecionado.Veiculo = dgveiculos.Rows[indextable].Cells[2].Value.ToString();
                Global.VeiculoSelecionado.Kmscontracto = Convert.ToInt32(dgveiculos.Rows[indextable].Cells[7].Value.ToString());
                Global.VeiculoSelecionado.Kmsiniciais = Convert.ToInt32(dgveiculos.Rows[indextable].Cells[8].Value.ToString());
                Global.VeiculoSelecionado.Matricula = dgveiculos.Rows[indextable].Cells[3].Value.ToString();
                Global.VeiculoSelecionado.Owner = dgveiculos.Rows[indextable].Cells[4].Value.ToString();
                this.Close();
            }
        }
    }
}
