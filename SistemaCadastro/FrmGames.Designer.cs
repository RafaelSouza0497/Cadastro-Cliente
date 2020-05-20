namespace SistemaCadastro
{
    partial class FrmGames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGames));
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvGames = new System.Windows.Forms.DataGridView();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produtora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plataformas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPreço = new System.Windows.Forms.TextBox();
            this.txtGenero = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.cbPlataforma = new System.Windows.Forms.ComboBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.BtnCancela = new System.Windows.Forms.Button();
            this.btnAddCliente = new System.Windows.Forms.Button();
            this.lblCelular = new System.Windows.Forms.Label();
            this.lblPlataformas = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblProdutora = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.txtProdutora = new System.Windows.Forms.TextBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(697, 484);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 18;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvGames);
            this.groupBox2.Location = new System.Drawing.Point(12, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 276);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Biblioteca de games";
            // 
            // dgvGames
            // 
            this.dgvGames.AllowUserToOrderColumns = true;
            this.dgvGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Titulo,
            this.ano,
            this.Produtora,
            this.Genero,
            this.Plataformas,
            this.Preco});
            this.dgvGames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGames.Location = new System.Drawing.Point(3, 16);
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.Size = new System.Drawing.Size(754, 257);
            this.dgvGames.TabIndex = 0;
            // 
            // Titulo
            // 
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.Name = "Titulo";
            // 
            // ano
            // 
            this.ano.HeaderText = "Ano";
            this.ano.Name = "ano";
            // 
            // Produtora
            // 
            this.Produtora.HeaderText = "Produtora";
            this.Produtora.Name = "Produtora";
            // 
            // Genero
            // 
            this.Genero.HeaderText = "Genero";
            this.Genero.Name = "Genero";
            // 
            // Plataformas
            // 
            this.Plataformas.HeaderText = "Plataformas";
            this.Plataformas.Name = "Plataformas";
            // 
            // Preco
            // 
            this.Preco.HeaderText = "Preço";
            this.Preco.Name = "Preco";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPreço);
            this.groupBox1.Controls.Add(this.txtGenero);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.cbPlataforma);
            this.groupBox1.Controls.Add(this.btnLimpar);
            this.groupBox1.Controls.Add(this.BtnCancela);
            this.groupBox1.Controls.Add(this.btnAddCliente);
            this.groupBox1.Controls.Add(this.lblCelular);
            this.groupBox1.Controls.Add(this.lblPlataformas);
            this.groupBox1.Controls.Add(this.lblGenero);
            this.groupBox1.Controls.Add(this.lblProdutora);
            this.groupBox1.Controls.Add(this.lblCpf);
            this.groupBox1.Controls.Add(this.txtProdutora);
            this.groupBox1.Controls.Add(this.txtAno);
            this.groupBox1.Controls.Add(this.txtTitulo);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 184);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Game";
            // 
            // txtPreço
            // 
            this.txtPreço.Location = new System.Drawing.Point(20, 107);
            this.txtPreço.MaxLength = 11;
            this.txtPreço.Name = "txtPreço";
            this.txtPreço.Size = new System.Drawing.Size(100, 20);
            this.txtPreço.TabIndex = 23;
            this.txtPreço.Text = "R$";
            // 
            // txtGenero
            // 
            this.txtGenero.FormattingEnabled = true;
            this.txtGenero.Items.AddRange(new object[] {
            "Ação e Aventura",
            "Fps",
            "Esportes",
            "MMO",
            "Corrida",
            "Guerra"});
            this.txtGenero.Location = new System.Drawing.Point(415, 53);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.Size = new System.Drawing.Size(125, 21);
            this.txtGenero.TabIndex = 22;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(157, 155);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 21;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Visible = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // cbPlataforma
            // 
            this.cbPlataforma.FormattingEnabled = true;
            this.cbPlataforma.Items.AddRange(new object[] {
            "Xbox one",
            "Playstation 4",
            "PC"});
            this.cbPlataforma.Location = new System.Drawing.Point(582, 52);
            this.cbPlataforma.Name = "cbPlataforma";
            this.cbPlataforma.Size = new System.Drawing.Size(121, 21);
            this.cbPlataforma.TabIndex = 19;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.White;
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.Location = new System.Drawing.Point(23, 145);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(34, 33);
            this.btnLimpar.TabIndex = 18;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click_1);
            // 
            // BtnCancela
            // 
            this.BtnCancela.BackColor = System.Drawing.Color.White;
            this.BtnCancela.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancela.Image")));
            this.BtnCancela.Location = new System.Drawing.Point(711, 145);
            this.BtnCancela.Name = "BtnCancela";
            this.BtnCancela.Size = new System.Drawing.Size(32, 33);
            this.BtnCancela.TabIndex = 16;
            this.BtnCancela.UseVisualStyleBackColor = false;
            // 
            // btnAddCliente
            // 
            this.btnAddCliente.BackColor = System.Drawing.Color.White;
            this.btnAddCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCliente.Image")));
            this.btnAddCliente.Location = new System.Drawing.Point(655, 145);
            this.btnAddCliente.Name = "btnAddCliente";
            this.btnAddCliente.Size = new System.Drawing.Size(31, 33);
            this.btnAddCliente.TabIndex = 15;
            this.btnAddCliente.UseVisualStyleBackColor = false;
            this.btnAddCliente.Click += new System.EventHandler(this.btnAddCliente_Click_1);
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Location = new System.Drawing.Point(20, 91);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(35, 13);
            this.lblCelular.TabIndex = 11;
            this.lblCelular.Text = "Preco";
            // 
            // lblPlataformas
            // 
            this.lblPlataformas.AutoSize = true;
            this.lblPlataformas.Location = new System.Drawing.Point(579, 36);
            this.lblPlataformas.Name = "lblPlataformas";
            this.lblPlataformas.Size = new System.Drawing.Size(62, 13);
            this.lblPlataformas.TabIndex = 9;
            this.lblPlataformas.Text = "Plataformas";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(412, 36);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(42, 13);
            this.lblGenero.TabIndex = 7;
            this.lblGenero.Text = "Genero";
            // 
            // lblProdutora
            // 
            this.lblProdutora.AutoSize = true;
            this.lblProdutora.Location = new System.Drawing.Point(293, 36);
            this.lblProdutora.Name = "lblProdutora";
            this.lblProdutora.Size = new System.Drawing.Size(53, 13);
            this.lblProdutora.TabIndex = 6;
            this.lblProdutora.Text = "Produtora";
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Location = new System.Drawing.Point(154, 36);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(26, 13);
            this.lblCpf.TabIndex = 5;
            this.lblCpf.Text = "Ano";
            // 
            // txtProdutora
            // 
            this.txtProdutora.Location = new System.Drawing.Point(296, 53);
            this.txtProdutora.Name = "txtProdutora";
            this.txtProdutora.Size = new System.Drawing.Size(100, 20);
            this.txtProdutora.TabIndex = 3;
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(157, 53);
            this.txtAno.MaxLength = 11;
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(100, 20);
            this.txtAno.TabIndex = 2;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(20, 53);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 20);
            this.txtTitulo.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(17, 36);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(33, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Titulo";
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.ForeColor = System.Drawing.Color.Black;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.Location = new System.Drawing.Point(66, 478);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(28, 29);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Location = new System.Drawing.Point(15, 478);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(33, 29);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FrmGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 522);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Games";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGames_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvGames;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button BtnCancela;
        private System.Windows.Forms.Button btnAddCliente;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.Label lblPlataformas;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblProdutora;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.TextBox txtProdutora;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ComboBox cbPlataforma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ano;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produtora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plataformas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ComboBox txtGenero;
        private System.Windows.Forms.TextBox txtPreço;
    }
}