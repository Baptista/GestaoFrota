namespace Gestao_Frotas_Desktop.Marcacoes
{
    partial class FrmMarcacoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarcacoes));
            this.dgvpedidos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aprovarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disponibilizarPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbutilizador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbveiculo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbestado = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpinicio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpfim = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.gbdatas = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.spListaPedidoMarcacoesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaPedidoMarcacoesTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spListaPedidoMarcacoesTableAdapter();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.utilizadorTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.UtilizadorTableAdapter();
            this.veiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.VeiculoTableAdapter();
            this.utilizadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaVeiculoDescricaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaVeiculoDescricaoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spListaVeiculoDescricaoTableAdapter();
            this.spListaVeiculosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaVeiculosTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spListaVeiculosTableAdapter();
            this.spListaPedidoMarcacoesExtraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spListaPedidoMarcacoesExtraTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spListaPedidoMarcacoesExtraTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.bttclean = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pedido_Marcacao_HistoricoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pedido_Marcacao_HistoricoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter();
            this.justificacao_Pedido_MarcacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.justificacao_Pedido_MarcacaoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Justificacao_Pedido_MarcacaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpedidos)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.gbdatas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaPedidoMarcacoesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaVeiculoDescricaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaVeiculosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaPedidoMarcacoesExtraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.justificacao_Pedido_MarcacaoBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvpedidos.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvpedidos.Location = new System.Drawing.Point(12, 205);
            this.dgvpedidos.Name = "dgvpedidos";
            this.dgvpedidos.ReadOnly = true;
            this.dgvpedidos.RowHeadersVisible = false;
            this.dgvpedidos.Size = new System.Drawing.Size(776, 241);
            this.dgvpedidos.TabIndex = 0;
            this.dgvpedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpedidos_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "idpedidomarcacaohistorico";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "tipo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column3.HeaderText = "Veículo";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Owner";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Início";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Fim";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "tipotype";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aprovarPedidoToolStripMenuItem,
            this.cancelarPedidoToolStripMenuItem,
            this.terminarPedidoToolStripMenuItem,
            this.disponibilizarPedidoToolStripMenuItem});
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
            // disponibilizarPedidoToolStripMenuItem
            // 
            this.disponibilizarPedidoToolStripMenuItem.Name = "disponibilizarPedidoToolStripMenuItem";
            this.disponibilizarPedidoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.disponibilizarPedidoToolStripMenuItem.Text = "Disponibilizar Veículo";
            this.disponibilizarPedidoToolStripMenuItem.Click += new System.EventHandler(this.disponibilizarPedidoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(145, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista de Marcações";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(236, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Utilizador";
            // 
            // cbutilizador
            // 
            this.cbutilizador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbutilizador.FormattingEnabled = true;
            this.cbutilizador.Location = new System.Drawing.Point(149, 86);
            this.cbutilizador.Name = "cbutilizador";
            this.cbutilizador.Size = new System.Drawing.Size(254, 21);
            this.cbutilizador.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(579, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Veículo";
            // 
            // cbveiculo
            // 
            this.cbveiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbveiculo.FormattingEnabled = true;
            this.cbveiculo.Location = new System.Drawing.Point(409, 86);
            this.cbveiculo.Name = "cbveiculo";
            this.cbveiculo.Size = new System.Drawing.Size(379, 21);
            this.cbveiculo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(146, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Estado";
            // 
            // cbestado
            // 
            this.cbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbestado.FormattingEnabled = true;
            this.cbestado.Items.AddRange(new object[] {
            "Todos",
            "Aprovado",
            "Aprovado (Para Disponibilizar)",
            "Pendente",
            "Cancelado",
            "Terminado"});
            this.cbestado.Location = new System.Drawing.Point(75, 144);
            this.cbestado.Name = "cbestado";
            this.cbestado.Size = new System.Drawing.Size(197, 21);
            this.cbestado.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "De:";
            // 
            // dtpinicio
            // 
            this.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpinicio.Location = new System.Drawing.Point(45, 21);
            this.dtpinicio.Name = "dtpinicio";
            this.dtpinicio.Size = new System.Drawing.Size(144, 22);
            this.dtpinicio.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(195, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Até:";
            // 
            // dtpfim
            // 
            this.dtpfim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfim.Location = new System.Drawing.Point(236, 21);
            this.dtpfim.Name = "dtpfim";
            this.dtpfim.Size = new System.Drawing.Size(137, 22);
            this.dtpfim.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(337, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "A carregar dados...";
            this.label7.Visible = false;
            // 
            // gbdatas
            // 
            this.gbdatas.Controls.Add(this.dtpfim);
            this.gbdatas.Controls.Add(this.label5);
            this.gbdatas.Controls.Add(this.dtpinicio);
            this.gbdatas.Controls.Add(this.label6);
            this.gbdatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbdatas.ForeColor = System.Drawing.Color.White;
            this.gbdatas.Location = new System.Drawing.Point(409, 129);
            this.gbdatas.Name = "gbdatas";
            this.gbdatas.Size = new System.Drawing.Size(379, 48);
            this.gbdatas.TabIndex = 15;
            this.gbdatas.TabStop = false;
            this.gbdatas.Text = "Data";
            this.gbdatas.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(295, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 20);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Entre Datas";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            this.tableAdapterManager.UtilizadorTableAdapter = this.utilizadorTableAdapter;
            this.tableAdapterManager.Veiculo_EntregaTableAdapter = null;
            this.tableAdapterManager.VeiculoTableAdapter = this.veiculoTableAdapter;
            // 
            // utilizadorTableAdapter
            // 
            this.utilizadorTableAdapter.ClearBeforeFill = true;
            // 
            // veiculoTableAdapter
            // 
            this.veiculoTableAdapter.ClearBeforeFill = true;
            // 
            // utilizadorBindingSource
            // 
            this.utilizadorBindingSource.DataMember = "Utilizador";
            this.utilizadorBindingSource.DataSource = this.dataSet1;
            // 
            // veiculoBindingSource
            // 
            this.veiculoBindingSource.DataMember = "Veiculo";
            this.veiculoBindingSource.DataSource = this.dataSet1;
            // 
            // spListaVeiculoDescricaoBindingSource
            // 
            this.spListaVeiculoDescricaoBindingSource.DataMember = "spListaVeiculoDescricao";
            this.spListaVeiculoDescricaoBindingSource.DataSource = this.dataSet1;
            // 
            // spListaVeiculoDescricaoTableAdapter
            // 
            this.spListaVeiculoDescricaoTableAdapter.ClearBeforeFill = true;
            // 
            // spListaVeiculosBindingSource
            // 
            this.spListaVeiculosBindingSource.DataMember = "spListaVeiculos";
            this.spListaVeiculosBindingSource.DataSource = this.dataSet1;
            // 
            // spListaVeiculosTableAdapter
            // 
            this.spListaVeiculosTableAdapter.ClearBeforeFill = true;
            // 
            // spListaPedidoMarcacoesExtraBindingSource
            // 
            this.spListaPedidoMarcacoesExtraBindingSource.DataMember = "spListaPedidoMarcacoesExtra";
            this.spListaPedidoMarcacoesExtraBindingSource.DataSource = this.dataSet1;
            // 
            // spListaPedidoMarcacoesExtraTableAdapter
            // 
            this.spListaPedidoMarcacoesExtraTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.magnifier;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(583, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 43);
            this.button1.TabIndex = 17;
            this.button1.Text = "Aplicar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bttclean
            // 
            this.bttclean.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttclean.Image = global::Gestao_Frotas_Desktop.Properties.Resources.paintbrush;
            this.bttclean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttclean.Location = new System.Drawing.Point(694, 7);
            this.bttclean.Name = "bttclean";
            this.bttclean.Size = new System.Drawing.Size(94, 43);
            this.bttclean.TabIndex = 14;
            this.bttclean.Text = "Limpar";
            this.bttclean.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttclean.UseVisualStyleBackColor = true;
            this.bttclean.Click += new System.EventHandler(this.bttclean_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.logo_gestao_frotas;
            this.pictureBox1.Location = new System.Drawing.Point(21, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
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
            // FrmMarcacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(808, 466);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.gbdatas);
            this.Controls.Add(this.bttclean);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbestado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbveiculo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbutilizador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvpedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMarcacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcações";
            this.Load += new System.EventHandler(this.FrmMarcacoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpedidos)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbdatas.ResumeLayout(false);
            this.gbdatas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaPedidoMarcacoesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaVeiculoDescricaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaVeiculosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spListaPedidoMarcacoesExtraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.justificacao_Pedido_MarcacaoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvpedidos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbutilizador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbveiculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbestado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpinicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpfim;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bttclean;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource spListaPedidoMarcacoesBindingSource;
        private DataSet1TableAdapters.spListaPedidoMarcacoesTableAdapter spListaPedidoMarcacoesTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox gbdatas;
        private System.Windows.Forms.CheckBox checkBox1;
        private DataSet1TableAdapters.UtilizadorTableAdapter utilizadorTableAdapter;
        private System.Windows.Forms.BindingSource utilizadorBindingSource;
        private DataSet1TableAdapters.VeiculoTableAdapter veiculoTableAdapter;
        private System.Windows.Forms.BindingSource veiculoBindingSource;
        private System.Windows.Forms.BindingSource spListaVeiculoDescricaoBindingSource;
        private DataSet1TableAdapters.spListaVeiculoDescricaoTableAdapter spListaVeiculoDescricaoTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource spListaVeiculosBindingSource;
        private DataSet1TableAdapters.spListaVeiculosTableAdapter spListaVeiculosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.BindingSource spListaPedidoMarcacoesExtraBindingSource;
        private DataSet1TableAdapters.spListaPedidoMarcacoesExtraTableAdapter spListaPedidoMarcacoesExtraTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aprovarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminarPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disponibilizarPedidoToolStripMenuItem;
        private System.Windows.Forms.BindingSource pedido_Marcacao_HistoricoBindingSource;
        private DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter pedido_Marcacao_HistoricoTableAdapter;
        private System.Windows.Forms.BindingSource justificacao_Pedido_MarcacaoBindingSource;
        private DataSet1TableAdapters.Justificacao_Pedido_MarcacaoTableAdapter justificacao_Pedido_MarcacaoTableAdapter;
    }
}