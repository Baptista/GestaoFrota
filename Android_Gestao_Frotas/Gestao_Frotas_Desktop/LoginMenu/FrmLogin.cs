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
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Utilizador' table. You can move, or remove it, as needed.
            //this.utilizadorTableAdapter.Fill(this.dataSet1.Utilizador);
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtlogin.Text != "" && txtpassword.Text != "")
            {
                button1.Enabled = false;
                var a = utilizadorTableAdapter.GetDataByLogin(txtlogin.Text, txtpassword.Text);
                //string a = spLoginTableAdapter.GetData(txtlogin.Text, txtpassword.Text).Rows[0][0].ToString();
                if (a.Count == 0)
                {
                    MessageBox.Show("Credenciais Invalidas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Global.user = new Core_Gestao_Frotas.Business.Models.User
                    {
                        Id = Convert.ToInt32(a.Rows[0][0].ToString()),
                        Profile = new Core_Gestao_Frotas.Business.Models.Profile
                        {
                            Id = Convert.ToInt32(a.Rows[0][1].ToString()),
                            IsIncomplete = true
                        },
                        Username = a.Rows[0][2].ToString(),
                        Name = a.Rows[0][3].ToString(),
                        Password = a.Rows[0][4].ToString(),
                        Active = (bool)(a.Rows[0][5].ToString() == "1" ? true : false),
                    };
                    button1.Enabled = true;
                    Global.frm = this;
                    this.Hide();
                    var frmmenu = new FrmMenu();
                    frmmenu.Show();
                }
                button1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
