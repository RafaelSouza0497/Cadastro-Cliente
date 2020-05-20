using System;
using ClEntidades;
using System.Collections.Generic;
using CLRegras;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FrmRecuperaSenha : Form
    {
        CLUsuario Atual;
        int Codigo;
        
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="user"></param>
        public FrmRecuperaSenha(string user)
        {
            Atual= Utils.GetListaUsuarios().Where(x =>x.Id == user).ToList().Single();
            InitializeComponent();
            PreencheEmail();
        }
        
        /// <summary>
        /// Metodo preenche o email na textbox com uma 'mascara'
        /// </summary>
        public void PreencheEmail()
        {
            var Inicio = Atual.Email.Take(3).ToList();
            var meio = "...";
            var final = Atual.Email.SkipWhile(x => x != '@').Take(10).ToList();
            var Frase = Inicio.Concat(meio).Concat(final);
            foreach (char i in Frase)
            {
                txtEmailRecuperacao.Text += i;
            }
            txtEmailRecuperacao.Enabled = false;
        }
       
        /// <summary>
        /// Metodo de acionamento do botao de envio do codigo para o email do usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            
                Random Rand = new Random();
                Codigo = Rand.Next(10000);
                try
                {
                    Utils.EnviarEmailSistema("rafael.rezende@meioambiente.mg.gov.br", false, "Recuperação de Senha", Convert.ToString(Codigo));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
                txtEmailRecuperacao.Enabled = false;
                MessageBox.Show("E-mail enviado !\nCaso não consiga visualizar clique em reenviar!");
                btnEnviar.Visible = false;
                btnReenviar.Visible = true;
            
            
        }
       
        /// <summary>
        /// Metodo validar le o codigo passado pelo cliente e confere se foi o mesmo enviado por email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                if (txtCodigo.Text == Convert.ToString(Codigo))
                {                    
                    FrmNovaSenha Pass = new FrmNovaSenha(Atual);
                    Pass.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("O Codigo informado é invalido!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);                  
                }
            }
            else
            {
                MessageBox.Show("Digite o codigo no campo acima!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        /// <summary>
        /// Metodo reenvia o codigo caso o usuario nao tenha recebido corretamente no email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReenviar_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.EnviarEmailSistema("rafael.rezende@meioambiente.mg.gov.br", false, "Recuperação de Senha", Convert.ToString(Codigo));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
    }
}
