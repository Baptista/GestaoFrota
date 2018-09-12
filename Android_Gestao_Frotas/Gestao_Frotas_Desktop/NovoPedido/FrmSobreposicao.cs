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
    public partial class FrmSobreposicao : Form
    {
        public FrmSobreposicao()
        {
            InitializeComponent();
        }

        private void FrmSobreposicao_Load(object sender, EventArgs e)
        {
            label2.Text = "Existe actualmente uma sobreposição com o Veículo:\n" + Global.Sobreposicao.veiculo + "\nData Inicio: " + Global.Sobreposicao.datainicio.ToShortDateString() + " Data Fim: " + Global.Sobreposicao.datafim.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtjustificacao.Text != "")
            {
                Global.Justification = txtjustificacao.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Campo Justificação Vazio!", "Justificação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
