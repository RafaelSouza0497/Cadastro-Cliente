using CLRegras;
using ClEntidades;
using System;
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
    public partial class FrmMenuInicial : Form
    {
       
        public CLUsuario Usuario;
        
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="User"></param>
        public FrmMenuInicial(CLUsuario User)
        {
           
            if (User.perfil.Id == "Gerente" || User.perfil.Id == "Administrador")
            {
                this.Usuario = User;
                InitializeComponent();
            } else if (User.perfil.Id == "Basico")
            {
                this.Usuario = User;
                InitializeComponent();
                registroToolStripMenuItem.Visible = false;
                clienteToolStripMenuItem.Visible = false;
            }
           
        }
        
        /// <summary>
        /// Abre a tela de cadastro de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.ShowDialog();
        }
       
        /// <summary>
        /// Metodo Sair mostra uma mensagem de SIM ou NAO para o usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja Fechar?", "Logoff", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        /// <summary>
        /// Abre a aba de registro de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
            if (this.Usuario.perfil.Leitura && this.Usuario.perfil.Gravacao)
            {
                FrmUsuarios usuario = new FrmUsuarios(Usuario);
                usuario.ShowDialog();
            }
            
        }
        /// <summary>
        /// Abre a aba de games
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               FrmGames Games = new FrmGames();
                Games.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu algum erro");
            }
        }
        
        /// <summary>
        /// Abre a aba de trocr usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trocarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            FrmTelaLogin tela = new FrmTelaLogin();
            this.Hide();
            tela.ShowDialog();
            this.Close();
        }
        
        /// <summary>
        /// Abre a aba de redefinição de senha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redefinirSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNovaSenha nova = new FrmNovaSenha(this.Usuario);
                nova.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu algum erro"+ex.Message);
            }
        }

        /// <summary>
        /// Abre a aba de Listar todos os clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmListarClientes lista = new FrmListarClientes();
                lista.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu algum erro" + ex.Message);
            }
           
        }
    }
}
