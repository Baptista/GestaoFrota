using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop.Relatorios
{
    public partial class FrmRelatorio : Form
    {

        List<int> idusers = new List<int>();
        List<int> idvehicles = new List<int>();
        int indextable1 = -1;
        int indextable2 = -1;

        public FrmRelatorio()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox1.Checked;
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.spListaVeiculoDescricao' table. You can move, or remove it, as needed.
            //this.spListaVeiculoDescricaoTableAdapter.Fill(this.dataSet1.spListaVeiculoDescricao);
            // TODO: This line of code loads data into the 'dataSet1.Veiculo' table. You can move, or remove it, as needed.
            //this.veiculoTableAdapter.Fill(this.dataSet1.Veiculo);
            // TODO: This line of code loads data into the 'dataSet1.Utilizador' table. You can move, or remove it, as needed.
            //this.utilizadorTableAdapter.Fill(this.dataSet1.Utilizador);

            var users = utilizadorTableAdapter.GetData();
            var veiculos = spListaVeiculoDescricaoTableAdapter.GetData();

            for (int i = 0; i < users.Count; i++)
            {
                idusers.Add(Convert.ToInt32(users.Rows[i][0].ToString()));
                cbUsersReport.Items.Add(users.Rows[i][3].ToString() + " (" + users.Rows[i][2].ToString() + ")");
            }

            for (int i = 0; i < veiculos.Count; i++)
            {
               idvehicles.Add(Convert.ToInt32(veiculos.Rows[i][0].ToString()));
                CbVehiclesReports.Items.Add(veiculos.Rows[i][1].ToString());
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvutilizadoresreport.Rows.Add(idusers[cbUsersReport.SelectedIndex], cbUsersReport.SelectedItem);
            int valortarget = cbUsersReport.SelectedIndex;
            cbUsersReport.Items.RemoveAt(valortarget);
            idusers.RemoveAt(valortarget);
            CheckCheckBoxes();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgveiculosreport.Rows.Add(idvehicles[CbVehiclesReports.SelectedIndex], CbVehiclesReports.SelectedItem);
            int valortarget = CbVehiclesReports.SelectedIndex;
            CbVehiclesReports.Items.RemoveAt(valortarget);
            idvehicles.RemoveAt(valortarget);
            CheckCheckBoxes();
        }

        private void CheckCheckBoxes()
        {
            if (cbUsersReport.Items.Count == 0)
            {
                cbUsersReport.Enabled = false;
            }
            else
            {
                cbUsersReport.Enabled = true;
            }

            if (CbVehiclesReports.Items.Count == 0)
            {
                CbVehiclesReports.Enabled = false;
            }
            else
            {
                CbVehiclesReports.Enabled = true;
            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (indextable1 != -1 && dgvutilizadoresreport.Rows.Count > 0)
            {
                idusers.Add(Convert.ToInt32(dgvutilizadoresreport.Rows[indextable1].Cells[0].Value.ToString()));
                cbUsersReport.Items.Add(dgvutilizadoresreport.Rows[indextable1].Cells[1].Value.ToString());
                dgvutilizadoresreport.Rows.RemoveAt(indextable1);
                dgvutilizadoresreport.ClearSelection();
            }
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (indextable2 != -1 && dgveiculosreport.Rows.Count > 0)
            {
                idvehicles.Add(Convert.ToInt32(dgveiculosreport.Rows[indextable2].Cells[0].Value.ToString()));
                CbVehiclesReports.Items.Add(dgveiculosreport.Rows[indextable2].Cells[1].Value.ToString());
                dgveiculosreport.Rows.RemoveAt(indextable2);
                dgveiculosreport.ClearSelection();
            }
        }

        private void dgvutilizadoresreport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indextable1 = dgvutilizadoresreport.CurrentCell.RowIndex;
        }

        private void dgveiculosreport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indextable2 = dgveiculosreport.CurrentCell.RowIndex;
        }

        private void dgvutilizadoresreport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgveiculosreport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = "";

            if (checkBox1.Checked == true)
            {
                texto = "Têm a certeza que pretende gerar relatórios da actividade de " + dateTimePicker1.Value.ToShortDateString() + " até " + dateTimePicker2.Value.ToShortDateString() + " para os utilizadores:\n";
            }
            else
            {
                texto = "Têm a certeza que pretende gerar relatórios da actividade de --/--/---- até --/--/---- para os utilizadores:\n";
            }

            for (int i = 0; i < dgvutilizadoresreport.Rows.Count; i++)
            {
                texto = texto + dgvutilizadoresreport.Rows[i].Cells[1].Value.ToString() + "\n";
            }

            texto = texto + "E para os veículos:\n";

            for (int i = 0; i < dgveiculosreport.Rows.Count; i++)
            {
                texto = texto + dgveiculosreport.Rows[i].Cells[1].Value.ToString() + "\n";
            }

            DialogResult dialogResult = MessageBox.Show(texto, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
  
            }

        }
    }
}
