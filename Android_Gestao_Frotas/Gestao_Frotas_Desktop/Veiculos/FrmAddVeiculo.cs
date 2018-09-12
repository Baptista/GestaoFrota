using Gestao_Frotas_Desktop.Veiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop
{
    public partial class FrmAddVeiculo : Form
    {

        List<int> list = new List<int>();
        int IndexDanos = -1;
        int littlefix = 0;

        public FrmAddVeiculo()
        {
            InitializeComponent();
        }

        private void FrmAddVeiculo_Load(object sender, EventArgs e)
        {
            var teste = DateTime.Now.ToBinary().ToString();
            //DateTime today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            // TODO: This line of code loads data into the 'dataSet1.Danos_Veiculo_Comprovativo' table. You can move, or remove it, as needed.
            //this.danos_Veiculo_ComprovativoTableAdapter.Fill(this.dataSet1.Danos_Veiculo_Comprovativo);
            // TODO: This line of code loads data into the 'dataSet1.Danos_Veiculo' table. You can move, or remove it, as needed.
            //this.danos_VeiculoTableAdapter.Fill(this.dataSet1.Danos_Veiculo);
            // TODO: This line of code loads data into the 'dataSet1.Veiculo' table. You can move, or remove it, as needed.
            // this.veiculoTableAdapter.Fill(this.dataSet1.Veiculo);
            // TODO: This line of code loads data into the 'dataSet1.Utilizador' table. You can move, or remove it, as needed.
            this.utilizadorTableAdapter.Fill(this.dataSet1.Utilizador);
            // TODO: This line of code loads data into the 'dataSet1.Tipologia' table. You can move, or remove it, as needed.
            this.tipologiaTableAdapter.Fill(this.dataSet1.Tipologia);
            // TODO: This line of code loads data into the 'dataSet1.Modelo' table. You can move, or remove it, as needed.
            //this.modeloTableAdapter.Fill(this.dataSet1.Modelo);
            // TODO: This line of code loads data into the 'dataSet1.Marca' table. You can move, or remove it, as needed.
            this.marcaTableAdapter.Fill(this.dataSet1.Marca);

            list.Add(-1);
            cbowner.Items.Add("Empresa");
            var utilizadores = utilizadorTableAdapter.GetData();
            for (int i = 0; i < utilizadores.Count; i++)
            {
                list.Add(int.Parse(utilizadores.Rows[i][0].ToString()));
                cbowner.Items.Add(utilizadores.Rows[i][3].ToString() + " (" + utilizadores.Rows[i][2].ToString() + ")");
            }

            //Global.dano = new List<Core_Gestao_Frotas.Business.Models.DamageVehicle>();
            //Global.danoComprovativo = new List<Core_Gestao_Frotas.Business.Models.DamageVehicleDocument>();

            if (Global.NewOrEdit == 0)
            {
                cbmarca.SelectedIndex = -1;
                cbmodelo.Enabled = false;
                cbstate.Checked = true;
                cbstate.Enabled = false;
            }else if (Global.NewOrEdit == 1)
            {
                this.Text = "Editar Veiculo";
                label1.Text = "Editar Veiculo";
                bttadd.Text = "Editar Veiculo";

                var modeloespecific = modeloTableAdapter.GetDataById(Global.vehicle.Model.Id);
                cbmarca.SelectedValue = int.Parse(modeloespecific[0][1].ToString());
                modeloTableAdapter.FillByIdMarca(this.dataSet1.Modelo, int.Parse(cbmarca.SelectedValue.ToString()));

                cbmodelo.Enabled = true;
                cbmodelo.SelectedValue = Global.vehicle.Model.Id;
                cbtipologia.SelectedValue = Global.vehicle.Typology.Id;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == Global.vehicle.User.Id)
                    {
                        cbowner.SelectedIndex = i;
                    }
                }
                txtmatricula.Text = Global.vehicle.LicensePlate;
                cbstate.Enabled = true;
                cbstate.Checked = Global.vehicle.Active;
                nudkms.Value = Decimal.Parse(Global.vehicle.StartKms.ToString());
                nudkmscontrato.Value = Decimal.Parse(Global.vehicle.ContractKms.ToString());

                Reloaddanos();

            }

            littlefix = 1;

        }

        private void cbmarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (littlefix == 1)
            {
                cbmodelo.Enabled = true;
                modeloTableAdapter.FillByIdMarca(this.dataSet1.Modelo, int.Parse(cbmarca.SelectedValue.ToString()));
            }
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

        private void button3_Click(object sender, EventArgs e)
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

        private void dgvdanos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IndexDanos = dgvdanos.CurrentCell.RowIndex;
        }

        private void button4_Click(object sender, EventArgs e)
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
                else
                {
                    int iddano = int.Parse(dgvdanos.Rows[dgvdanos.CurrentRow.Index].Cells[0].Value.ToString());
                    string desc = dgvdanos.Rows[dgvdanos.CurrentRow.Index].Cells[1].Value.ToString();
                    dgvdanos.ClearSelection();

                    if (iddano == -1)
                    {
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
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Deseja remover o dano PERMANENTEMENTE " + desc + " ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Global.dano.RemoveAt(IndexDanos);
                            Global.danoComprovativo.RemoveAt(IndexDanos);
                            danos_Veiculo_ComprovativoTableAdapter.DeleteQuery(iddano);
                            danos_VeiculoTableAdapter.DeleteQuery(iddano);
                            Reloaddanos();
                            dgvdanos.ClearSelection();
                        }

                        IndexDanos = -1;
                    }

                }
            }
        }

        private void downloadImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvdanos.Rows.Count > 0 && IndexDanos != -1)
            {
                if (Global.danoComprovativo[IndexDanos].Document != null)
                {
                    var imagem = DevolveImagem(Global.danoComprovativo[IndexDanos].Document);
                   SaveImageCapture(imagem, Global.danoComprovativo[IndexDanos].DocumentName);        
                }
            }
            dgvdanos.ClearSelection();
            IndexDanos = -1;
        }

        private Image DevolveImagem(Byte[] image)
        {
            using (var ms = new MemoryStream(image))
            {
                return Image.FromStream(ms);
            }
        }

        private Image ConvertImagem(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
            }
            return image;
        }

        public static void SaveImageCapture(Image image, string nome)
        {
            Bitmap bm = new Bitmap(image);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = nome;
            sfd.Filter = "Imagem|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                bm.Save(sfd.FileName, format);
            }
        }

        private void bttadd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (cbmarca.SelectedIndex != -1 && cbmodelo.SelectedIndex != -1 && cbtipologia.SelectedIndex != -1 && cbowner.SelectedIndex != -1 && txtmatricula.MaskCompleted == true && nudkmscontrato.Value > 0)
            {
                if (Global.NewOrEdit == 0)
                {
                    if (cbowner.SelectedIndex == 0)
                    {
                        veiculoTableAdapter.InsertQuery(int.Parse(cbmodelo.SelectedValue.ToString()), int.Parse(cbtipologia.SelectedValue.ToString()), null, txtmatricula.Text, true, nudkms.Value, nudkmscontrato.Value, cbstate.Checked);
                    }
                    else
                    {
                        veiculoTableAdapter.InsertQuery(int.Parse(cbmodelo.SelectedValue.ToString()), int.Parse(cbtipologia.SelectedValue.ToString()), list[cbowner.SelectedIndex], txtmatricula.Text, true, nudkms.Value, nudkmscontrato.Value, cbstate.Checked);
                    }

                    if (Global.dano.Count > 0)
                    {
                        int idVeiculoAdded =  int.Parse(veiculoTableAdapter.GetDataByMaxId()[0][0].ToString());

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

                    this.Close();
                }
                else if (Global.NewOrEdit == 1)
                {
                    if (cbowner.SelectedIndex == 0)
                    {
                        veiculoTableAdapter.UpdateQuery(int.Parse(cbmodelo.SelectedValue.ToString()), int.Parse(cbtipologia.SelectedValue.ToString()), null, txtmatricula.Text, true, nudkms.Value, nudkmscontrato.Value, cbstate.Checked, Global.vehicle.Id);
                    }
                    else
                    {
                        veiculoTableAdapter.UpdateQuery(int.Parse(cbmodelo.SelectedValue.ToString()), int.Parse(cbtipologia.SelectedValue.ToString()), list[cbowner.SelectedIndex], txtmatricula.Text, true, nudkms.Value, nudkmscontrato.Value, cbstate.Checked, Global.vehicle.Id);
                    }

                    if (Global.dano.Count > 0)
                    {
                        int idVeiculoAdded = Global.vehicle.Id;

                        for (int i = 0; i < Global.dano.Count; i++)
                        {

                            if (Global.dano[i].Id != -1)
                            {
                                if (Global.dano[i].RequestHistory != null)
                                {
                                    danos_VeiculoTableAdapter.UpdateQuery(Global.dano[i].RequestHistory.Id, Global.dano[i].Date, Global.dano[i].Description, true, idVeiculoAdded, Global.dano[i].Id);
                                }
                                else
                                {
                                    danos_VeiculoTableAdapter.UpdateQuery(null, Global.dano[i].Date, Global.dano[i].Description, true, idVeiculoAdded, Global.dano[i].Id);
                                }
                                if (Global.danoComprovativo[i].Document != null)
                                {
                                    int idDanoAdded = Global.dano[i].Id;
                                    danos_Veiculo_ComprovativoTableAdapter.UpdateQuery(idDanoAdded, Global.danoComprovativo[i].Document, ".jpeg", Global.danoComprovativo[i].DocumentName, Global.danoComprovativo[i].Date, true, Global.danoComprovativo[i].Id);
                                }
                            }
                            else
                            {
                                danos_VeiculoTableAdapter.InsertQuery(null, DateTime.Now.ToString(), Global.dano[i].Description, true, idVeiculoAdded);
                                if (Global.danoComprovativo[i].Document != null)
                                {
                                    int idDanoAdded = int.Parse(danos_VeiculoTableAdapter.GetDataByMaxId()[0][0].ToString());
                                    danos_Veiculo_ComprovativoTableAdapter.InsertQuery(idDanoAdded, Global.danoComprovativo[i].Document, ".jpeg", Global.danoComprovativo[i].DocumentName, DateTime.Now.ToString(), true);
                                }
                            }


                        }

                    }
                    this.Close();
                }
            }
            else
            {
                if (cbmarca.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbmarca, "Selecione uma marca!");
                }
                if (cbmodelo.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbmodelo, "Selecione um modelo!");
                }
                if (cbtipologia.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbtipologia, "Selecione uma tipologia!");
                }
                if (cbowner.SelectedIndex == -1)
                {
                    errorProvider1.SetError(cbowner, "Selecione um owner!");
                }
                if (txtmatricula.MaskCompleted == false)
                {
                    errorProvider1.SetError(txtmatricula, "Matricula Invalida!");
                }
                if (nudkmscontrato.Value == 0)
                {
                    errorProvider1.SetError(nudkmscontrato, "Numero de Kms de Contracto Invalido!");
                }
            }
        }

    }
}
