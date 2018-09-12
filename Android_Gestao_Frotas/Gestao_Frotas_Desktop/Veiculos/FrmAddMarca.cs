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
    public partial class FrmAddMarca : Form
    {
        public FrmAddMarca()
        {
            InitializeComponent();
        }

        private void bttadd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtnome.Text != "")
            {
                if (Global.NewOrEdit == 0)
                {
                    marcaTableAdapter.InsertMarcaQuery(txtnome.Text, true);
                    this.Close();
                }
                else
                {
                    marcaTableAdapter.UpdateMarcaQuery(txtnome.Text, cbState.Checked, Global.brand.Id);
                    this.Close();
                }
            }
            else
            {
                if (txtnome.Text == "")
                {
                    errorProvider1.SetError(txtnome, "Campo nome vazio!");
                }
            }
        }

        private void FrmAddMarca_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Marca' table. You can move, or remove it, as needed.
            this.marcaTableAdapter.Fill(this.dataSet1.Marca);
            // TODO: This line of code loads data into the 'dataSet1.Marca' table. You can move, or remove it, as needed.
            //this.marcaTableAdapter.Fill(this.dataSet1.Marca);

            if (Global.NewOrEdit == 0)
            {
                this.Text = "Adicionar Marca";
                label1.Text = "Adicionar Marca";
                bttadd.Text = "Adicionar";
                cbState.Checked = true;
                cbState.Enabled = false;
            }
            else
            {
                this.Text = "Editar Marca";
                label1.Text = "Editar Marca";
                bttadd.Text = "Editar";
                cbState.Enabled = true;
                txtnome.Text = Global.brand.Description;
                cbState.Checked = Global.brand.Active;
            }

        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
