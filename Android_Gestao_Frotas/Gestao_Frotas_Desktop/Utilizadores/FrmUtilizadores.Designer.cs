namespace Gestao_Frotas_Desktop
{
    partial class FrmUtilizadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtilizadores));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activarDesactivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvutilizadores = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UtilizadoresMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.activarDesactivarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reporPasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.utilizadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.utilizadorTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.UtilizadorTableAdapter();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.utilizadoresTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.utilizadoresTableTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.UtilizadoresTableTableAdapter();
            this.spObtemPasswordDefaultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spObtemPasswordDefaultTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spObtemPasswordDefaultTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvutilizadores)).BeginInit();
            this.UtilizadoresMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadoresTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spObtemPasswordDefaultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(175, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Utilizadores";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.activarDesactivarToolStripMenuItem,
            this.reporPasswordToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.add__3_;
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.novoToolStripMenuItem.Text = "Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
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
            // reporPasswordToolStripMenuItem
            // 
            this.reporPasswordToolStripMenuItem.Image = global::Gestao_Frotas_Desktop.Properties.Resources.key_silhouette_security_tool_interface_symbol_of_password;
            this.reporPasswordToolStripMenuItem.Name = "reporPasswordToolStripMenuItem";
            this.reporPasswordToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.reporPasswordToolStripMenuItem.Text = "Repor Password";
            this.reporPasswordToolStripMenuItem.Click += new System.EventHandler(this.reporPasswordToolStripMenuItem_Click);
            // 
            // dgvutilizadores
            // 
            this.dgvutilizadores.AllowUserToAddRows = false;
            this.dgvutilizadores.AllowUserToDeleteRows = false;
            this.dgvutilizadores.AllowUserToResizeColumns = false;
            this.dgvutilizadores.AllowUserToResizeRows = false;
            this.dgvutilizadores.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.dgvutilizadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvutilizadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvutilizadores.ContextMenuStrip = this.UtilizadoresMS;
            this.dgvutilizadores.Location = new System.Drawing.Point(12, 147);
            this.dgvutilizadores.Name = "dgvutilizadores";
            this.dgvutilizadores.ReadOnly = true;
            this.dgvutilizadores.RowHeadersVisible = false;
            this.dgvutilizadores.Size = new System.Drawing.Size(459, 389);
            this.dgvutilizadores.TabIndex = 7;
            this.dgvutilizadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvutilizadores_CellClick);
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
            this.Column2.HeaderText = "Username";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 170;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Perfil";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Estado";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "IdUser";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // UtilizadoresMS
            // 
            this.UtilizadoresMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem1,
            this.activarDesactivarToolStripMenuItem1,
            this.reporPasswordToolStripMenuItem1});
            this.UtilizadoresMS.Name = "UtilizadoresMS";
            this.UtilizadoresMS.Size = new System.Drawing.Size(171, 70);
            // 
            // editarToolStripMenuItem1
            // 
            this.editarToolStripMenuItem1.Name = "editarToolStripMenuItem1";
            this.editarToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.editarToolStripMenuItem1.Text = "Editar";
            this.editarToolStripMenuItem1.Click += new System.EventHandler(this.editarToolStripMenuItem1_Click);
            // 
            // activarDesactivarToolStripMenuItem1
            // 
            this.activarDesactivarToolStripMenuItem1.Name = "activarDesactivarToolStripMenuItem1";
            this.activarDesactivarToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.activarDesactivarToolStripMenuItem1.Text = "Activar/Desactivar";
            this.activarDesactivarToolStripMenuItem1.Click += new System.EventHandler(this.activarDesactivarToolStripMenuItem1_Click);
            // 
            // reporPasswordToolStripMenuItem1
            // 
            this.reporPasswordToolStripMenuItem1.Name = "reporPasswordToolStripMenuItem1";
            this.reporPasswordToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.reporPasswordToolStripMenuItem1.Text = "Repor Password";
            this.reporPasswordToolStripMenuItem1.Click += new System.EventHandler(this.reporPasswordToolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.logo_gestao_frotas;
            this.pictureBox1.Location = new System.Drawing.Point(40, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.tableAdapterManager.VeiculoTableAdapter = null;
            // 
            // utilizadoresTableBindingSource
            // 
            this.utilizadoresTableBindingSource.DataMember = "UtilizadoresTable";
            this.utilizadoresTableBindingSource.DataSource = this.dataSet1;
            // 
            // utilizadoresTableTableAdapter
            // 
            this.utilizadoresTableTableAdapter.ClearBeforeFill = true;
            // 
            // spObtemPasswordDefaultBindingSource
            // 
            this.spObtemPasswordDefaultBindingSource.DataMember = "spObtemPasswordDefault";
            this.spObtemPasswordDefaultBindingSource.DataSource = this.dataSet1;
            // 
            // spObtemPasswordDefaultTableAdapter
            // 
            this.spObtemPasswordDefaultTableAdapter.ClearBeforeFill = true;
            // 
            // FrmUtilizadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(492, 556);
            this.Controls.Add(this.dgvutilizadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUtilizadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilizadores";
            this.Load += new System.EventHandler(this.FrmUtilizadores_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvutilizadores)).EndInit();
            this.UtilizadoresMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadoresTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spObtemPasswordDefaultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarDesactivarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporPasswordToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvutilizadores;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource utilizadorBindingSource;
        private DataSet1TableAdapters.UtilizadorTableAdapter utilizadorTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource utilizadoresTableBindingSource;
        private DataSet1TableAdapters.UtilizadoresTableTableAdapter utilizadoresTableTableAdapter;
        private System.Windows.Forms.BindingSource spObtemPasswordDefaultBindingSource;
        private DataSet1TableAdapters.spObtemPasswordDefaultTableAdapter spObtemPasswordDefaultTableAdapter;
        private System.Windows.Forms.ContextMenuStrip UtilizadoresMS;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem activarDesactivarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reporPasswordToolStripMenuItem1;
    }
}