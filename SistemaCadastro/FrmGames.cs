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
    
    public partial class FrmGames : Form
    {
        public CLGames GameAtual;
       
        /// <summary>
        /// Construtor
        /// </summary>
        public FrmGames()
        {

            Utils.CarregarGames();
            InitializeComponent();
            PreencheGridGames();

        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCliente_Click_1(object sender, EventArgs e)
        {
           
            string Titulo = txtTitulo.Text;
            string Ano = txtAno.Text;
            string Produtora = txtProdutora.Text;          
            string valor = txtPreço.Text;       
            string Genero = txtGenero.Text;
            string plataforma = cbPlataforma.Text;

            CLGames Game = new CLGames(Titulo, Ano, Produtora, Genero,valor, plataforma);
            


            if (Utils.AddGames(Game))
            {
                GameAtual = Utils.GetGames(Titulo);
                MessageBox.Show("Game adicionado com sucesso", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);              
                LimparCampos();
                LimparGrid();

            }
            else
            {
                MessageBox.Show("Ja existe um Jogo registrado com este titulo", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            PreencheGridGames();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LimparCampos()
        {
            txtTitulo.Clear();
            txtAno.Clear();
            txtProdutora.Clear();
            txtPreço.Clear();
            txtGenero.Text="";
            cbPlataforma.Text="";
           
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void LimparGrid()
        {
            dgvGames.Rows.Clear();
        }
        
        /// <summary>
        /// Botao cancela permite ao usuario limpar os campos caso tenha digitado dados errados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancela_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        /// <summary>
        /// Metodo que preenche o grid com os contatos do cliente 
        /// </summary>
        /// <param name="Games">recebe a lista geral  de Games  </param>
        public void PreencheGridGames()
        {
            List<CLGames> Lista = Utils.GetListaGames();
            foreach (CLGames game in Lista)
            {
                dgvGames.Rows.Add(game.Titulo, game.Ano, game.Produtora, game.Genero, game.Plataforma, game.Preco);
            }

        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnSalvar.Visible = true;
            DataGridViewSelectedRowCollection gridGamesRow = dgvGames.SelectedRows;

            foreach (DataGridViewRow rowA in gridGamesRow)
            {
                try
                {
                    string Title = dgvGames.Rows[rowA.Index].Cells["Titulo"].Value.ToString();
                    var Jogo = Utils.GetListaGames().Where(x => x.Titulo == Title).ToList();
                    LimparCampos();
                    PreencheCampos(Jogo.First().Titulo, Jogo.First().Ano, Jogo.First().Produtora, Jogo.First().Genero, Jogo.First().Plataforma, Jogo.First().Preco);
                    GameAtual = Jogo.First();
                }
                catch (Exception)
                {
                    MessageBox.Show("Escolha apenas um de cada vez", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
           
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            GameAtual.Titulo = txtTitulo.Text;
            GameAtual.Ano = txtAno.Text;
            GameAtual.Produtora = txtProdutora.Text;
            GameAtual.Preco = txtPreço.Text;           
            GameAtual.Genero = txtGenero.Text;
            GameAtual.Plataforma = cbPlataforma.Text;
            Utils.SalvarGames();
            LimparCampos();
            LimparGrid();
            PreencheGridGames();
        }
      
        /// <summary>
        /// Preenche os campos com os dados do game escolhido no grid
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="ano"></param>
        /// <param name="produtora"></param>
        /// <param name="genero"></param>
        /// <param name="plataforma"></param>
        /// <param name="preco"></param>
        public void PreencheCampos(string titulo, string ano, string produtora, string genero,string plataforma, string preco)
        {
            txtTitulo.Text = titulo;
            txtAno.Text = ano;
            txtProdutora.Text = produtora;
            txtPreço.Text = preco;
            cbPlataforma.SelectedText = plataforma;
            txtGenero.Text = genero;
        }
     
        /// <summary>
        /// Limpa os campos e o data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            LimparCampos();
            LimparGrid();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFechar_Click_1(object sender, EventArgs e)
        {           
            DialogResult dialogResult = MessageBox.Show("Deseja Fechar?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                btnLimpar_Click_1(sender,e);
                this.Close();
            }
        }

        /// <summary>
        /// Metodo define a ação da tecla esc no teclado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGames_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                btnFechar_Click_1(sender, e);
            }
        }

        /// <summary>
        /// Metodo que permite excluir um game do drig view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection gridGamesRow = dgvGames.SelectedRows;

            foreach (DataGridViewRow rowA in gridGamesRow)
            {
                string Title = dgvGames.Rows[rowA.Index].Cells["Titulo"].Value.ToString();
                var Jogo = Utils.GetListaGames().Where(x => x.Titulo == Title).ToList();
                DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir este game??", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Utils.Remover(Jogo.Single());
                    dgvGames.Rows.Clear();
                    PreencheGridGames();
                }
                else
                {
                    break;
                }

            }
        }
    
    }
}
