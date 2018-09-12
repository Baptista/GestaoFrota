using Gestao_Frotas_Desktop.Veiculos;
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

    public partial class frmVeiculos : Form
    {

        int tabindex = 0;
        int indexVeiculos = -1;
        int indexMarcas = -1;
        int indexModelos = -1;
        int indexTipologias = -1;

        int indextable = -1;

        public frmVeiculos()
        {
            InitializeComponent();
        }

        private void FrmVeiculos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Danos_Veiculo_Comprovativo' table. You can move, or remove it, as needed.
            //this.danos_Veiculo_ComprovativoTableAdapter.Fill(this.dataSet1.Danos_Veiculo_Comprovativo);
            // TODO: This line of code loads data into the 'dataSet1.Danos_Veiculo' table. You can move, or remove it, as needed.
            //this.danos_VeiculoTableAdapter.Fill(this.dataSet1.Danos_Veiculo);
            if (Global.optionVehicle == 0)
            {
                lbldesc.Text = "Veículos";
            }else if (Global.optionVehicle == 1)
            {
                lbldesc.Text = "Marcas";
            }
            else if (Global.optionVehicle == 2)
            {
                lbldesc.Text = "Modelos";
            }
            else if (Global.optionVehicle == 3)
            {
                lbldesc.Text = "Tipologias";
            }
            tabindex = Global.optionVehicle;
            tabveiculos.SelectedIndex = tabindex;

            ReloadData();
        }

        private void ReloadVeiculos()
        {
            dgveiculos.Rows.Clear();
            var veiculos = spListaVeiculosTA.GetData();

            for (int i = 0; i < veiculos.Count; i++)
            {
                var idveiculo = veiculos.Rows[i][0].ToString();
                var veiculo = veiculos.Rows[i][1].ToString() + " - " + veiculos.Rows[i][5].ToString() + " - " + veiculos.Rows[i][7].ToString();
                var matricula = veiculos.Rows[i][12].ToString();
                var owner = veiculos.Rows[i][11].ToString();
                var combustivel = veiculos.Rows[i][9].ToString();
                var estado = Convert.ToBoolean(veiculos.Rows[i][15]);

                if (estado == true)
                {
                    dgveiculos.Rows.Add(idveiculo, Properties.Resources.car_test, veiculo, matricula, owner, combustivel, "Ativo");
                }
                else
                {
                    dgveiculos.Rows.Add(idveiculo, Properties.Resources.car_test, veiculo, matricula, owner, combustivel, "Inativo");
                }

            }

            for (int i = 0; i < dgveiculos.Columns.Count; i++)
                if (dgveiculos.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgveiculos.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgveiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgveiculos.MultiSelect = false;
            dgveiculos.Enabled = true;

            ChangeColorStateVeiculos();

        }

        private void ReloadMarcas()
        {
            dgvmarcas.Rows.Clear();
            var marcas = spListaMarcasTA.GetData(null, true);

            for (int i = 0; i < marcas.Count; i++)
            {
                var idmarca = marcas.Rows[i][0].ToString();
                var marca = marcas.Rows[i][1].ToString();
                var estado = Convert.ToBoolean(marcas.Rows[i][2]);

                if (estado == true)
                {
                    dgvmarcas.Rows.Add(idmarca, Properties.Resources.marca, marca, "Ativo");
                }
                else
                {
                    dgvmarcas.Rows.Add(idmarca, Properties.Resources.marca, marca, "Inativo");
                }

            }

            for (int i = 0; i < dgvmarcas.Columns.Count; i++)
                if (dgvmarcas.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvmarcas.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvmarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmarcas.MultiSelect = false;
            dgvmarcas.Enabled = true;

            ChangeColorStateMarcas();
        }

        private void ReloadModelos()
        {
            dgvmodelos.Rows.Clear();
            var modelos = listaModelosTA.GetData();

            for (int i = 0; i < modelos.Count; i++)
            {

                var idmodelo = modelos.Rows[i][0].ToString();
                var modelo = modelos.Rows[i][1] + " (" + modelos.Rows[i][3] + ")".ToString();
                var Ativo = Convert.ToBoolean(modelos.Rows[i][2]);
                var Combustivel = modelos.Rows[i][4].ToString();

                if (Ativo == true)
                {
                    dgvmodelos.Rows.Add(idmodelo, Properties.Resources.modelo, modelo, Combustivel, "Ativo");
                }
                else
                {
                    dgvmodelos.Rows.Add(idmodelo, Properties.Resources.modelo, modelo, Combustivel, "Inativo");
                }

            }

            for (int i = 0; i < dgvmodelos.Columns.Count; i++)
                if (dgvmodelos.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvmodelos.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvmodelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmodelos.MultiSelect = false;
            dgvmodelos.Enabled = true;

            ChangeColorStateModelos();
        }

        private void ReloadTipologias()
        {
            dgvTipologias.Rows.Clear();
            var tipologias = spListaTipologiaTA.GetData(null, true);

            for (int i = 0; i < tipologias.Count; i++)
            {
                var idtipologia = tipologias.Rows[i][0].ToString();
                var tipologia = tipologias.Rows[i][1].ToString();
                var estado = Convert.ToBoolean(tipologias.Rows[i][2]);

                if (estado == true)
                {
                    dgvTipologias.Rows.Add(idtipologia, Properties.Resources.tipologia, tipologia, "Ativo");
                }
                else
                {
                    dgvTipologias.Rows.Add(idtipologia, Properties.Resources.tipologia, tipologia, "Inativo");
                }

            }

            for (int i = 0; i < dgvTipologias.Columns.Count; i++)
                if (dgvTipologias.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvTipologias.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvTipologias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipologias.MultiSelect = false;
            dgvTipologias.Enabled = true;

            ChangeColorStateTipologias();
        }

        private void ReloadData()
        {
            dgveiculos.Rows.Clear();
            dgvmarcas.Rows.Clear();
            dgvmodelos.Rows.Clear();
            dgvTipologias.Rows.Clear();

            //carregar dados

            var veiculos = spListaVeiculosTA.GetData();
            var marcas = spListaMarcasTA.GetData(null, true);
            var modelos = listaModelosTA.GetData();
            var tipologias = spListaTipologiaTA.GetData(null, true);

            //tabela Veiculos

            for (int i = 0; i < veiculos.Count; i++)
            {
                var idveiculo = veiculos.Rows[i][0].ToString();
                var veiculo = veiculos.Rows[i][1].ToString() + " - " + veiculos.Rows[i][5].ToString() + " - " + veiculos.Rows[i][7].ToString();
                var matricula = veiculos.Rows[i][12].ToString();
                var owner = veiculos.Rows[i][11].ToString();
                var combustivel = veiculos.Rows[i][9].ToString();
                var estado = Convert.ToBoolean(veiculos.Rows[i][15]);

                if (estado == true)
                {
                    dgveiculos.Rows.Add(idveiculo, Properties.Resources.car_test, veiculo, matricula, owner, combustivel, "Ativo");
                }
                else
                {
                    dgveiculos.Rows.Add(idveiculo, Properties.Resources.car_test, veiculo, matricula, owner, combustivel, "Inativo");
                }

            }

            for (int i = 0; i < dgveiculos.Columns.Count; i++)
                if (dgveiculos.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgveiculos.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgveiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgveiculos.MultiSelect = false;
            dgveiculos.Enabled = true;

            ChangeColorStateVeiculos();

            //tabela marcas

            for (int i = 0; i < marcas.Count; i++)
            {
                var idmarca = marcas.Rows[i][0].ToString();
                var marca = marcas.Rows[i][1].ToString();
                var estado = Convert.ToBoolean(marcas.Rows[i][2]);

                if (estado == true)
                {
                    dgvmarcas.Rows.Add(idmarca, Properties.Resources.marca, marca, "Ativo");
                }
                else
                {
                    dgvmarcas.Rows.Add(idmarca, Properties.Resources.marca, marca, "Inativo");
                }

            }

            for (int i = 0; i < dgvmarcas.Columns.Count; i++)
                if (dgvmarcas.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvmarcas.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvmarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmarcas.MultiSelect = false;
            dgvmarcas.Enabled = true;

            ChangeColorStateMarcas();

            //tabela modelos

            for (int i = 0; i < modelos.Count; i++)
            {

                var idmodelo = modelos.Rows[i][0].ToString();
                var modelo = modelos.Rows[i][1] + " (" + modelos.Rows[i][3] + ")".ToString();
                var Ativo = Convert.ToBoolean(modelos.Rows[i][2]);
                var Combustivel = modelos.Rows[i][4].ToString();

                if (Ativo == true)
                {
                    dgvmodelos.Rows.Add(idmodelo, Properties.Resources.modelo, modelo, Combustivel, "Ativo");
                }
                else
                {
                    dgvmodelos.Rows.Add(idmodelo, Properties.Resources.modelo, modelo, Combustivel, "Inativo");
                }

            }

            for (int i = 0; i < dgvmodelos.Columns.Count; i++)
                if (dgvmodelos.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvmodelos.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvmodelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmodelos.MultiSelect = false;
            dgvmodelos.Enabled = true;

            ChangeColorStateModelos();

            //tabela tipologias

            for (int i = 0; i < tipologias.Count; i++)
            {
                var idtipologia = tipologias.Rows[i][0].ToString();
                var tipologia = tipologias.Rows[i][1].ToString();
                var estado = Convert.ToBoolean(tipologias.Rows[i][2]);

                if (estado == true)
                {
                    dgvTipologias.Rows.Add(idtipologia, Properties.Resources.tipologia, tipologia, "Ativo");
                }
                else
                {
                    dgvTipologias.Rows.Add(idtipologia, Properties.Resources.tipologia, tipologia, "Inativo");
                }

            }

            for (int i = 0; i < dgvTipologias.Columns.Count; i++)
                if (dgvTipologias.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dgvTipologias.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    break;
                }

            dgvTipologias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipologias.MultiSelect = false;
            dgvTipologias.Enabled = true;

            ChangeColorStateTipologias();

        }

        private void tabveiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabindex = tabveiculos.SelectedIndex;
            if (tabindex == 0)
            {
                lbldesc.Text = "Veículos";
            }
            else if (tabindex == 1)
            {
                lbldesc.Text = "Marcas";
            }
            else if (tabindex == 2)
            {
                lbldesc.Text = "Modelos";
            }
            else if (tabindex == 3)
            {
                lbldesc.Text = "Tipologias";
            }
            dgveiculos.ClearSelection();
            dgvmarcas.ClearSelection();
            dgvmodelos.ClearSelection();
            dgvTipologias.ClearSelection();
            indexVeiculos = -1;
            indexMarcas = -1;
            indexModelos = -1;
            indexTipologias = -1;
        }

        private void ChangeColorStateVeiculos()
        {
            for (int i = 0; i < dgveiculos.Rows.Count; i++)
            {
                if (dgveiculos.Rows[i].Cells[6].Value.ToString() == "Ativo")
                {
                    dgveiculos.Rows[i].Cells[6].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
                }
                else
                {
                    dgveiculos.Rows[i].Cells[6].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed };
                }
            }
        }

        private void ChangeColorStateMarcas()
        {
            for (int i = 0; i < dgvmarcas.Rows.Count; i++)
            {
                if (dgvmarcas.Rows[i].Cells[3].Value.ToString() == "Ativo")
                {
                    dgvmarcas.Rows[i].Cells[3].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
                }
                else
                {
                    dgvmarcas.Rows[i].Cells[3].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed };
                }
            }
        }

        private void ChangeColorStateModelos()
        {
            for (int i = 0; i < dgvmodelos.Rows.Count; i++)
            {
                if (dgvmodelos.Rows[i].Cells[4].Value.ToString() == "Ativo")
                {
                    dgvmodelos.Rows[i].Cells[4].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
                }
                else
                {
                    dgvmodelos.Rows[i].Cells[4].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed };
                }
            }
        }

        private void ChangeColorStateTipologias()
        {
            for (int i = 0; i < dgvTipologias.Rows.Count; i++)
            {
                if (dgvTipologias.Rows[i].Cells[3].Value.ToString() == "Ativo")
                {
                    dgvTipologias.Rows[i].Cells[3].Style = new DataGridViewCellStyle { ForeColor = Color.Green };
                }
                else
                {
                    dgvTipologias.Rows[i].Cells[3].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed };
                }
            }
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabindex == 0)
            {
                Global.dano = new List<Core_Gestao_Frotas.Business.Models.DamageVehicle>();
                Global.danoComprovativo = new List<Core_Gestao_Frotas.Business.Models.DamageVehicleDocument>();

                Global.NewOrEdit = 0;
                var frmAddVeiculo = new FrmAddVeiculo();
                frmAddVeiculo.ShowDialog();
                ReloadVeiculos();
                dgveiculos.ClearSelection();
                indextable = -1;
                indexVeiculos = -1;

            }
            else if (tabindex == 1)
            {
                Global.NewOrEdit = 0;
                var frmAddMarca = new FrmAddMarca();
                frmAddMarca.ShowDialog();
                ReloadMarcas();
                dgvmarcas.ClearSelection();
                indextable = -1;
                indexMarcas = -1;
            }
            else if (tabindex == 2)
            {
                Global.NewOrEdit = 0;
                var frmAddModelo = new FrmAddModelo();
                frmAddModelo.ShowDialog();
                ReloadModelos();
                dgvmodelos.ClearSelection();
                indextable = -1;
                indexModelos = -1;
            }
            else if (tabindex == 3)
            {
                Global.NewOrEdit = 0;
                var frmAddTipologia = new FrmAddTipologia();
                frmAddTipologia.ShowDialog();
                ReloadTipologias();
                dgvTipologias.ClearSelection();
                indextable = -1;
                indexTipologias = -1;
            }
        }

        private void dgveiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexVeiculos = Convert.ToInt32(dgveiculos.Rows[dgveiculos.CurrentRow.Index].Cells[0].Value.ToString());
            indextable = dgveiculos.CurrentCell.RowIndex;
        }

        private void dgvmarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexMarcas = Convert.ToInt32(dgvmarcas.Rows[dgvmarcas.CurrentRow.Index].Cells[0].Value.ToString());
            indextable = dgvmarcas.CurrentCell.RowIndex;
        }

        private void dgvmodelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexModelos = Convert.ToInt32(dgvmodelos.Rows[dgvmodelos.CurrentRow.Index].Cells[0].Value.ToString());
            indextable = dgvmodelos.CurrentCell.RowIndex;
        }

        private void dgvTipologias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexTipologias = Convert.ToInt32(dgvTipologias.Rows[dgvTipologias.CurrentRow.Index].Cells[0].Value.ToString());
            indextable = dgvTipologias.CurrentCell.RowIndex;
        }

        private void EditarMenu()
        {
            if (tabindex == 0)
            {
                if (indexVeiculos != -1)
                {
                    var veiculo = veiculoTableAdapter.GetDataById(indexVeiculos);

                    if (veiculo[0][3] != DBNull.Value)
                    {
                        Global.vehicle = new Core_Gestao_Frotas.Business.Models.Vehicle
                        {
                            Id = indexVeiculos,
                            Model = new Core_Gestao_Frotas.Business.Models.Model
                            {
                                Id = int.Parse(veiculo[0][1].ToString()),
                                IsIncomplete = true
                            },
                            Typology = new Core_Gestao_Frotas.Business.Models.Typology
                            {
                                Id = int.Parse(veiculo[0][2].ToString()),
                                IsIncomplete = true
                            },
                            User = new Core_Gestao_Frotas.Business.Models.User
                            {
                                Id = int.Parse(veiculo[0][3].ToString()),
                                IsIncomplete = true
                            },
                            LicensePlate = veiculo[0][4].ToString(),
                            Available = Convert.ToBoolean(veiculo[0][5].ToString()),
                            StartKms = float.Parse(veiculo[0][6].ToString()),
                            ContractKms = float.Parse(veiculo[0][7].ToString()),
                            Active = Convert.ToBoolean(veiculo[0][8].ToString()),
                        };
                    }
                    else
                    {
                        Global.vehicle = new Core_Gestao_Frotas.Business.Models.Vehicle
                        {
                            Id = indexVeiculos,
                            Model = new Core_Gestao_Frotas.Business.Models.Model
                            {
                                Id = int.Parse(veiculo[0][1].ToString()),
                                IsIncomplete = true
                            },
                            Typology = new Core_Gestao_Frotas.Business.Models.Typology
                            {
                                Id = int.Parse(veiculo[0][2].ToString()),
                                IsIncomplete = true
                            },
                            User = new Core_Gestao_Frotas.Business.Models.User
                            {
                                Id = -1,
                                IsIncomplete = true
                            },
                            LicensePlate = veiculo[0][4].ToString(),
                            Available = Convert.ToBoolean(veiculo[0][5].ToString()),
                            StartKms = float.Parse(veiculo[0][6].ToString()),
                            ContractKms = float.Parse(veiculo[0][7].ToString()),
                            Active = Convert.ToBoolean(veiculo[0][8].ToString()),
                        };
                    }

                    Global.dano = new List<Core_Gestao_Frotas.Business.Models.DamageVehicle>();
                    Global.danoComprovativo = new List<Core_Gestao_Frotas.Business.Models.DamageVehicleDocument>();

                    var receivedanos = danos_VeiculoTableAdapter.GetDataByIdVeiculo(Global.vehicle.Id);
                    if (receivedanos.Count > 0)
                    {
                        for (int i = 0; i < receivedanos.Count; i++)
                        {

                            if (receivedanos[i][1] != DBNull.Value)
                            {
                                Global.dano.Add(new Core_Gestao_Frotas.Business.Models.DamageVehicle
                                {
                                    Id = receivedanos[i].IdDanosVeiculo,
                                    RequestHistory = new Core_Gestao_Frotas.Business.Models.RequestHistory
                                    {
                                        Id = receivedanos[i].IdPedidoMarcacaoHistorico,
                                        IsIncomplete = true
                                    },
                                    Date = receivedanos[i].Data,
                                    Description = receivedanos[i].Descricao,
                                    Active = receivedanos[i].Ativo,
                                    Vehicle = new Core_Gestao_Frotas.Business.Models.Vehicle
                                    {
                                        Id = receivedanos[i].IdVeiculo,
                                        IsIncomplete = true
                                    },
                                    IsIncomplete = false
                                });
                            }
                            else
                            {
                                Global.dano.Add(new Core_Gestao_Frotas.Business.Models.DamageVehicle
                                {
                                    Id = receivedanos[i].IdDanosVeiculo,
                                    Date = receivedanos[i].Data,
                                    Description = receivedanos[i].Descricao,
                                    Active = receivedanos[i].Ativo,
                                    Vehicle = new Core_Gestao_Frotas.Business.Models.Vehicle
                                    {
                                        Id = receivedanos[i].IdVeiculo,
                                        IsIncomplete = true
                                    },
                                    IsIncomplete = false
                                });
                            }

                            var receivedanocomprovativo = danos_Veiculo_ComprovativoTableAdapter.GetDataByIdDano(receivedanos[i].IdDanosVeiculo);
                            if (receivedanocomprovativo.Count > 0)
                            {
                                Global.danoComprovativo.Add(new Core_Gestao_Frotas.Business.Models.DamageVehicleDocument
                                {
                                    Id = receivedanocomprovativo[0].IdDanosVeiculoComprovativo,
                                    DocumentName = receivedanocomprovativo[0].NomeDocumento,
                                    Document = receivedanocomprovativo[0].Documento,
                                    DocumentFormat = receivedanocomprovativo[0].FormatoDocumento,
                                    DamageVehicle = Global.dano[Global.dano.Count - 1],
                                    Date = receivedanocomprovativo[0].Data,
                                    Active = receivedanocomprovativo[0].Ativo,
                                    IsIncomplete = false,
                                });
                            }
                            else
                            {
                                Global.danoComprovativo.Add(new Core_Gestao_Frotas.Business.Models.DamageVehicleDocument
                                {
                                    Id = -1,
                                    DocumentName = "NO DOCUMENT",
                                    Document = null,
                                    DocumentFormat = ".jpeg",
                                    Date = DateTime.Now,
                                    Active = true,
                                    IsIncomplete = true,
                                });
                            }
                        }
                    }

                    Global.NewOrEdit = 1;
                    var frmAddVeiculo = new FrmAddVeiculo();
                    frmAddVeiculo.ShowDialog();
                    ReloadVeiculos();
                    indexVeiculos = -1;
                    indextable = -1;
                    dgveiculos.ClearSelection();
                }
            }
            else if (tabindex == 1)
            {
                if (indexMarcas != -1)
                {
                    var marca = marcaTableAdapter.GetDataById(indexMarcas);
                    Global.brand = new Core_Gestao_Frotas.Business.Models.Brand
                    {
                        Id = indexMarcas,
                        Description = marca[0][1].ToString(),
                        Active = Convert.ToBoolean(marca[0][2].ToString()),
                        IsIncomplete = false
                    };
                    Global.NewOrEdit = 1;
                    var frmAddMarca = new FrmAddMarca();
                    frmAddMarca.ShowDialog();
                    ReloadMarcas();
                    indexMarcas = -1;
                    indextable = -1;
                    dgvmarcas.ClearSelection();
                }
            }
            else if (tabindex == 2)
            {
                if (indexModelos != -1)
                {
                    var modelo = modeloTableAdapter.GetDataById(indexModelos);
                    Global.model = new Core_Gestao_Frotas.Business.Models.Model
                    {
                        Id = indexModelos,
                        Brand = new Core_Gestao_Frotas.Business.Models.Brand
                        {
                            Id = Convert.ToInt32(modelo[0][1].ToString()),
                            IsIncomplete = true
                        },
                        Description = modelo[0][2].ToString(),
                        Active = Convert.ToBoolean(modelo[0][3].ToString()),
                        Fuel = new Core_Gestao_Frotas.Business.Models.Fuel
                        {
                            Id = Convert.ToInt32(modelo[0][4].ToString()),
                            IsIncomplete = true
                        },
                        IsIncomplete = false
                    };
                    Global.NewOrEdit = 1;
                    var frmAddModelo = new FrmAddModelo();
                    frmAddModelo.ShowDialog();
                    ReloadModelos();
                    indexModelos = -1;
                    indextable = -1;
                    dgvmodelos.ClearSelection();
                }
            }
            else if (tabindex == 3)
            {
                if (indexTipologias != -1)
                {
                    var tipologia = tipologiaTableAdapter.GetDataById(indexTipologias);
                    Global.typology = new Core_Gestao_Frotas.Business.Models.Typology
                    {
                        Id = indexTipologias,
                        Description = tipologia[0][1].ToString(),
                        Active = Convert.ToBoolean(tipologia[0][2].ToString()),
                        IsIncomplete = false
                    };
                    Global.NewOrEdit = 1;
                    var frmAddTipologia = new FrmAddTipologia();
                    frmAddTipologia.ShowDialog();
                    ReloadTipologias();
                    indexTipologias = -1;
                    indextable = -1;
                    dgvTipologias.ClearSelection();
                }
            }
        }

        private void ActivarDesactivarMenu()
        {
            if (tabindex == 0)
            {
                if (indexVeiculos != -1)
                {
                    var nome = dgveiculos.Rows[indextable].Cells[2].Value.ToString();
                    var estado = dgveiculos.Rows[indextable].Cells[6].Value.ToString();
                    var alterarestado = true;

                    if (estado == "Ativo")
                    {
                        estado = "desativar";
                        alterarestado = false;
                    }
                    else if (estado == "Inativo")
                    {
                        estado = "ativar";
                        alterarestado = true;
                    }

                    DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer " + estado + " o veiculo: " + nome + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        veiculoTableAdapter.UpdateEstadoQuery(alterarestado, indexVeiculos);
                        MessageBox.Show("Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReloadVeiculos();
                        dgveiculos.ClearSelection();
                        indextable = -1;
                        indexVeiculos = -1;
                    }

                }
            }
            else if (tabindex == 1)
            {
                if (indexMarcas != -1)
                {
                    var nome = dgvmarcas.Rows[indextable].Cells[2].Value.ToString();
                    var estado = dgvmarcas.Rows[indextable].Cells[3].Value.ToString();
                    var alterarestado = true;

                    if (estado == "Ativo")
                    {
                        estado = "desativar";
                        alterarestado = false;
                    }
                    else if (estado == "Inativo")
                    {
                        estado = "ativar";
                        alterarestado = true;
                    }

                    DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer " + estado + " a marca: " + nome + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        marcaTableAdapter.UpdateEstadoMarcaQuery(alterarestado, indexMarcas);
                        MessageBox.Show("Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReloadMarcas();
                        dgvmarcas.ClearSelection();
                        indextable = -1;
                        indexMarcas = -1;
                    }
                }
            }
            else if (tabindex == 2)
            {
                if (indexModelos != -1)
                {
                    var nome = dgvmodelos.Rows[indextable].Cells[2].Value.ToString();
                    var estado = dgvmodelos.Rows[indextable].Cells[4].Value.ToString();
                    var alterarestado = true;

                    if (estado == "Ativo")
                    {
                        estado = "desativar";
                        alterarestado = false;
                    }
                    else if (estado == "Inativo")
                    {
                        estado = "ativar";
                        alterarestado = true;
                    }

                    DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer " + estado + " o modelo: " + nome + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        modeloTableAdapter.UpdateEstadoModeloQuery(alterarestado, indexModelos);
                        MessageBox.Show("Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReloadModelos();
                        dgvmodelos.ClearSelection();
                        indextable = -1;
                        indexModelos = -1;
                    }
                }
            }
            else if (tabindex == 3)
            {
                if (indexTipologias != -1)
                {
                    var nome = dgvTipologias.Rows[indextable].Cells[2].Value.ToString();
                    var estado = dgvTipologias.Rows[indextable].Cells[3].Value.ToString();
                    var alterarestado = true;

                    if (estado == "Ativo")
                    {
                        estado = "desativar";
                        alterarestado = false;
                    }
                    else if (estado == "Inativo")
                    {
                        estado = "ativar";
                        alterarestado = true;
                    }

                    DialogResult dialogResult = MessageBox.Show("Tem a certeza que quer " + estado + " a tipologia: " + nome + "?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        tipologiaTableAdapter.UpdateEstadoTipologiaQuery(alterarestado, indexTipologias);
                        MessageBox.Show("Alterado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReloadTipologias();
                        dgvTipologias.ClearSelection();
                        indextable = -1;
                        indexTipologias = -1;
                    }
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarMenu();
        }

        private void activarDesactivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivarDesactivarMenu();
        }

        private void ativarDesativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivarDesactivarMenu();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditarMenu();
        }
    }
}
