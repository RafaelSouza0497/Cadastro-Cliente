using System;
using ClEntidades;
using CLRegras;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FrmNovaSenha : Form
    {
        CLUsuario Usuario;
      
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="user"></param>
        public FrmNovaSenha(CLUsuario user)
        {
            this.Usuario = user;
            InitializeComponent();
        }
      
        /// <summary>
        /// Aqui a nova senha é criada pelo usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (txtConfirmação.Text == txtSenha.Text)
            {
                Usuario.Senha = txtSenha.Text;
                Utils.SalvarUsuarios();
                MessageBox.Show("Nova senha cadastrada com sucesso!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);              
                this.Close();
            }
            else
            {
                MessageBox.Show("As senhas nao coincidem", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
    }
}
