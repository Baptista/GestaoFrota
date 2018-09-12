namespace Gestao_Frotas_Desktop.NovoPedido
{
    partial class FrmPedidoVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoVeiculo));
            this.dgveiculos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.pedido_Marcacao_HistoricoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pedido_Marcacao_HistoricoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.veiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.VeiculoTableAdapter();
            this.veiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spDetalheVeiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spDetalheVeiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spDetalheVeiculoTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtdetalheiniciais = new System.Windows.Forms.Label();
            this.txtdetalhecontracto = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtdetalheveiculo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgveiculos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDetalheVeiculoBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgveiculos
            // 
            this.dgveiculos.AllowUserToAddRows = false;
            this.dgveiculos.AllowUserToDeleteRows = false;
            this.dgveiculos.AllowUserToResizeColumns = false;
            this.dgveiculos.AllowUserToResizeRows = false;
            this.dgveiculos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dgveiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgveiculos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column9});
            this.dgveiculos.Location = new System.Drawing.Point(22, 176);
            this.dgveiculos.Name = "dgveiculos";
            this.dgveiculos.ReadOnly = true;
            this.dgveiculos.RowHeadersVisible = false;
            this.dgveiculos.Size = new System.Drawing.Size(757, 242);
            this.dgveiculos.TabIndex = 0;
            this.dgveiculos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgveiculos_CellClick);
            this.dgveiculos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgveiculos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Veículos Disponiveis";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.logo_gestao_frotas;
            this.pictureBox1.Location = new System.Drawing.Point(68, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.tableAdapterManager.Pedido_Marcacao_HistoricoTableAdapter = this.pedido_Marcacao_HistoricoTableAdapter;
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
            this.tableAdapterManager.VeiculoTableAdapter = this.veiculoTableAdapter;
            // 
            // veiculoTableAdapter
            // 
            this.veiculoTableAdapter.ClearBeforeFill = true;
            // 
            // veiculoBindingSource
            // 
            this.veiculoBindingSource.DataMember = "Veiculo";
            this.veiculoBindingSource.DataSource = this.dataSet1;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtdetalheiniciais);
            this.groupBox1.Controls.Add(this.txtdetalhecontracto);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtdetalheveiculo);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(360, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 131);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalhes";
            this.groupBox1.Visible = false;
            // 
            // txtdetalheiniciais
            // 
            this.txtdetalheiniciais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdetalheiniciais.Location = new System.Drawing.Point(116, 76);
            this.txtdetalheiniciais.Name = "txtdetalheiniciais";
            this.txtdetalheiniciais.Size = new System.Drawing.Size(186, 24);
            this.txtdetalheiniciais.TabIndex = 6;
            this.txtdetalheiniciais.Text = "Kms Iniciais:";
            this.txtdetalheiniciais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdetalhecontracto
            // 
            this.txtdetalhecontracto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdetalhecontracto.Location = new System.Drawing.Point(116, 52);
            this.txtdetalhecontracto.Name = "txtdetalhecontracto";
            this.txtdetalhecontracto.Size = new System.Drawing.Size(297, 24);
            this.txtdetalhecontracto.TabIndex = 5;
            this.txtdetalhecontracto.Text = "Kms Contrato:";
            this.txtdetalhecontracto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtdetalhecontracto.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(308, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtdetalheveiculo
            // 
            this.txtdetalheveiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdetalheveiculo.Location = new System.Drawing.Point(116, 28);
            this.txtdetalheveiculo.Name = "txtdetalheveiculo";
            this.txtdetalheveiculo.Size = new System.Drawing.Size(297, 24);
            this.txtdetalheveiculo.TabIndex = 1;
            this.txtdetalheveiculo.Text = "Veiculo";
            this.txtdetalheveiculo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::Gestao_Frotas_Desktop.Properties.Resources.car_test;
            this.pictureBox2.Location = new System.Drawing.Point(6, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(104, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "idveiculo";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "foto";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Veiculo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 240;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Matricula";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Owner";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Combustivel";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Estado";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "KmsContrato";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "KmsIniciais";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // FrmPedidoVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(800, 438);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgveiculos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPedidoVeiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido Veiculo";
            this.Load += new System.EventHandler(this.FrmPedidoVeiculo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgveiculos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spDetalheVeiculoBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgveiculos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource pedido_Marcacao_HistoricoBindingSource;
        private DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter pedido_Marcacao_HistoricoTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DataSet1TableAdapters.VeiculoTableAdapter veiculoTableAdapter;
        private System.Windows.Forms.BindingSource veiculoBindingSource;
        private System.Windows.Forms.BindingSource spDetalheVeiculoBindingSource;
        private DataSet1TableAdapters.spDetalheVeiculoTableAdapter spDetalheVeiculoTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtdetalhecontracto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtdetalheveiculo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label txtdetalheiniciais;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}