namespace Gestao_Frotas_Desktop
{
    partial class FrmAddUtilizador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddUtilizador));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.cbperfil = new System.Windows.Forms.ComboBox();
            this.perfilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Gestao_Frotas_Desktop.DataSet1();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bttcancel = new System.Windows.Forms.Button();
            this.bttadd = new System.Windows.Forms.Button();
            this.perfilTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.PerfilTableAdapter();
            this.spObtemPasswordDefaultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spObtemPasswordDefaultTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.spObtemPasswordDefaultTableAdapter();
            this.tableAdapterManager = new Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager();
            this.cbState = new System.Windows.Forms.CheckBox();
            this.utilizadorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.utilizadorTableAdapter = new Gestao_Frotas_Desktop.DataSet1TableAdapters.UtilizadorTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spObtemPasswordDefaultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(94, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Adicionar Utilizador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome";
            // 
            // txtnome
            // 
            this.txtnome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnome.Location = new System.Drawing.Point(84, 93);
            this.txtnome.Name = "txtnome";
            this.txtnome.Size = new System.Drawing.Size(322, 26);
            this.txtnome.TabIndex = 6;
            this.txtnome.TextChanged += new System.EventHandler(this.txtnome_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username";
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.Location = new System.Drawing.Point(21, 206);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(390, 26);
            this.txtusername.TabIndex = 8;
            this.txtusername.TextChanged += new System.EventHandler(this.txtusername_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // txtpassword
            // 
            this.txtpassword.Enabled = false;
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(21, 290);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(390, 26);
            this.txtpassword.TabIndex = 10;
            // 
            // cbperfil
            // 
            this.cbperfil.DataSource = this.perfilBindingSource;
            this.cbperfil.DisplayMember = "Descricao";
            this.cbperfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbperfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbperfil.FormattingEnabled = true;
            this.cbperfil.Location = new System.Drawing.Point(21, 364);
            this.cbperfil.Name = "cbperfil";
            this.cbperfil.Size = new System.Drawing.Size(390, 28);
            this.cbperfil.TabIndex = 11;
            this.cbperfil.ValueMember = "IdPerfil";
            // 
            // perfilBindingSource
            // 
            this.perfilBindingSource.DataMember = "Perfil";
            this.perfilBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Perfil";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestao_Frotas_Desktop.Properties.Resources.user_silhouette;
            this.pictureBox1.Location = new System.Drawing.Point(52, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Gestao_Frotas_Desktop.Properties.Resources.user_silhouette;
            this.pictureBox2.Location = new System.Drawing.Point(318, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // bttcancel
            // 
            this.bttcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttcancel.Location = new System.Drawing.Point(104, 409);
            this.bttcancel.Name = "bttcancel";
            this.bttcancel.Size = new System.Drawing.Size(92, 34);
            this.bttcancel.TabIndex = 15;
            this.bttcancel.Text = "Cancelar";
            this.bttcancel.UseVisualStyleBackColor = true;
            this.bttcancel.Click += new System.EventHandler(this.bttcancel_Click);
            // 
            // bttadd
            // 
            this.bttadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttadd.Location = new System.Drawing.Point(220, 409);
            this.bttadd.Name = "bttadd";
            this.bttadd.Size = new System.Drawing.Size(92, 34);
            this.bttadd.TabIndex = 16;
            this.bttadd.Text = "Adicionar";
            this.bttadd.UseVisualStyleBackColor = true;
            this.bttadd.Click += new System.EventHandler(this.bttadd_Click);
            // 
            // perfilTableAdapter
            // 
            this.perfilTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.PerfilTableAdapter = this.perfilTableAdapter;
            this.tableAdapterManager.PermissaoTableAdapter = null;
            this.tableAdapterManager.sysdiagramsTableAdapter = null;
            this.tableAdapterManager.Tipo_Justificacao_PedidoTableAdapter = null;
            this.tableAdapterManager.TipologiaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Gestao_Frotas_Desktop.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UtilizadorTableAdapter = null;
            this.tableAdapterManager.Veiculo_EntregaTableAdapter = null;
            this.tableAdapterManager.VeiculoTableAdapter = null;
            // 
            // cbState
            // 
            this.cbState.AutoSize = true;
            this.cbState.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.ForeColor = System.Drawing.Color.White;
            this.cbState.Location = new System.Drawing.Point(169, 135);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(87, 28);
            this.cbState.TabIndex = 18;
            this.cbState.Text = "Estado";
            this.cbState.UseVisualStyleBackColor = true;
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmAddUtilizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(431, 467);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.bttadd);
            this.Controls.Add(this.bttcancel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbperfil);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddUtilizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Utilizador";
            this.Load += new System.EventHandler(this.FrmAddUtilizador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spObtemPasswordDefaultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilizadorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.ComboBox cbperfil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button bttcancel;
        private System.Windows.Forms.Button bttadd;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource perfilBindingSource;
        private DataSet1TableAdapters.PerfilTableAdapter perfilTableAdapter;
        private System.Windows.Forms.BindingSource spObtemPasswordDefaultBindingSource;
        private DataSet1TableAdapters.spObtemPasswordDefaultTableAdapter spObtemPasswordDefaultTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.CheckBox cbState;
        private System.Windows.Forms.BindingSource utilizadorBindingSource;
        private DataSet1TableAdapters.UtilizadorTableAdapter utilizadorTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}