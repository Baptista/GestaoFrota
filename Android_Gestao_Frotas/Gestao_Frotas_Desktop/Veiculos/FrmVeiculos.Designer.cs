namespace Gestao_Frotas_Desktop
{
    partial class frmVeiculos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVeiculos));
            this.lbldesc = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activarDesactivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabveiculos = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgveiculos = new System.Windows.Forms.DataGridView();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ativarDesativarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvmarcas = new System.Windows.Forms.DataGridView();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvmodelos = new System.Windows.Forms.DataGridView();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvTipologias = new System.Windows.Forms.DataGridView();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.spListaVeiculosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaVeiculosTA = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spListaVeiculosTableAdapter();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.spListaMarcasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaMarcasTA = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spListaMarcasTableAdapter();
            this.spListaTipologiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaTipologiaTA = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spListaTipologiaTableAdapter();
            this.listaModelosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listaModelosTA = new Gestao_Frotas_Desktop.DataSet1TableAdapters.ListaModelosTableAdapter();
            this.veiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.VeiculoTableAdapter();
            this.marcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marcaTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.MarcaTableAdapter();
            this.modeloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modeloTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.ModeloTableAdapter();
            this.tipologiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipologiaTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TipologiaTableAdapter();
            this.danos_VeiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.danos_VeiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Danos_VeiculoTableAdapter();
            this.danos_Veiculo_ComprovativoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.danos_Veiculo_ComprovativoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Danos_Veiculo_ComprovativoTableAdapter();
            this.menuStrip1.SuspendLayout();
            this.tabveiculos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgveiculos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmarcas)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmodelos)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipologias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaVeiculosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaMarcasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaTipologiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaModelosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeloBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipologiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_VeiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_Veiculo_ComprovativoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbldesc
            // 
            this.lbldesc.AutoSize = true;
            this.lbldesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldesc.ForeColor = System.Drawing.Color.White;
            this.lbldesc.Location = new System.Drawing.Point(147, 70);
            this.lbldesc.Name = "lbldesc";
            this.lbldesc.Size = new System.Drawing.Size(102, 25);
            this.lbldesc.TabIndex = 6;
            this.lbldesc.Text = "Veículos";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.activarDesactivarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.add__3_;
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.adicionarToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.writing;
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // activarDesactivarToolStripMenuItem
            // 
            this.activarDesactivarToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.alarm;
            this.activarDesactivarToolStripMenuItem.Name = "activarDesactivarToolStripMenuItem";
            this.activarDesactivarToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.activarDesactivarToolStripMenuItem.Text = "Activar/Desactivar";
            this.activarDesactivarToolStripMenuItem.Click += new System.EventHandler(this.activarDesactivarToolStripMenuItem_Click);
            // 
            // tabveiculos
            // 
            this.tabveiculos.Controls.Add(this.tabPage1);
            this.tabveiculos.Controls.Add(this.tabPage2);
            this.tabveiculos.Controls.Add(this.tabPage3);
            this.tabveiculos.Controls.Add(this.tabPage4);
            this.tabveiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabveiculos.Location = new System.Drawing.Point(12, 152);
            this.tabveiculos.Name = "tabveiculos";
            this.tabveiculos.SelectedIndex = 0;
            this.tabveiculos.Size = new System.Drawing.Size(776, 286);
            this.tabveiculos.TabIndex = 8;
            this.tabveiculos.SelectedIndexChanged += new System.EventHandler(this.tabveiculos_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.tabPage1.Controls.Add(this.dgveiculos);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 257);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Veículos";
            // 
            // dgveiculos
            // 
            this.dgveiculos.AllowUserToAddRows = false;
            this.dgveiculos.AllowUserToDeleteRows = false;
            this.dgveiculos.AllowUserToResizeColumns = false;
            this.dgveiculos.AllowUserToResizeRows = false;
            this.dgveiculos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgveiculos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgveiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgveiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column17,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column6});
            this.dgveiculos.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgveiculos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgveiculos.Location = new System.Drawing.Point(3, 3);
            this.dgveiculos.Name = "dgveiculos";
            this.dgveiculos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgveiculos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgveiculos.RowHeadersVisible = false;
            this.dgveiculos.Size = new System.Drawing.Size(762, 251);
            this.dgveiculos.TabIndex = 0;
            this.dgveiculos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgveiculos_CellClick);
            // 
            // Column17
            // 
            this.Column17.HeaderText = "idveiculo";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Foto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Veículo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 240;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Matricula";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Owner";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Combustivel";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Estado";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem1,
            this.ativarDesativarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 48);
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.editarToolStripMenuItem1.Text = "Editar";
            this.editarToolStripMenuItem1.Click += new System.EventHandler(this.editarToolStripMenuItem1_Click);
            // 
            // ativarDesativarToolStripMenuItem
            // 
            this.ativarDesativarToolStripMenuItem.Name = "ativarDesativarToolStripMenuItem";
            this.ativarDesativarToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.ativarDesativarToolStripMenuItem.Text = "Activar/Desactivar";
            this.ativarDesativarToolStripMenuItem.Click += new System.EventHandler(this.ativarDesativarToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.tabPage2.Controls.Add(this.dgvmarcas);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Marcas";
            // 
            // dgvmarcas
            // 
            this.dgvmarcas.AllowUserToAddRows = false;
            this.dgvmarcas.AllowUserToDeleteRows = false;
            this.dgvmarcas.AllowUserToResizeColumns = false;
            this.dgvmarcas.AllowUserToResizeRows = false;
            this.dgvmarcas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dgvmarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmarcas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column18,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvmarcas.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvmarcas.Location = new System.Drawing.Point(3, 3);
            this.dgvmarcas.Name = "dgvmarcas";
            this.dgvmarcas.ReadOnly = true;
            this.dgvmarcas.RowHeadersVisible = false;
            this.dgvmarcas.Size = new System.Drawing.Size(762, 251);
            this.dgvmarcas.TabIndex = 0;
            this.dgvmarcas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvmarcas_CellClick);
            // 
            // Column18
            // 
            this.Column18.HeaderText = "IdMarca";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Marca";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 550;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Estado";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.tabPage3.Controls.Add(this.dgvmodelos);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 257);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Modelos";
            // 
            // dgvmodelos
            // 
            this.dgvmodelos.AllowUserToAddRows = false;
            this.dgvmodelos.AllowUserToDeleteRows = false;
            this.dgvmodelos.AllowUserToResizeColumns = false;
            this.dgvmodelos.AllowUserToResizeRows = false;
            this.dgvmodelos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dgvmodelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmodelos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column19,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgvmodelos.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvmodelos.Location = new System.Drawing.Point(3, 3);
            this.dgvmodelos.Name = "dgvmodelos";
            this.dgvmodelos.ReadOnly = true;
            this.dgvmodelos.RowHeadersVisible = false;
            this.dgvmodelos.Size = new System.Drawing.Size(762, 251);
            this.dgvmodelos.TabIndex = 0;
            this.dgvmodelos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvmodelos_CellClick);
            // 
            // Column19
            // 
            this.Column19.HeaderText = "IdModelo";
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            this.Column19.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column10.Width = 80;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Modelo";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 470;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Combustivel";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Estado";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.tabPage4.Controls.Add(this.dgvTipologias);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(768, 257);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tipologias";
            // 
            // dgvTipologias
            // 
            this.dgvTipologias.AllowUserToAddRows = false;
            this.dgvTipologias.AllowUserToDeleteRows = false;
            this.dgvTipologias.AllowUserToResizeColumns = false;
            this.dgvTipologias.AllowUserToResizeRows = false;
            this.dgvTipologias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dgvTipologias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipologias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column20,
            this.Column14,
            this.Column15,
            this.Column16});
            this.dgvTipologias.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvTipologias.Location = new System.Drawing.Point(3, 3);
            this.dgvTipologias.Name = "dgvTipologias";
            this.dgvTipologias.ReadOnly = true;
            this.dgvTipologias.RowHeadersVisible = false;
            this.dgvTipologias.Size = new System.Drawing.Size(762, 251);
            this.dgvTipologias.TabIndex = 0;
            this.dgvTipologias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipologias_CellClick);
            // 
            // Column20
            // 
            this.Column20.HeaderText = "IdTipologia";
            this.Column20.Name = "Column20";
            this.Column20.ReadOnly = true;
            this.Column20.Visible = false;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column14.Width = 80;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Tipologia";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 550;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Estado";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.logo_gestao_frotas;
            this.pictureBox1.Location = new System.Drawing.Point(12, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spListaVeiculosBindingSource
            // 
            this.spListaVeiculosBindingSource.DataMember = "spListaVeiculos";
            this.spListaVeiculosBindingSource.DataSource = this.dataSet1;
            // 
            // spListaVeiculosTA
            // 
            this.spListaVeiculosTA.ClearBeforeFill = true;
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
            // spListaMarcasBindingSource
            // 
            this.spListaMarcasBindingSource.DataMember = "spListaMarcas";
            this.spListaMarcasBindingSource.DataSource = this.dataSet1;
            // 
            // spListaMarcasTA
            // 
            this.spListaMarcasTA.ClearBeforeFill = true;
            // 
            // spListaTipologiaBindingSource
            // 
            this.spListaTipologiaBindingSource.DataMember = "spListaTipologia";
            this.spListaTipologiaBindingSource.DataSource = this.dataSet1;
            // 
            // spListaTipologiaTA
            // 
            this.spListaTipologiaTA.ClearBeforeFill = true;
            // 
            // listaModelosBindingSource
            // 
            this.listaModelosBindingSource.DataMember = "ListaModelos";
            this.listaModelosBindingSource.DataSource = this.dataSet1;
            // 
            // listaModelosTA
            // 
            this.listaModelosTA.ClearBeforeFill = true;
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
            // marcaBindingSource
            // 
            this.marcaBindingSource.DataMember = "Marca";
            this.marcaBindingSource.DataSource = this.dataSet1;
            // 
            // marcaTableAdapter
            // 
            this.marcaTableAdapter.ClearBeforeFill = true;
            // 
            // modeloBindingSource
            // 
            this.modeloBindingSource.DataMember = "Modelo";
            this.modeloBindingSource.DataSource = this.dataSet1;
            // 
            // modeloTableAdapter
            // 
            this.modeloTableAdapter.ClearBeforeFill = true;
            // 
            // tipologiaBindingSource
            // 
            this.tipologiaBindingSource.DataMember = "Tipologia";
            this.tipologiaBindingSource.DataSource = this.dataSet1;
            // 
            // tipologiaTableAdapter
            // 
            this.tipologiaTableAdapter.ClearBeforeFill = true;
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
            // frmVeiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(808, 458);
            this.Controls.Add(this.tabveiculos);
            this.Controls.Add(this.lbldesc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVeiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veiculos";
            this.Load += new System.EventHandler(this.FrmVeiculos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabveiculos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgveiculos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmarcas)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmodelos)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipologias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaVeiculosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaMarcasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaTipologiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaModelosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeloBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipologiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_VeiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_Veiculo_ComprovativoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbldesc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarDesactivarToolStripMenuItem;
        private System.Windows.Forms.TabControl tabveiculos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgveiculos;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource spListaVeiculosBindingSource;
        private DataSet1TableAdapters.spListaVeiculosTableAdapter spListaVeiculosTA;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dgvmarcas;
        private System.Windows.Forms.DataGridView dgvmodelos;
        private System.Windows.Forms.DataGridView dgvTipologias;
        private System.Windows.Forms.BindingSource spListaMarcasBindingSource;
        private DataSet1TableAdapters.spListaMarcasTableAdapter spListaMarcasTA;
        private System.Windows.Forms.BindingSource spListaTipologiaBindingSource;
        private DataSet1TableAdapters.spListaTipologiaTableAdapter spListaTipologiaTA;
        private System.Windows.Forms.BindingSource listaModelosBindingSource;
        private DataSet1TableAdapters.ListaModelosTableAdapter listaModelosTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewImageColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewImageColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewImageColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.BindingSource veiculoBindingSource;
        private DataSet1TableAdapters.VeiculoTableAdapter veiculoTableAdapter;
        private System.Windows.Forms.BindingSource marcaBindingSource;
        private DataSet1TableAdapters.MarcaTableAdapter marcaTableAdapter;
        private System.Windows.Forms.BindingSource modeloBindingSource;
        private DataSet1TableAdapters.ModeloTableAdapter modeloTableAdapter;
        private System.Windows.Forms.BindingSource tipologiaBindingSource;
        private DataSet1TableAdapters.TipologiaTableAdapter tipologiaTableAdapter;
        private System.Windows.Forms.BindingSource danos_VeiculoBindingSource;
        private DataSet1TableAdapters.Danos_VeiculoTableAdapter danos_VeiculoTableAdapter;
        private System.Windows.Forms.BindingSource danos_Veiculo_ComprovativoBindingSource;
        private DataSet1TableAdapters.Danos_Veiculo_ComprovativoTableAdapter danos_Veiculo_ComprovativoTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ativarDesativarToolStripMenuItem;
    }
}