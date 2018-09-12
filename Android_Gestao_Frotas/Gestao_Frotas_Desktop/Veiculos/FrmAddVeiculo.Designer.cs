namespace Gestao_Frotas_Desktop
{
    partial class FrmAddVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddVeiculo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbmarca = new System.Windows.Forms.ComboBox();
            this.marcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.cbmodelo = new System.Windows.Forms.ComboBox();
            this.modeloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbtipologia = new System.Windows.Forms.ComboBox();
            this.tipologiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cbowner = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudkmscontrato = new System.Windows.Forms.NumericUpDown();
            this.bttadd = new System.Windows.Forms.Button();
            this.dgvdanos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadImagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.marcaTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.MarcaTableAdapter();
            this.modeloTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.ModeloTableAdapter();
            this.tipologiaTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TipologiaTableAdapter();
            this.nudkms = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.utilizadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.utilizadorTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.UtilizadorTableAdapter();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.txtmatricula = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.veiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.VeiculoTableAdapter();
            this.cbstate = new System.Windows.Forms.CheckBox();
            this.danos_VeiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.danos_VeiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Danos_VeiculoTableAdapter();
            this.danos_Veiculo_ComprovativoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.danos_Veiculo_ComprovativoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Danos_Veiculo_ComprovativoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.marcaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeloBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipologiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudkmscontrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudkms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_VeiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_Veiculo_ComprovativoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adicionar Veículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Modelo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipologia";
            // 
            // cbmarca
            // 
            this.cbmarca.DataSource = this.marcaBindingSource;
            this.cbmarca.DisplayMember = "Descricao";
            this.cbmarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmarca.FormattingEnabled = true;
            this.cbmarca.Location = new System.Drawing.Point(106, 92);
            this.cbmarca.Name = "cbmarca";
            this.cbmarca.Size = new System.Drawing.Size(247, 28);
            this.cbmarca.TabIndex = 4;
            this.cbmarca.ValueMember = "IdMarca";
            this.cbmarca.SelectedIndexChanged += new System.EventHandler(this.cbmarca_SelectedIndexChanged);
            // 
            // marcaBindingSource
            // 
            this.marcaBindingSource.DataMember = "Marca";
            this.marcaBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbmodelo
            // 
            this.cbmodelo.DataSource = this.modeloBindingSource;
            this.cbmodelo.DisplayMember = "Descricao";
            this.cbmodelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmodelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmodelo.FormattingEnabled = true;
            this.cbmodelo.Location = new System.Drawing.Point(106, 141);
            this.cbmodelo.Name = "cbmodelo";
            this.cbmodelo.Size = new System.Drawing.Size(247, 28);
            this.cbmodelo.TabIndex = 5;
            this.cbmodelo.ValueMember = "IdModelo";
            // 
            // modeloBindingSource
            // 
            this.modeloBindingSource.DataMember = "Modelo";
            this.modeloBindingSource.DataSource = this.dataSet1;
            // 
            // cbtipologia
            // 
            this.cbtipologia.DataSource = this.tipologiaBindingSource;
            this.cbtipologia.DisplayMember = "Descricao";
            this.cbtipologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbtipologia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbtipologia.FormattingEnabled = true;
            this.cbtipologia.Location = new System.Drawing.Point(106, 184);
            this.cbtipologia.Name = "cbtipologia";
            this.cbtipologia.Size = new System.Drawing.Size(247, 28);
            this.cbtipologia.TabIndex = 6;
            this.cbtipologia.ValueMember = "IdTipologia";
            // 
            // tipologiaBindingSource
            // 
            this.tipologiaBindingSource.DataMember = "Tipologia";
            this.tipologiaBindingSource.DataSource = this.dataSet1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(40, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Owner";
            // 
            // cbowner
            // 
            this.cbowner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbowner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbowner.FormattingEnabled = true;
            this.cbowner.Location = new System.Drawing.Point(106, 229);
            this.cbowner.Name = "cbowner";
            this.cbowner.Size = new System.Drawing.Size(247, 28);
            this.cbowner.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Matricula";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(233, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 40);
            this.label7.TabIndex = 11;
            this.label7.Text = "Kms\r\nContrato\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudkmscontrato
            // 
            this.nudkmscontrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudkmscontrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudkmscontrato.Location = new System.Drawing.Point(208, 414);
            this.nudkmscontrato.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudkmscontrato.Name = "nudkmscontrato";
            this.nudkmscontrato.Size = new System.Drawing.Size(133, 26);
            this.nudkmscontrato.TabIndex = 12;
            this.nudkmscontrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bttadd
            // 
            this.bttadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttadd.Location = new System.Drawing.Point(23, 466);
            this.bttadd.Name = "bttadd";
            this.bttadd.Size = new System.Drawing.Size(783, 28);
            this.bttadd.TabIndex = 13;
            this.bttadd.Text = "Adicionar Veículo";
            this.bttadd.UseVisualStyleBackColor = true;
            this.bttadd.Click += new System.EventHandler(this.bttadd_Click);
            // 
            // dgvdanos
            // 
            this.dgvdanos.AllowUserToAddRows = false;
            this.dgvdanos.AllowUserToDeleteRows = false;
            this.dgvdanos.AllowUserToResizeColumns = false;
            this.dgvdanos.AllowUserToResizeRows = false;
            this.dgvdanos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdanos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvdanos.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvdanos.Location = new System.Drawing.Point(399, 139);
            this.dgvdanos.Name = "dgvdanos";
            this.dgvdanos.ReadOnly = true;
            this.dgvdanos.RowHeadersVisible = false;
            this.dgvdanos.Size = new System.Drawing.Size(391, 301);
            this.dgvdanos.TabIndex = 14;
            this.dgvdanos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdanos_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IdDanoVeiculo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descrição";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 300;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Foto";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadImagemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 26);
            // 
            // downloadImagemToolStripMenuItem
            // 
            this.downloadImagemToolStripMenuItem.Name = "downloadImagemToolStripMenuItem";
            this.downloadImagemToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.downloadImagemToolStripMenuItem.Text = "Download Imagem";
            this.downloadImagemToolStripMenuItem.Click += new System.EventHandler(this.downloadImagemToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(564, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Danos";
            // 
            // button4
            // 
            this.button4.Image = global::Gestao_Frotas_Desktop.Properties.Resources.cancel_mark__1_;
            this.button4.Location = new System.Drawing.Point(652, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 49);
            this.button4.TabIndex = 18;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::Gestao_Frotas_Desktop.Properties.Resources.writing;
            this.button3.Location = new System.Drawing.Point(560, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 49);
            this.button3.TabIndex = 17;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Gestao_Frotas_Desktop.Properties.Resources.add__3_;
            this.button2.Location = new System.Drawing.Point(469, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 49);
            this.button2.TabIndex = 16;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // marcaTableAdapter
            // 
            this.marcaTableAdapter.ClearBeforeFill = true;
            // 
            // modeloTableAdapter
            // 
            this.modeloTableAdapter.ClearBeforeFill = true;
            // 
            // tipologiaTableAdapter
            // 
            this.tipologiaTableAdapter.ClearBeforeFill = true;
            // 
            // nudkms
            // 
            this.nudkms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudkms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudkms.Location = new System.Drawing.Point(42, 414);
            this.nudkms.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudkms.Name = "nudkms";
            this.nudkms.Size = new System.Drawing.Size(133, 26);
            this.nudkms.TabIndex = 19;
            this.nudkms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(83, 379);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Kms";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // utilizadorBindingSource
            // 
            this.utilizadorBindingSource.DataMember = "Utilizador";
            this.utilizadorBindingSource.DataSource = this.dataSet1;
            // 
            // utilizadorTableAdapter
            // 
            this.utilizadorTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CombustivelTableAdapter = null;
            this.tableAdapterManager.ConfiguracaoTableAdapter = null;
            this.tableAdapterManager.Danos_Veiculo_ComprovativoTableAdapter = null;
            this.tableAdapterManager.Danos_VeiculoTableAdapter = null;
            this.tableAdapterManager.Estado_Pedido_MarcacaoTableAdapter = null;
            this.tableAdapterManager.Justificacao_Pedido_MarcacaoTableAdapter = null;
            this.tableAdapterManager.MarcaTableAdapter = this.marcaTableAdapter;
            this.tableAdapterManager.ModeloTableAdapter = this.modeloTableAdapter;
            this.tableAdapterManager.Pedido_Marcacao_HistoricoTableAdapter = null;
            this.tableAdapterManager.Pedido_MarcacaoTableAdapter = null;
            this.tableAdapterManager.Perfil_PermissaoTableAdapter = null;
            this.tableAdapterManager.PerfilTableAdapter = null;
            this.tableAdapterManager.PermissaoTableAdapter = null;
            this.tableAdapterManager.sysdiagramsTableAdapter = null;
            this.tableAdapterManager.Tipo_Justificacao_PedidoTableAdapter = null;
            this.tableAdapterManager.TipologiaTableAdapter = this.tipologiaTableAdapter;
            this.tableAdapterManager.UpdateOrder = Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UtilizadorTableAdapter = this.utilizadorTableAdapter;
            this.tableAdapterManager.Veiculo_EntregaTableAdapter = null;
            this.tableAdapterManager.VeiculoTableAdapter = null;
            // 
            // txtmatricula
            // 
            this.txtmatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmatricula.Location = new System.Drawing.Point(106, 272);
            this.txtmatricula.Mask = "AA-AA-AA";
            this.txtmatricula.Name = "txtmatricula";
            this.txtmatricula.Size = new System.Drawing.Size(71, 26);
            this.txtmatricula.TabIndex = 21;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // veiculoBindingSource
            // 
            this.veiculoBindingSource.DataMember = "Veiculo";
            this.veiculoBindingSource.DataSource = this.dataSet1;
            // 
            // veiculoTableAdapter
            // 
            this.veiculoTableAdapter.ClearBeforeFill = true;
            // 
            // cbstate
            // 
            this.cbstate.AutoSize = true;
            this.cbstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbstate.ForeColor = System.Drawing.Color.White;
            this.cbstate.Location = new System.Drawing.Point(151, 326);
            this.cbstate.Name = "cbstate";
            this.cbstate.Size = new System.Drawing.Size(85, 24);
            this.cbstate.TabIndex = 22;
            this.cbstate.Text = "Estado";
            this.cbstate.UseVisualStyleBackColor = true;
            // 
            // danos_VeiculoBindingSource
            // 
            this.danos_VeiculoBindingSource.DataMember = "Danos_Veiculo";
            this.danos_VeiculoBindingSource.DataSource = this.dataSet1;
            // 
            // danos_VeiculoTableAdapter
            // 
            this.danos_VeiculoTableAdapter.ClearBeforeFill = true;
            // 
            // danos_Veiculo_ComprovativoBindingSource
            // 
            this.danos_Veiculo_ComprovativoBindingSource.DataMember = "Danos_Veiculo_Comprovativo";
            this.danos_Veiculo_ComprovativoBindingSource.DataSource = this.dataSet1;
            // 
            // danos_Veiculo_ComprovativoTableAdapter
            // 
            this.danos_Veiculo_ComprovativoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmAddVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(828, 514);
            this.Controls.Add(this.cbstate);
            this.Controls.Add(this.txtmatricula);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudkms);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvdanos);
            this.Controls.Add(this.bttadd);
            this.Controls.Add(this.nudkmscontrato);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbowner);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbtipologia);
            this.Controls.Add(this.cbmodelo);
            this.Controls.Add(this.cbmarca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddVeiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Veiculo";
            this.Load += new System.EventHandler(this.FrmAddVeiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.marcaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeloBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipologiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudkmscontrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudkms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_VeiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_Veiculo_ComprovativoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbmarca;
        private System.Windows.Forms.ComboBox cbmodelo;
        private System.Windows.Forms.ComboBox cbtipologia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbowner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudkmscontrato;
        private System.Windows.Forms.Button bttadd;
        private System.Windows.Forms.DataGridView dgvdanos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource marcaBindingSource;
        private DataSet1TableAdapters.MarcaTableAdapter marcaTableAdapter;
        private System.Windows.Forms.BindingSource modeloBindingSource;
        private DataSet1TableAdapters.ModeloTableAdapter modeloTableAdapter;
        private System.Windows.Forms.BindingSource tipologiaBindingSource;
        private DataSet1TableAdapters.TipologiaTableAdapter tipologiaTableAdapter;
        private System.Windows.Forms.NumericUpDown nudkms;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource utilizadorBindingSource;
        private DataSet1TableAdapters.UtilizadorTableAdapter utilizadorTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.MaskedTextBox txtmatricula;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem downloadImagemToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource veiculoBindingSource;
        private DataSet1TableAdapters.VeiculoTableAdapter veiculoTableAdapter;
        private System.Windows.Forms.CheckBox cbstate;
        private System.Windows.Forms.BindingSource danos_VeiculoBindingSource;
        private DataSet1TableAdapters.Danos_VeiculoTableAdapter danos_VeiculoTableAdapter;
        private System.Windows.Forms.BindingSource danos_Veiculo_ComprovativoBindingSource;
        private DataSet1TableAdapters.Danos_Veiculo_ComprovativoTableAdapter danos_Veiculo_ComprovativoTableAdapter;
    }
}