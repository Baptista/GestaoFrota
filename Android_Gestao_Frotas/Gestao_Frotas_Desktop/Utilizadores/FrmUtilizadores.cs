using Core_Gestao_Frotas.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop
{
    public partial class FrmUtilizadores : Form
    {

        int index = -1;

        public FrmUtilizadores()
        {
            InitializeComponent();
        }

        private void FrmUtilizadores_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.spObtemPasswordDefault' table. You can move, or remove it, as needed.
            //this.spObtemPasswordDefaultTableAdapter.Fill(this.dataSet1.spObtemPasswordDefault);
            // TODO: This line of code loads data into the 'dataSet1.UtilizadoresTable' table. You can move, or remove it, as needed.
            //this.utilizadoresTableTableAdapter.Fill(this.dataSet1.UtilizadoresTable);
            // TODO: This line of code loads data into the 'dataSet1.Utilizador' table. You can move, or remove it, as needed.
            //this.utilizadorTableAdapter.Fill(this.dataSet1.Utilizador);
            Reloadusers();
        }

        private void ChangeColorState()
        {
            for (int i = 0; i < dgvutilizadores.Rows.Count; i++)
            {
                if (dgvutilizadores.Rows[i].Cells[3].Value.ToString() == "Ativo")
                {
                    dgvutilizadores.Rows[i].Cells[3].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
                }
                else
                {
                    dgvutilizadores.Rows[i].Cells[3].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed };
                }
            }
        }

        private void Reloadusers()
        {
            dgvutilizadores.Rows.Clear();
            dgvutilizadores.Enabled = false;
            var a = utilizadoresTableTableAdapter.GetData();
            for (int i = 0; i < a.Count; i++)
            {
                dgvutilizadores.Rows.Add(Properties.Resources.user, a.Rows[i][0], a.Rows[i][1], a.Rows[i][2], a.Rows[i][3]);
            }

            for (int i = 0; i < dgvutilizadores.Columns.Count; i++)
                if (dgvutilizadores.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvutilizadores.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvutilizadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvutilizadores.MultiSelect = false;
            dgvutilizadores.Enabled = true;
            ChangeColorState();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.NewOrEdit = 0;
            var frmAddUtilizador = new FrmAddUtilizador();
            frmAddUtilizador.ShowDialog();
            Reloadusers();
            dgvutilizadores.ClearSelection();
            index = -1;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarUser();
        }

        private void EditarUser()
        {
            if (index != -1)
            {
                Global.NewOrEdit = 1;
                var user = utilizadorTableAdapter.GetDataById(index);
                var userid = Convert.ToInt32(user[0][0].ToString());
                var perfilid = Convert.ToInt32(user[0][1].ToString());
                var username = user[0][2].ToString();
                var nome = user[0][3].ToString();
                var password = user[0][4].ToString();
                var ativo = Convert.ToBoolean(user[0][5].ToString());

                Global.userEdit = new User
                {
                    Id = userid,
                    Profile = new Profile { Id = perfilid, IsIncomplete = true },
                    Name = nome,
                    Username = username,
                    Password = password,
                    Active = ativo,
                    IsIncomplete = false,
                };
                var frmAddUtilizador = new FrmAddUtilizador();
                frmAddUtilizador.ShowDialog();
                Reloadusers();
                dgvutilizadores.ClearSelection();
                index = -1;
            }
        }

        private void dgvutilizadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = Convert.ToInt32(dgvutilizadores.Rows[dgvutilizadores.CurrentRow.Index].Cells[4].Value.ToString());
            //System.Windows.Forms.MessageBox.Show(index.ToString());
        }

        private void activarDesactivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivarDesactivarUtilizador();
        }

        private void ActivarDesactivarUtilizador()
        {
            if (index != -1)
            {
                var user = utilizadorTableAdapter.GetDataById(index);
                var username = user[0][2].ToString();
                var ativo = Convert.ToBoolean(user[0][5].ToString());
                var Txt = "";
                if (ativo == true)
                {
                    Txt = "Desactivar";
                }
                else
                {
                    Txt = "Ativar";
                }

                DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer " + Txt + " o utilizador: " + username + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    utilizadorTableAdapter.UpdateEstadoQuery(!ativo, index);
                    MessageBox.Show("Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reloadusers();
                    dgvutilizadores.ClearSelection();
                    index = -1;
                }
            }
        }

        private void reporPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReporPasswordUtilizador();
        }

        private void ReporPasswordUtilizador()
        {
            if (index != -1)
            {
                var user = utilizadorTableAdapter.GetDataById(index);
                var oldpassword = spObtemPasswordDefaultTableAdapter.GetData().Rows[0][0].ToString();

                var username = user[0][2].ToString();

                DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer repor a password do utilizador: " + username + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    utilizadorTableAdapter.UpdateReporPasswordQuery(oldpassword, index);
                    MessageBox.Show("Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reloadusers();
                    dgvutilizadores.ClearSelection();
                    index = -1;
                }

            }
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditarUser();
        }

        private void activarDesactivarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ActivarDesactivarUtilizador();
        }

        private void reporPasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReporPasswordUtilizador();
        }
    }
}
