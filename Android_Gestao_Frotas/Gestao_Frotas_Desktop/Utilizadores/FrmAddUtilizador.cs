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
    public partial class FrmAddUtilizador : Form
    {
        public FrmAddUtilizador()
        {
            InitializeComponent();
        }

        private void FrmAddUtilizador_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Utilizador' table. You can move, or remove it, as needed.
            //this.utilizadorTableAdapter.Fill(this.dataSet1.Utilizador);
            this.perfilTableAdapter.Fill(this.dataSet1.Perfil);
            txtpassword.Text = spObtemPasswordDefaultTableAdapter.GetData().Rows[0][0].ToString();

            if (Global.NewOrEdit == 0)
            {
                this.Text = "Adicionar Utilizador";
                label1.Text = "Adicionar Utilizador";
                cbState.Checked = true;
                cbState.Enabled = false;
                bttadd.Text = "Adicionar";
            }
            else
            {
                this.Text = "Editar Utilizador";
                label1.Text = "Editar Utilizador";
                //cbState.Checked = true;
                cbState.Enabled = true;
                txtnome.Text = Global.userEdit.Name;
                cbState.Checked = Global.userEdit.Active;
                txtusername.Text = Global.userEdit.Username;
                txtpassword.Text = Global.userEdit.Password;
                cbperfil.SelectedValue = Global.userEdit.Profile.Id;
                bttadd.Text = "Editar";
            }

        }

        private void bttcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttadd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtnome.Text != "" && txtusername.Text != "" && txtpassword.Text != "")
            {
                if (Global.NewOrEdit == 0)
                {
                        utilizadorTableAdapter.Insert(int.Parse(cbperfil.SelectedValue.ToString()), txtusername.Text.TrimEnd(), txtnome.Text.TrimEnd(), txtpassword.Text.TrimEnd(), true);
                        this.Close();
                }
                else if (Global.NewOrEdit == 1)
                {
                        string username = txtusername.Text;
                        string password = txtpassword.Text;
                        string nome = txtnome.Text;

                        utilizadorTableAdapter.UpdateQuery(int.Parse(cbperfil.SelectedValue.ToString()), username, nome, password, cbState.Checked, Global.userEdit.Id);
                        this.Close();
                }
            }
            else
            {
                if (txtnome.Text == "")
                {
                    errorProvider1.SetError(txtnome, "Campo nome Vazio!");
                }
                if (txtusername.Text == "")
                {
                    errorProvider1.SetError(txtusername, "Campo Username Vazio!");
                }
                if (txtpassword.Text == "")
                {
                    errorProvider1.SetError(txtpassword, "Campo Password Vazio!");
                }
            }

        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
