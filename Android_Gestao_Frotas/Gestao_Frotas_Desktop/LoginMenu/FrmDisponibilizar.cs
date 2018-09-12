using Gestao_Frotas_Desktop.Veiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop.LoginMenu
{
    public partial class FrmDisponibilizar : Form
    {

        int IndexDanos = -1;

        public FrmDisponibilizar()
        {
            InitializeComponent();
        }

        private void FrmDisponibilizar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Danos_Veiculo_Comprovativo' table. You can move, or remove it, as needed.
            //this.danos_Veiculo_ComprovativoTableAdapter.Fill(this.dataSet1.Danos_Veiculo_Comprovativo);
            // TODO: This line of code loads data into the 'dataSet1.Danos_Veiculo' table. You can move, or remove it, as needed.
            //this.danos_VeiculoTableAdapter.Fill(this.dataSet1.Danos_Veiculo);
            // TODO: This line of code loads data into the 'dataSet1.Veiculo_Entrega' table. You can move, or remove it, as needed.
            //this.veiculo_EntregaTableAdapter.Fill(this.dataSet1.Veiculo_Entrega);
            // TODO: This line of code loads data into the 'dataSet1.Pedido_Marcacao_Historico' table. You can move, or remove it, as needed.
            //this.pedido_Marcacao_HistoricoTableAdapter.Fill(this.dataSet1.Pedido_Marcacao_Historico);

            Global.dano = new List<Core_Gestao_Frotas.Business.Models.DamageVehicle>();
            Global.danoComprovativo = new List<Core_Gestao_Frotas.Business.Models.DamageVehicleDocument>();

        }

        private void Reloaddanos()
        {
            dgvdanos.Rows.Clear();
            dgvdanos.Enabled = false;
            for (int i = 0; i < Global.dano.Count; i++)
            {
                if (Global.danoComprovativo[i].Document != null)
                {
                    dgvdanos.Rows.Add(Global.dano[i].Id, Global.dano[i].Description, Properties.Resources.yesfoto);
                }
                else
                {
                    dgvdanos.Rows.Add(Global.dano[i].Id, Global.dano[i].Description, Properties.Resources.no_photo);
                }
            }

            for (int i = 0; i < dgvdanos.Columns.Count; i++)
                if (dgvdanos.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvdanos.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvdanos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvdanos.MultiSelect = false;
            dgvdanos.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.NewOrEditDeep = 0;
            var frmAddDanoVeiculo = new FrmAddDanoVeiculo();
            frmAddDanoVeiculo.ShowDialog();
            Reloaddanos();
            dgvdanos.ClearSelection();
            IndexDanos = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvdanos.Rows.Count > 0 && IndexDanos != -1)
            {
                Global.DeepIndex = IndexDanos;
                Global.NewOrEditDeep = 1;
                Global.danoEdit = Global.dano[IndexDanos];
                Global.danoComprovativoEdit = Global.danoComprovativo[IndexDanos];
                var frmAddDanoVeiculo = new FrmAddDanoVeiculo();
                frmAddDanoVeiculo.ShowDialog();
                Reloaddanos();
                dgvdanos.ClearSelection();
                IndexDanos = -1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvdanos.Rows.Count > 0 && IndexDanos != -1)
            {
                if (Global.NewOrEdit == 0)
                {
                    string desc = dgvdanos.Rows[dgvdanos.CurrentRow.Index].Cells[1].Value.ToString();
                    dgvdanos.ClearSelection();

                    DialogResult dialogResult = MessageBox.Show("Deseja remover o dano " + desc + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Global.dano.RemoveAt(IndexDanos);
                        Global.danoComprovativo.RemoveAt(IndexDanos);
                        Reloaddanos();
                        dgvdanos.ClearSelection();
                    }

                    IndexDanos = -1;
                }
            }
        }

        private void dgvdanos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IndexDanos = dgvdanos.CurrentCell.RowIndex;
        }

        private void bttconfirm_Click(object sender, EventArgs e)
        {
            bttconfirm.Enabled = false;
            bttconfirm.Text = "Comunicando...";
            this.Update();

            pedido_Marcacao_HistoricoTableAdapter.TerminaPedidoMarcacaoQuery(Global.pedidomarcacaohistoricodamage.Id);
            veiculo_EntregaTableAdapter.InsertQuery(Global.pedidomarcacaohistoricodamage.Id, DateTime.Now.ToString(), numericUpDown1.Value);

            if (Global.dano.Count > 0)
            {
                int idVeiculoAdded = Global.VeiculoSelecionado.idveiculo;

                for (int i = 0; i < Global.dano.Count; i++)
                {
                    danos_VeiculoTableAdapter.InsertQuery(null, DateTime.Now.ToString(), Global.dano[i].Description, true, idVeiculoAdded);
                    if (Global.danoComprovativo[i].Document != null)
                    {
                        int idDanoAdded = int.Parse(danos_VeiculoTableAdapter.GetDataByMaxId()[0][0].ToString());
                        danos_Veiculo_ComprovativoTableAdapter.InsertQuery(idDanoAdded, Global.danoComprovativo[i].Document, ".jpeg", Global.danoComprovativo[i].DocumentName, DateTime.Now.ToString(), true);
                    }
                }
            }

            MessageBox.Show("Veículo disponibilizado!", "Pedido Marcação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

    }
}
