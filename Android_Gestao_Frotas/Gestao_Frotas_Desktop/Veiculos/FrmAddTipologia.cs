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
    public partial class FrmAddTipologia : Form
    {
        public FrmAddTipologia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtnome.Text != "")
            {
                if (Global.NewOrEdit == 0)
                {
                    tipologiaTableAdapter.InsertTipologiaQuery(txtnome.Text, cbstate.Checked);
                    this.Close();
                }
                else
                {
                    tipologiaTableAdapter.UpdateTipologiaQuery(txtnome.Text, cbstate.Checked, Global.typology.Id);
                    this.Close();
                }
            }
            else
            {
                if (txtnome.Text == "")
                {
                    errorProvider1.SetError(txtnome, "O campo nome esta vazio");
                }
            }
        }

        private void FrmAddTipologia_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Tipologia' table. You can move, or remove it, as needed.
            this.tipologiaTableAdapter.Fill(this.dataSet1.Tipologia);
            if (Global.NewOrEdit == 0)
            {
                this.Text = "Adicionar Tipologia";
                label1.Text = "Adicionar Tipologia";
                bttadd.Text = "Adicionar";
                cbstate.Checked = true;
                cbstate.Enabled = false;
            }
            else
            {
                this.Text = "Editar Tipologia";
                label1.Text = "Editar Tipologia";
                bttadd.Text = "Editar";
                cbstate.Enabled = true;
                txtnome.Text = Global.typology.Description;
                cbstate.Checked = Global.typology.Active;
            }
        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
