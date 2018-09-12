namespace Gestao_Frotas_Desktop.NovoPedido
{
    partial class FrmNovoPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovoPedido));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDataInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpDataFim = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraFim = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelkmsprivate = new System.Windows.Forms.Label();
            this.labelprivateowner = new System.Windows.Forms.Label();
            this.labelprivateveiculo = new System.Windows.Forms.Label();
            this.pbprivateimage = new System.Windows.Forms.PictureBox();
            this.bttVehicle = new System.Windows.Forms.Button();
            this.BttAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbstate = new System.Windows.Forms.CheckBox();
            this.gbFim = new System.Windows.Forms.GroupBox();
            this.gbInicio = new System.Windows.Forms.GroupBox();
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.spDetalheVeiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spDetalheVeiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spDetalheVeiculoTableAdapter();
            this.pedido_Marcacao_HistoricoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pedido_Marcacao_HistoricoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter();
            this.pedido_MarcacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pedido_MarcacaoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Pedido_MarcacaoTableAdapter();
            this.justificacao_Pedido_MarcacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.justificacao_Pedido_MarcacaoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Justificacao_Pedido_MarcacaoTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbprivateimage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbFim.SuspendLayout();
            this.gbInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDetalheVeiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_MarcacaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.justificacao_Pedido_MarcacaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(156, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Novo Pedido";
            // 
            // dtpDataInicio
            // 
            this.dtpDataInicio.Checked = false;
            this.dtpDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicio.Location = new System.Drawing.Point(6, 36);
            this.dtpDataInicio.Name = "dtpDataInicio";
            this.dtpDataInicio.Size = new System.Drawing.Size(185, 26);
            this.dtpDataInicio.TabIndex = 1;
            this.dtpDataInicio.ValueChanged += new System.EventHandler(this.dtpDataInicio_ValueChanged);
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "HH:mm:ss";
            this.dtpHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.Location = new System.Drawing.Point(197, 36);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(201, 26);
            this.dtpHoraInicio.TabIndex = 3;
            this.dtpHoraInicio.ValueChanged += new System.EventHandler(this.dtpHoraInicio_ValueChanged);
            // 
            // dtpDataFim
            // 
            this.dtpDataFim.Checked = false;
            this.dtpDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFim.Location = new System.Drawing.Point(6, 44);
            this.dtpDataFim.Name = "dtpDataFim";
            this.dtpDataFim.Size = new System.Drawing.Size(185, 26);
            this.dtpDataFim.TabIndex = 5;
            this.dtpDataFim.ValueChanged += new System.EventHandler(this.dtpDataFim_ValueChanged);
            // 
            // dtpHoraFim
            // 
            this.dtpHoraFim.CustomFormat = "HH:mm:ss";
            this.dtpHoraFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraFim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFim.Location = new System.Drawing.Point(197, 44);
            this.dtpHoraFim.Name = "dtpHoraFim";
            this.dtpHoraFim.ShowUpDown = true;
            this.dtpHoraFim.Size = new System.Drawing.Size(201, 26);
            this.dtpHoraFim.TabIndex = 6;
            this.dtpHoraFim.ValueChanged += new System.EventHandler(this.dtpHoraFim_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelkmsprivate);
            this.groupBox1.Controls.Add(this.labelprivateowner);
            this.groupBox1.Controls.Add(this.labelprivateveiculo);
            this.groupBox1.Controls.Add(this.pbprivateimage);
            this.groupBox1.Controls.Add(this.bttVehicle);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(31, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 188);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veiculo";
            // 
            // labelkmsprivate
            // 
            this.labelkmsprivate.Location = new System.Drawing.Point(19, 118);
            this.labelkmsprivate.Name = "labelkmsprivate";
            this.labelkmsprivate.Size = new System.Drawing.Size(379, 55);
            this.labelkmsprivate.TabIndex = 4;
            this.labelkmsprivate.Text = "Kms Contracto Kms Iniciais";
            this.labelkmsprivate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelkmsprivate.Visible = false;
            // 
            // labelprivateowner
            // 
            this.labelprivateowner.Location = new System.Drawing.Point(127, 83);
            this.labelprivateowner.Name = "labelprivateowner";
            this.labelprivateowner.Size = new System.Drawing.Size(271, 26);
            this.labelprivateowner.TabIndex = 3;
            this.labelprivateowner.Text = "Owner:";
            this.labelprivateowner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelprivateowner.Visible = false;
            // 
            // labelprivateveiculo
            // 
            this.labelprivateveiculo.Location = new System.Drawing.Point(127, 37);
            this.labelprivateveiculo.Name = "labelprivateveiculo";
            this.labelprivateveiculo.Size = new System.Drawing.Size(271, 43);
            this.labelprivateveiculo.TabIndex = 2;
            this.labelprivateveiculo.Text = "Veiculo";
            this.labelprivateveiculo.Visible = false;
            // 
            // pbprivateimage
            // 
            this.pbprivateimage.Image = global::Gestao_Frotas_Desktop.Properties.Resources.car_test;
            this.pbprivateimage.Location = new System.Drawing.Point(23, 37);
            this.pbprivateimage.Name = "pbprivateimage";
            this.pbprivateimage.Size = new System.Drawing.Size(98, 78);
            this.pbprivateimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbprivateimage.TabIndex = 1;
            this.pbprivateimage.TabStop = false;
            this.pbprivateimage.Visible = false;
            // 
            // bttVehicle
            // 
            this.bttVehicle.ForeColor = System.Drawing.Color.Black;
            this.bttVehicle.Location = new System.Drawing.Point(91, 71);
            this.bttVehicle.Name = "bttVehicle";
            this.bttVehicle.Size = new System.Drawing.Size(233, 44);
            this.bttVehicle.TabIndex = 0;
            this.bttVehicle.Text = "Escolher Veículo";
            this.bttVehicle.UseVisualStyleBackColor = true;
            this.bttVehicle.Click += new System.EventHandler(this.bttVehicle_Click);
            // 
            // BttAdd
            // 
            this.BttAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BttAdd.Location = new System.Drawing.Point(27, 563);
            this.BttAdd.Name = "BttAdd";
            this.BttAdd.Size = new System.Drawing.Size(421, 34);
            this.BttAdd.TabIndex = 8;
            this.BttAdd.Text = "Realizar Pedido";
            this.BttAdd.UseVisualStyleBackColor = true;
            this.BttAdd.Click += new System.EventHandler(this.BttAdd_ClickAsync);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.steering__2_;
            this.pictureBox1.Location = new System.Drawing.Point(95, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Gestao_Frotas_Desktop.Properties.Resources.steering__2_;
            this.pictureBox2.Location = new System.Drawing.Point(308, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(55, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // cbstate
            // 
            this.cbstate.AutoSize = true;
            this.cbstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbstate.ForeColor = System.Drawing.Color.White;
            this.cbstate.Location = new System.Drawing.Point(179, 208);
            this.cbstate.Name = "cbstate";
            this.cbstate.Size = new System.Drawing.Size(100, 24);
            this.cbstate.TabIndex = 11;
            this.cbstate.Text = "Continuo";
            this.cbstate.UseVisualStyleBackColor = true;
            this.cbstate.CheckedChanged += new System.EventHandler(this.cbstate_CheckedChanged);
            // 
            // gbFim
            // 
            this.gbFim.Controls.Add(this.dtpHoraFim);
            this.gbFim.Controls.Add(this.dtpDataFim);
            this.gbFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFim.ForeColor = System.Drawing.Color.White;
            this.gbFim.Location = new System.Drawing.Point(31, 238);
            this.gbFim.Name = "gbFim";
            this.gbFim.Size = new System.Drawing.Size(417, 100);
            this.gbFim.TabIndex = 12;
            this.gbFim.TabStop = false;
            this.gbFim.Text = "Data Fim";
            // 
            // gbInicio
            // 
            this.gbInicio.Controls.Add(this.dtpDataInicio);
            this.gbInicio.Controls.Add(this.dtpHoraInicio);
            this.gbInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInicio.ForeColor = System.Drawing.Color.White;
            this.gbInicio.Location = new System.Drawing.Point(31, 92);
            this.gbInicio.Name = "gbInicio";
            this.gbInicio.Size = new System.Drawing.Size(417, 97);
            this.gbInicio.TabIndex = 13;
            this.gbInicio.TabStop = false;
            this.gbInicio.Text = "Data Inicio";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CombustivelTableAdapter = null;
            this.tableAdapterManager.ConfiguracaoTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.Danos_Veiculo_ComprovativoTableAdapter = null;
            this.tableAdapterManager.Danos_VeiculoTableAdapter = null;
            this.tableAdapterManager.Estado_Pedido_MarcacaoTableAdapter = null;
            this.tableAdapterManager.Justificacao_Pedido_MarcacaoTableAdapter = null;
            this.tableAdapterManager.MarcaTableAdapter = null;
            this.tableAdapterManager.ModeloTableAdapter = null;
            this.tableAdapterManager.Pedido_Marcacao_HistoricoTableAdapter = null;
            this.tableAdapterManager.Pedido_MarcacaoTableAdapter = null;
            this.tableAdapterManager.Perfil_PermissaoTableAdapter = null;
            this.tableAdapterManager.PerfilTableAdapter = null;
            this.tableAdapterManager.PermissaoTableAdapter = null;
            this.tableAdapterManager.sysdiagramsTableAdapter = null;
            this.tableAdapterManager.Tipo_Justificacao_PedidoTableAdapter = null;
            this.tableAdapterManager.TipologiaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UtilizadorTableAdapter = null;
            this.tableAdapterManager.Veiculo_EntregaTableAdapter = null;
            this.tableAdapterManager.VeiculoTableAdapter = null;
            // 
            // spDetalheVeiculoBindingSource
            // 
            this.spDetalheVeiculoBindingSource.DataMember = "spDetalheVeiculo";
            this.spDetalheVeiculoBindingSource.DataSource = this.dataSet1;
            // 
            // spDetalheVeiculoTableAdapter
            // 
            this.spDetalheVeiculoTableAdapter.ClearBeforeFill = true;
            // 
            // pedido_Marcacao_HistoricoBindingSource
            // 
            this.pedido_Marcacao_HistoricoBindingSource.DataMember = "Pedido_Marcacao_Historico";
            this.pedido_Marcacao_HistoricoBindingSource.DataSource = this.dataSet1;
            // 
            // pedido_Marcacao_HistoricoTableAdapter
            // 
            this.pedido_Marcacao_HistoricoTableAdapter.ClearBeforeFill = true;
            // 
            // pedido_MarcacaoBindingSource
            // 
            this.pedido_MarcacaoBindingSource.DataMember = "Pedido_Marcacao";
            this.pedido_MarcacaoBindingSource.DataSource = this.dataSet1;
            // 
            // pedido_MarcacaoTableAdapter
            // 
            this.pedido_MarcacaoTableAdapter.ClearBeforeFill = true;
            // 
            // justificacao_Pedido_MarcacaoBindingSource
            // 
            this.justificacao_Pedido_MarcacaoBindingSource.DataMember = "Justificacao_Pedido_Marcacao";
            this.justificacao_Pedido_MarcacaoBindingSource.DataSource = this.dataSet1;
            // 
            // justificacao_Pedido_MarcacaoTableAdapter
            // 
            this.justificacao_Pedido_MarcacaoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmNovoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(474, 617);
            this.Controls.Add(this.gbInicio);
            this.Controls.Add(this.gbFim);
            this.Controls.Add(this.cbstate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BttAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNovoPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Pedido";
            this.Load += new System.EventHandler(this.FrmNovoPedido_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbprivateimage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbFim.ResumeLayout(false);
            this.gbInicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDetalheVeiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_MarcacaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.justificacao_Pedido_MarcacaoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDataInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpDataFim;
        private System.Windows.Forms.DateTimePicker dtpHoraFim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttVehicle;
        private System.Windows.Forms.Button BttAdd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox cbstate;
        private System.Windows.Forms.GroupBox gbFim;
        private System.Windows.Forms.GroupBox gbInicio;
        private System.Windows.Forms.Label labelkmsprivate;
        private System.Windows.Forms.Label labelprivateowner;
        private System.Windows.Forms.Label labelprivateveiculo;
        private System.Windows.Forms.PictureBox pbprivateimage;
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource spDetalheVeiculoBindingSource;
        private DataSet1TableAdapters.spDetalheVeiculoTableAdapter spDetalheVeiculoTableAdapter;
        private System.Windows.Forms.BindingSource pedido_Marcacao_HistoricoBindingSource;
        private DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter pedido_Marcacao_HistoricoTableAdapter;
        private System.Windows.Forms.BindingSource pedido_MarcacaoBindingSource;
        private DataSet1TableAdapters.Pedido_MarcacaoTableAdapter pedido_MarcacaoTableAdapter;
        private System.Windows.Forms.BindingSource justificacao_Pedido_MarcacaoBindingSource;
        private DataSet1TableAdapters.Justificacao_Pedido_MarcacaoTableAdapter justificacao_Pedido_MarcacaoTableAdapter;
    }
}