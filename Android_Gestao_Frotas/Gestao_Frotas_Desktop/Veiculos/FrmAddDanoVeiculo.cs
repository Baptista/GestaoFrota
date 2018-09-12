using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestao_Frotas_Desktop.Veiculos
{
    public partial class FrmAddDanoVeiculo : Form
    {
        public FrmAddDanoVeiculo()
        {
            InitializeComponent();
        }

        private void bttaddfoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = of.FileName;

            }
        }

        private void bttadd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtdesc.Text != "")
            {
                if (Global.NewOrEditDeep == 0)
                {

                    Global.dano.Add(new Core_Gestao_Frotas.Business.Models.DamageVehicle
                    {
                        Id = -1,
                        Description = txtdesc.Text,
                        Date = DateTime.Now,
                        Active = true,
                        RequestHistory = null,
                        Vehicle = null,
                    });
                    if (pictureBox1.Image != null)
                    {
                        Global.danoComprovativo.Add(new Core_Gestao_Frotas.Business.Models.DamageVehicleDocument
                        {
                            Id = -1,
                            DocumentFormat = ".jpg",
                            DocumentName = "dano",
                            Date = DateTime.Now,
                            Active = true,
                            DamageVehicle = Global.dano[Global.dano.Count - 1],
                            Document = ImageToByteArray(pictureBox1.Image),
                            IsIncomplete = false
                        });
                    }
                    else
                    {
                        Global.danoComprovativo.Add(new Core_Gestao_Frotas.Business.Models.DamageVehicleDocument
                        {
                            Id = -1,
                            DocumentFormat = ".jpg",
                            DocumentName = "dano",
                            Date = DateTime.Now,
                            Active = true,
                            DamageVehicle = Global.dano[Global.dano.Count - 1],
                            Document = null,
                            IsIncomplete = false
                        });
                    }

                }else if (Global.NewOrEditDeep == 1)
                {
                    if (pictureBox1.Image != null)
                    {
                        Global.dano[Global.DeepIndex].Description = txtdesc.Text;
                        Global.danoComprovativo[Global.DeepIndex].Document = ImageToByteArray(pictureBox1.Image);
                    }
                    else
                    {
                        Global.dano[Global.DeepIndex].Description = txtdesc.Text;
                    }
                }
                this.Close();
            }
            else
            {
                if (txtdesc.Text == "")
                {
                        errorProvider1.SetError(txtdesc, "Campo descrição vazio!");
                }
            }
        }

        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private void txtdesc_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void FrmAddDanoVeiculo_Load(object sender, EventArgs e)
        {
            if (Global.NewOrEditDeep == 0)
            {
                label1.Text = "Adicionar Dano";
                bttadd.Text = "Adicionar Dano";
            }
            else if (Global.NewOrEditDeep == 1)
            {
                label1.Text = "Editar Dano";
                bttadd.Text = "Editar Dano";
                txtdesc.Text = Global.danoEdit.Description;
                if (Global.danoComprovativoEdit.Document != null)
                {
                    pictureBox1.Image = DevolveImagem(Global.danoComprovativoEdit.Document);
                }

            }
        }

        private Image DevolveImagem (Byte[] image)
        {
            using (var ms = new MemoryStream(image))
            {
                return Image.FromStream(ms);
            }
        }

    }
}
