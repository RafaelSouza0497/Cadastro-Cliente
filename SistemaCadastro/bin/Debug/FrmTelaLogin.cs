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
    public partial class FrmTelaLogin : Form
    {
        
        public FrmTelaLogin()
        {
            Utils.CarregarUsuarios();
            
            InitializeComponent();
        }

        /// <summary>
        /// Metodo tentar logar no sistema chamando o  metodo de validação de login
        /// </summary>
        public void TryConnection()
        {
            string Id = txbUsuario.Text;
            string Pass = txbSenha.Text;

            if (Utils.ValidaLogin(Id, Pass, Utils.GetListaUsuarios()))
            {
                //LimparCampos();

                CLUsuario user = Utils.GetUsuarios(Id);
                FrmMenuInicial TelaInicial = new FrmMenuInicial(user);
                TelaInicial.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Usuario ou senha incorretos!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Botao entrar tenta logar no sistema usando os dados passados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            TryConnection();
        }

        /// <summary>
        /// Limpa os campos preenchidos
        /// </summary>
        private void LimparCampos()
        {
            txbUsuario.Clear();
            txbSenha.Clear();
        }

        /// <summary>
        /// Cancela a ação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }


        /// <summary>
        /// Este Metodo usa a ação do botao enter para ativar o botao entrar deste formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TelaLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
        }

        /// <summary>
        /// Metodo de acionamento do botao Esqueci minha senha que direciona para o formulario de criação da nova senha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEsqueciMinhaSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txbUsuario.Text))
            {
                FrmRecuperaSenha Rec = new FrmRecuperaSenha(txbUsuario.Text);
                Rec.ShowDialog();
                Utils.CarregarUsuarios();
            }
            else
            {
                MessageBox.Show("Digite seu usuario!", this.Name, MessageBoxButtons.OK);
            }
        }

        private void PrimeiroAcesso_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataGridView dgvUsers=new DataGridView();
            FrmCadastroUsuario cadastro = new FrmCadastroUsuario(false, dgvUsers);
            cadastro.ShowDialog();
           
        }
    }
}
