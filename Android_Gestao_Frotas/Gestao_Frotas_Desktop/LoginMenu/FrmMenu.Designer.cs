namespace Gestao_Frotas_Desktop
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novoPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porAprovarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porDisponíbilizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.históricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipologiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.perfisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definiçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvpedidos = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aprovarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponibilizarVeículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.spListaPedidoMarcacoesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaPedidoMarcacoesTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spListaPedidoMarcacoesTableAdapter();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.pedido_Marcacao_HistoricoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pedido_Marcacao_HistoricoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter();
            this.justificacao_Pedido_MarcacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.justificacao_Pedido_MarcacaoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Justificacao_Pedido_MarcacaoTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpedidos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaPedidoMarcacoesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.justificacao_Pedido_MarcacaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoPedidoToolStripMenuItem,
            this.marcaçõesToolStripMenuItem,
            this.veículosToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.utilizadoresToolStripMenuItem,
            this.definiçõesToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novoPedidoToolStripMenuItem
            // 
            this.novoPedidoToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.icon__1_;
            this.novoPedidoToolStripMenuItem.Name = "novoPedidoToolStripMenuItem";
            this.novoPedidoToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.novoPedidoToolStripMenuItem.Text = "Novo Pedido";
            this.novoPedidoToolStripMenuItem.Click += new System.EventHandler(this.novoPedidoToolStripMenuItem_Click);
            // 
            // marcaçõesToolStripMenuItem
            // 
            this.marcaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porAprovarToolStripMenuItem,
            this.porDisponíbilizarToolStripMenuItem,
            this.emCursoToolStripMenuItem,
            this.históricoToolStripMenuItem});
            this.marcaçõesToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.appointment;
            this.marcaçõesToolStripMenuItem.Name = "marcaçõesToolStripMenuItem";
            this.marcaçõesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.marcaçõesToolStripMenuItem.Text = "Marcações";
            // 
            // porAprovarToolStripMenuItem
            // 
            this.porAprovarToolStripMenuItem.Name = "porAprovarToolStripMenuItem";
            this.porAprovarToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.porAprovarToolStripMenuItem.Text = "Por Aprovar";
            this.porAprovarToolStripMenuItem.Click += new System.EventHandler(this.porAprovarToolStripMenuItem_Click);
            // 
            // porDisponíbilizarToolStripMenuItem
            // 
            this.porDisponíbilizarToolStripMenuItem.Name = "porDisponíbilizarToolStripMenuItem";
            this.porDisponíbilizarToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.porDisponíbilizarToolStripMenuItem.Text = "Por Disponíbilizar";
            this.porDisponíbilizarToolStripMenuItem.Click += new System.EventHandler(this.porDisponíbilizarToolStripMenuItem_Click);
            // 
            // emCursoToolStripMenuItem
            // 
            this.emCursoToolStripMenuItem.Name = "emCursoToolStripMenuItem";
            this.emCursoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.emCursoToolStripMenuItem.Text = "Em Curso";
            this.emCursoToolStripMenuItem.Click += new System.EventHandler(this.emCursoToolStripMenuItem_Click);
            // 
            // históricoToolStripMenuItem
            // 
            this.históricoToolStripMenuItem.Name = "históricoToolStripMenuItem";
            this.históricoToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.históricoToolStripMenuItem.Text = "Histórico";
            this.históricoToolStripMenuItem.Click += new System.EventHandler(this.históricoToolStripMenuItem_Click);
            // 
            // veículosToolStripMenuItem
            // 
            this.veículosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.veículosToolStripMenuItem1,
            this.marcasToolStripMenuItem,
            this.modelosToolStripMenuItem,
            this.tipologiasToolStripMenuItem});
            this.veículosToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.car__3_;
            this.veículosToolStripMenuItem.Name = "veículosToolStripMenuItem";
            this.veículosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.veículosToolStripMenuItem.Text = "Veículos";
            // 
            // veículosToolStripMenuItem1
            // 
            this.veículosToolStripMenuItem1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.car__4_;
            this.veículosToolStripMenuItem1.Name = "veículosToolStripMenuItem1";
            this.veículosToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.veículosToolStripMenuItem1.Text = "Veículos";
            this.veículosToolStripMenuItem1.Click += new System.EventHandler(this.veículosToolStripMenuItem1_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.icon__1_;
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.marcasToolStripMenuItem.Text = "Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // modelosToolStripMenuItem
            // 
            this.modelosToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.car_front;
            this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            this.modelosToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.modelosToolStripMenuItem.Text = "Modelos";
            this.modelosToolStripMenuItem.Click += new System.EventHandler(this.modelosToolStripMenuItem_Click);
            // 
            // tipologiasToolStripMenuItem
            // 
            this.tipologiasToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.key_silhouette_security_tool_interface_symbol_of_password;
            this.tipologiasToolStripMenuItem.Name = "tipologiasToolStripMenuItem";
            this.tipologiasToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.tipologiasToolStripMenuItem.Text = "Tipologias";
            this.tipologiasToolStripMenuItem.Click += new System.EventHandler(this.tipologiasToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.magnifier;
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            this.relatóriosToolStripMenuItem.Click += new System.EventHandler(this.relatóriosToolStripMenuItem_Click);
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilizadoresToolStripMenuItem1,
            this.perfisToolStripMenuItem});
            this.utilizadoresToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.user;
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.utilizadoresToolStripMenuItem.Text = "Utilizadores";
            // 
            // utilizadoresToolStripMenuItem1
            // 
            this.utilizadoresToolStripMenuItem1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.user;
            this.utilizadoresToolStripMenuItem1.Name = "utilizadoresToolStripMenuItem1";
            this.utilizadoresToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.utilizadoresToolStripMenuItem1.Text = "Utilizadores";
            this.utilizadoresToolStripMenuItem1.Click += new System.EventHandler(this.utilizadoresToolStripMenuItem1_Click);
            // 
            // perfisToolStripMenuItem
            // 
            this.perfisToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.paintbrush;
            this.perfisToolStripMenuItem.Name = "perfisToolStripMenuItem";
            this.perfisToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.perfisToolStripMenuItem.Text = "Perfis";
            // 
            // definiçõesToolStripMenuItem
            // 
            this.definiçõesToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.menu;
            this.definiçõesToolStripMenuItem.Name = "definiçõesToolStripMenuItem";
            this.definiçõesToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.definiçõesToolStripMenuItem.Text = "Definições";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.logout;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(162, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pedidos de Marcação";
            // 
            // dgvpedidos
            // 
            this.dgvpedidos.AllowUserToAddRows = false;
            this.dgvpedidos.AllowUserToDeleteRows = false;
            this.dgvpedidos.AllowUserToResizeColumns = false;
            this.dgvpedidos.AllowUserToResizeRows = false;
            this.dgvpedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dgvpedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7});
            this.dgvpedidos.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvpedidos.Location = new System.Drawing.Point(18, 156);
            this.dgvpedidos.Name = "dgvpedidos";
            this.dgvpedidos.ReadOnly = true;
            this.dgvpedidos.RowHeadersVisible = false;
            this.dgvpedidos.Size = new System.Drawing.Size(770, 282);
            this.dgvpedidos.TabIndex = 3;
            this.dgvpedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpedidos_CellClick);
            this.dgvpedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpedidos_CellContentClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "idpedidomarcacaohistorico";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tipo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Veículo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Owner";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Início";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Fim";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "tipotype";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aprovarPedidoToolStripMenuItem,
            this.cancelarPedidoToolStripMenuItem,
            this.terminarPedidoToolStripMenuItem,
            this.disponibilizarVeículoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 92);
            // 
            // aprovarPedidoToolStripMenuItem
            // 
            this.aprovarPedidoToolStripMenuItem.Name = "aprovarPedidoToolStripMenuItem";
            this.aprovarPedidoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.aprovarPedidoToolStripMenuItem.Text = "Aprovar Pedido";
            this.aprovarPedidoToolStripMenuItem.Click += new System.EventHandler(this.aprovarPedidoToolStripMenuItem_Click);
            // 
            // cancelarPedidoToolStripMenuItem
            // 
            this.cancelarPedidoToolStripMenuItem.Name = "cancelarPedidoToolStripMenuItem";
            this.cancelarPedidoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cancelarPedidoToolStripMenuItem.Text = "Cancelar Pedido";
            this.cancelarPedidoToolStripMenuItem.Click += new System.EventHandler(this.cancelarPedidoToolStripMenuItem_Click);
            // 
            // terminarPedidoToolStripMenuItem
            // 
            this.terminarPedidoToolStripMenuItem.Name = "terminarPedidoToolStripMenuItem";
            this.terminarPedidoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.terminarPedidoToolStripMenuItem.Text = "Terminar Pedido";
            this.terminarPedidoToolStripMenuItem.Click += new System.EventHandler(this.terminarPedidoToolStripMenuItem_Click);
            // 
            // disponibilizarVeículoToolStripMenuItem
            // 
            this.disponibilizarVeículoToolStripMenuItem.Name = "disponibilizarVeículoToolStripMenuItem";
            this.disponibilizarVeículoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.disponibilizarVeículoToolStripMenuItem.Text = "Disponibilizar Veículo";
            this.disponibilizarVeículoToolStripMenuItem.Click += new System.EventHandler(this.disponibilizarVeículoToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.logo_gestao_frotas;
            this.pictureBox1.Location = new System.Drawing.Point(18, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(215, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Carregando Dados...";
            this.label2.Visible = false;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spListaPedidoMarcacoesBindingSource
            // 
            this.spListaPedidoMarcacoesBindingSource.DataMember = "spListaPedidoMarcacoes";
            this.spListaPedidoMarcacoesBindingSource.DataSource = this.dataSet1;
            // 
            // spListaPedidoMarcacoesTableAdapter
            // 
            this.spListaPedidoMarcacoesTableAdapter.ClearBeforeFill = true;
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
            // pedido_Marcacao_HistoricoBindingSource
            // 
            this.pedido_Marcacao_HistoricoBindingSource.DataMember = "Pedido_Marcacao_Historico";
            this.pedido_Marcacao_HistoricoBindingSource.DataSource = this.dataSet1;
            // 
            // pedido_Marcacao_HistoricoTableAdapter
            // 
            this.pedido_Marcacao_HistoricoTableAdapter.ClearBeforeFill = true;
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
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(808, 458);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvpedidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenu_FormClosing);
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpedidos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaPedidoMarcacoesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.justificacao_Pedido_MarcacaoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaçõesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem veículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem definiçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porAprovarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porDisponíbilizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem históricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veículosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipologiasToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvpedidos;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource spListaPedidoMarcacoesBindingSource;
        private DataSet1TableAdapters.spListaPedidoMarcacoesTableAdapter spListaPedidoMarcacoesTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem perfisToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aprovarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponibilizarVeículoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.BindingSource pedido_Marcacao_HistoricoBindingSource;
        private DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter pedido_Marcacao_HistoricoTableAdapter;
        private System.Windows.Forms.BindingSource justificacao_Pedido_MarcacaoBindingSource;
        private DataSet1TableAdapters.Justificacao_Pedido_MarcacaoTableAdapter justificacao_Pedido_MarcacaoTableAdapter;
    }
}