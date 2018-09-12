namespace Gestao_Frotas_Desktop.LoginMenu
{
    partial class FrmDisponibilizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisponibilizar));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.bttconfirm = new System.Windows.Forms.Button();
            this.dgvdanos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.pedido_Marcacao_HistoricoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pedido_Marcacao_HistoricoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.veiculo_EntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veiculo_EntregaTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Veiculo_EntregaTableAdapter();
            this.danos_VeiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.danos_VeiculoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Danos_VeiculoTableAdapter();
            this.danos_Veiculo_ComprovativoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.danos_Veiculo_ComprovativoTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.Danos_Veiculo_ComprovativoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculo_EntregaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_VeiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_Veiculo_ComprovativoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(149, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disponibilizar Veículo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.logo_gestao_frotas;
            this.pictureBox1.Location = new System.Drawing.Point(35, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(149, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kms:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(203, 63);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(373, 26);
            this.numericUpDown1.TabIndex = 3;
            // 
            // bttconfirm
            // 
            this.bttconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttconfirm.Location = new System.Drawing.Point(610, 35);
            this.bttconfirm.Name = "bttconfirm";
            this.bttconfirm.Size = new System.Drawing.Size(151, 50);
            this.bttconfirm.TabIndex = 4;
            this.bttconfirm.Text = "Confirmar";
            this.bttconfirm.UseVisualStyleBackColor = true;
            this.bttconfirm.Click += new System.EventHandler(this.bttconfirm_Click);
            // 
            // dgvdanos
            // 
            this.dgvdanos.AllowUserToAddRows = false;
            this.dgvdanos.AllowUserToDeleteRows = false;
            this.dgvdanos.AllowUserToResizeColumns = false;
            this.dgvdanos.AllowUserToResizeRows = false;
            this.dgvdanos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dgvdanos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdanos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvdanos.Location = new System.Drawing.Point(35, 133);
            this.dgvdanos.Name = "dgvdanos";
            this.dgvdanos.ReadOnly = true;
            this.dgvdanos.RowHeadersVisible = false;
            this.dgvdanos.Size = new System.Drawing.Size(726, 230);
            this.dgvdanos.TabIndex = 5;
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
            this.Column2.Width = 630;
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
            // button2
            // 
            this.button2.Image = global::Gestao_Frotas_Desktop.Properties.Resources.add__3_;
            this.button2.Location = new System.Drawing.Point(248, 369);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 54);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.writing;
            this.button1.Location = new System.Drawing.Point(359, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 54);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Image = global::Gestao_Frotas_Desktop.Properties.Resources.cancel_mark__1_;
            this.button3.Location = new System.Drawing.Point(463, 369);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 54);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.tableAdapterManager.Danos_Veiculo_ComprovativoTableAdapter = this.danos_Veiculo_ComprovativoTableAdapter;
            this.tableAdapterManager.Danos_VeiculoTableAdapter = this.danos_VeiculoTableAdapter;
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
            this.tableAdapterManager.Veiculo_EntregaTableAdapter = this.veiculo_EntregaTableAdapter;
            this.tableAdapterManager.VeiculoTableAdapter = null;
            // 
            // veiculo_EntregaBindingSource
            // 
            this.veiculo_EntregaBindingSource.DataMember = "Veiculo_Entrega";
            this.veiculo_EntregaBindingSource.DataSource = this.dataSet1;
            // 
            // veiculo_EntregaTableAdapter
            // 
            this.veiculo_EntregaTableAdapter.ClearBeforeFill = true;
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
            // FrmDisponibilizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvdanos);
            this.Controls.Add(this.bttconfirm);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDisponibilizar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disponibilizar Veículo";
            this.Load += new System.EventHandler(this.FrmDisponibilizar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdanos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedido_Marcacao_HistoricoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculo_EntregaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_VeiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.danos_Veiculo_ComprovativoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button bttconfirm;
        private System.Windows.Forms.DataGridView dgvdanos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource pedido_Marcacao_HistoricoBindingSource;
        private DataSet1TableAdapters.Pedido_Marcacao_HistoricoTableAdapter pedido_Marcacao_HistoricoTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DataSet1TableAdapters.Veiculo_EntregaTableAdapter veiculo_EntregaTableAdapter;
        private System.Windows.Forms.BindingSource veiculo_EntregaBindingSource;
        private DataSet1TableAdapters.Danos_VeiculoTableAdapter danos_VeiculoTableAdapter;
        private System.Windows.Forms.BindingSource danos_VeiculoBindingSource;
        private DataSet1TableAdapters.Danos_Veiculo_ComprovativoTableAdapter danos_Veiculo_ComprovativoTableAdapter;
        private System.Windows.Forms.BindingSource danos_Veiculo_ComprovativoBindingSource;
    }
}