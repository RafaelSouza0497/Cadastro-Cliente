namespace SistemaCadastro
{
    partial class FrmContatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContatos));
            this.gpbContatos = new System.Windows.Forms.GroupBox();
            this.btnConsultaCEP = new System.Windows.Forms.Button();
            this.Cidade = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.lblRua = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.lblCep = new System.Windows.Forms.Label();
            this.gpbContatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbContatos
            // 
            this.gpbContatos.Controls.Add(this.btnConsultaCEP);
            this.gpbContatos.Controls.Add(this.Cidade);
            this.gpbContatos.Controls.Add(this.txtCidade);
            this.gpbContatos.Controls.Add(this.label1);
            this.gpbContatos.Controls.Add(this.txtEstado);
            this.gpbContatos.Controls.Add(this.btnFechar);
            this.gpbContatos.Controls.Add(this.btnCancelar);
            this.gpbContatos.Controls.Add(this.btnSalvar);
            this.gpbContatos.Controls.Add(this.lblNumero);
            this.gpbContatos.Controls.Add(this.lblBairro);
            this.gpbContatos.Controls.Add(this.lblRua);
            this.gpbContatos.Controls.Add(this.txtNumero);
            this.gpbContatos.Controls.Add(this.txtBairro);
            this.gpbContatos.Controls.Add(this.txtRua);
            this.gpbContatos.Controls.Add(this.txtCEP);
            this.gpbContatos.Controls.Add(this.lblCep);
            this.gpbContatos.Location = new System.Drawing.Point(12, 12);
            this.gpbContatos.Name = "gpbContatos";
            this.gpbContatos.Size = new System.Drawing.Size(855, 249);
            this.gpbContatos.TabIndex = 1;
            this.gpbContatos.TabStop = false;
            this.gpbContatos.Text = "Dados do Contato";
            // 
            // btnConsultaCEP
            // 
            this.btnConsultaCEP.Location = new System.Drawing.Point(128, 52);
            this.btnConsultaCEP.Name = "btnConsultaCEP";
            this.btnConsultaCEP.Size = new System.Drawing.Size(21, 20);
            this.btnConsultaCEP.TabIndex = 20;
            this.btnConsultaCEP.Text = "X";
            this.btnConsultaCEP.UseVisualStyleBackColor = true;
            this.btnConsultaCEP.Click += new System.EventHandler(this.btnConsultaCEP_Click);
            // 
            // Cidade
            // 
            this.Cidade.AutoSize = true;
            this.Cidade.Location = new System.Drawing.Point(152, 36);
            this.Cidade.Name = "Cidade";
            this.Cidade.Size = new System.Drawing.Size(40, 13);
            this.Cidade.TabIndex = 19;
            this.Cidade.Text = "Cidade";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(155, 52);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(100, 20);
            this.txtCidade.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "UF";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(261, 52);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(34, 20);
            this.txtEstado.TabIndex = 16;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(774, 213);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 14;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(658, 213);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(526, 213);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(776, 36);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(16, 13);
            this.lblNumero.TabIndex = 7;
            this.lblNumero.Text = "n:";
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(523, 36);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(34, 13);
            this.lblBairro.TabIndex = 6;
            this.lblBairro.Text = "Bairro";
            // 
            // lblRua
            // 
            this.lblRua.AutoSize = true;
            this.lblRua.Location = new System.Drawing.Point(298, 36);
            this.lblRua.Name = "lblRua";
            this.lblRua.Size = new System.Drawing.Size(27, 13);
            this.lblRua.TabIndex = 5;
            this.lblRua.Text = "Rua";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(779, 52);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(39, 20);
            this.txtNumero.TabIndex = 4;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(524, 52);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(249, 20);
            this.txtBairro.TabIndex = 3;
            // 
            // txtRua
            // 
            this.txtRua.Location = new System.Drawing.Point(301, 52);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(217, 20);
            this.txtRua.TabIndex = 2;
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(22, 52);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(100, 20);
            this.txtCEP.TabIndex = 1;
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(19, 36);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(28, 13);
            this.lblCep.TabIndex = 0;
            this.lblCep.Text = "CEP";
            // 
            // FrmContatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 266);
            this.Controls.Add(this.gpbContatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContatos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro contatos";
            this.gpbContatos.ResumeLayout(false);
            this.gpbContatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbContatos;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.Label lblRua;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label Cidade;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button btnConsultaCEP;
    }
}