namespace SistemaCadastro
{
    partial class FrmTelaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTelaLogin));
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txbSenha = new System.Windows.Forms.TextBox();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtEsqueciMinhaSenha = new System.Windows.Forms.LinkLabel();
            this.PrimeiroAcesso = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEntrar.Location = new System.Drawing.Point(12, 183);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(116, 42);
            this.btnEntrar.TabIndex = 0;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelar.Location = new System.Drawing.Point(134, 183);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 42);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txbSenha
            // 
            this.txbSenha.Location = new System.Drawing.Point(12, 132);
            this.txbSenha.MaxLength = 16;
            this.txbSenha.Name = "txbSenha";
            this.txbSenha.PasswordChar = '*';
            this.txbSenha.Size = new System.Drawing.Size(237, 20);
            this.txbSenha.TabIndex = 2;
            // 
            // txbUsuario
            // 
            this.txbUsuario.Location = new System.Drawing.Point(12, 70);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(237, 20);
            this.txbUsuario.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 54);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(9, 116);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 5;
            this.lblSenha.Text = "Senha";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(274, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 230);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txtEsqueciMinhaSenha
            // 
            this.txtEsqueciMinhaSenha.AutoSize = true;
            this.txtEsqueciMinhaSenha.Location = new System.Drawing.Point(9, 258);
            this.txtEsqueciMinhaSenha.Name = "txtEsqueciMinhaSenha";
            this.txtEsqueciMinhaSenha.Size = new System.Drawing.Size(102, 13);
            this.txtEsqueciMinhaSenha.TabIndex = 9;
            this.txtEsqueciMinhaSenha.TabStop = true;
            this.txtEsqueciMinhaSenha.Text = "Esqueceu a senha?";
            this.txtEsqueciMinhaSenha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.txtEsqueciMinhaSenha_LinkClicked);
            // 
            // PrimeiroAcesso
            // 
            this.PrimeiroAcesso.AutoSize = true;
            this.PrimeiroAcesso.Location = new System.Drawing.Point(9, 302);
            this.PrimeiroAcesso.Name = "PrimeiroAcesso";
            this.PrimeiroAcesso.Size = new System.Drawing.Size(143, 13);
            this.PrimeiroAcesso.TabIndex = 10;
            this.PrimeiroAcesso.TabStop = true;
            this.PrimeiroAcesso.Text = "Primeiro Acesso? Clique aqui";
            this.PrimeiroAcesso.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PrimeiroAcesso_LinkClicked);
            // 
            // FrmTelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 324);
            this.Controls.Add(this.PrimeiroAcesso);
            this.Controls.Add(this.txtEsqueciMinhaSenha);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txbUsuario);
            this.Controls.Add(this.txbSenha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEntrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaLogin";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TelaLogin_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txbSenha;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel txtEsqueciMinhaSenha;
        private System.Windows.Forms.LinkLabel PrimeiroAcesso;
    }
}