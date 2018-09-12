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
    public partial class FrmJustificacao : Form
    {
        public FrmJustificacao()
        {
            InitializeComponent();
        }

        private void FrmJustificacao_Load(object sender, EventArgs e)
        {
            label1.Text = "Insira uma Justificação para terminar o Pedido\n" + Global.VeiculoSelecionado.Veiculo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Global.Justification = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Campo Justificação Vazio!", "Justificação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
