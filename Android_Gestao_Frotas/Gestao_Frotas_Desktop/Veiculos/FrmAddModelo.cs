using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop.Veiculos
{
    public partial class FrmAddModelo : Form
    {
        public FrmAddModelo()
        {
            InitializeComponent();
        }

        private void FrmAddModelo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Modelo' table. You can move, or remove it, as needed.
            //this.modeloTableAdapter.Fill(this.dataSet1.Modelo);
            // TODO: This line of code loads data into the 'dataSet1.Combustivel' table. You can move, or remove it, as needed.
            this.combustivelTableAdapter.Fill(this.dataSet1.Combustivel);
            // TODO: This line of code loads data into the 'dataSet1.Marca' table. You can move, or remove it, as needed.
            this.marcaTableAdapter.Fill(this.dataSet1.Marca);

            if (Global.NewOrEdit == 0)
            {
                this.Text = "Adicionar Modelo";
                label1.Text = "Adicionar Modelo";
                bttadd.Text = "Adicionar";
                cbState.Checked = true;
                cbState.Enabled = false;
            }
            else
            {
                this.Text = "Editar Modelo";
                label1.Text = "Editar Modelo";
                bttadd.Text = "Editar";
                cbState.Enabled = true;
                txtnome.Text = Global.model.Description;
                cbState.Checked = Global.model.Active;
                cbbrand.SelectedValue = Global.model.Brand.Id;
                cbfuel.SelectedValue = Global.model.Fuel.Id;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtnome.Text != "")
            {
                if (Global.NewOrEdit == 0)
                {
                    modeloTableAdapter.InsertModeloQuery(int.Parse(cbbrand.SelectedValue.ToString()), txtnome.Text, cbState.Checked, int.Parse(cbfuel.SelectedValue.ToString()));
                    this.Close();
                }
                else
                {
                    modeloTableAdapter.UpdateModeloQuery(int.Parse(cbbrand.SelectedValue.ToString()), txtnome.Text, cbState.Checked, int.Parse(cbfuel.SelectedValue.ToString()), Global.model.Id);
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

        private void txtnome_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
