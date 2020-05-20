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
    public partial class FrmCadastroUsuario : Form
    {
        
        public bool Editar;
        public CLUsuario Atual;
        public DataGridView Grid;

        public FrmCadastroUsuario(bool editar, DataGridView Data)
        {
            this.Grid = Data;
            this.Editar = editar;
            if (Editar)
            {
                InitializeComponent();
                PreencheCampos();
            }
            else
            {
                InitializeComponent();
            }

        }

        /// <summary>
        /// Limpa todos os preenchimentos da tela
        /// </summary>
        public void LimparCampos()
        {
            txbEmail.Clear();
            txbSenha.Clear();
            txbUsuario.Clear();
            txbPerfil.SelectedText = "";
            this.Close();

        }
       
        /// <summary>
        /// Preenche os campos com os dados do usuario selecionado para ser editado
        /// </summary>
        public void PreencheCampos()
        {
            if (Grid != null)
            {
                DataGridViewSelectedRowCollection gridContatosRow = Grid.SelectedRows;

                foreach (DataGridViewRow rowA in gridContatosRow)
                {
                    string id = Grid.Rows[rowA.Index].Cells["Id"].Value.ToString();
                    var Usuario = Utils.GetListaUsuarios().Where(x => x.Id == id).ToList();
                    this.Atual = Usuario.First();
                    txbEmail.Text = Atual.Email;
                    txbUsuario.Text = Atual.Id;
                    txbUsuario.Enabled = false;
                    txbSenha.Text = Atual.Senha;
                    txbSenha.Enabled = false;
                    txbConfirma.Enabled = false;
                    txtNome.Text = Atual.Nome;
                    if (Atual.perfil == null)
                    {
                        txbPerfil.Text = "null";
                    }
                    else { txbPerfil.Text = Atual.perfil.Id; }
                    

                }
            }
            else
            {
                MessageBox.Show("Carregue um usuario primeiro");
            }
        }
        
        /// <summary>
        /// Metodo salvar da ação do botao que salva um usuario que esta sendo cadastrado ou editado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Editar)
                {
                    if (Utils.ValidaSenha(txbSenha.Text))
                    {

                        if (txbSenha.Text == txbConfirma.Text)
                        {

                            string Id = txbUsuario.Text;
                            string Pass = txbSenha.Text;
                            string Email = txbEmail.Text;
                            string Nome = txtNome.Text;
                            CLUsuario User = new CLUsuario(Id, Pass, Email, Nome);
                            User.perfil.Id = txbPerfil.Text;
                            if (Utils.ValidaCpf(Id))
                            {
                                if (Utils.AddUsuarios(User))
                                {
                                    Utils.AtualizaPermissoes(User);
                                    Utils.SalvarUsuarios();
                                    Utils.CarregarUsuarios();
                                    MessageBox.Show(ConstantesApp.MsgGenerica, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    LimparCampos();
                                    Grid.Rows.Clear();
                                    AtualizaGrid();
                                }
                                else
                                {
                                    MessageBox.Show("Ja existe um usuario registrado com este Id", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    LimparCampos();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Id invalido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txbUsuario.Clear();
                            }


                        }
                        else
                        {
                            MessageBox.Show("A senhas nao correspondem!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txbSenha.Clear();
                            txbConfirma.Clear();
                        }
                    }
                    else

                        MessageBox.Show("A senha deve ter no minimo um caracter especial,um letra maiuscula e minimo 6 caracteres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {

                    //Atual.Id=txbUsuario.Text;
                    Atual.Nome = txtNome.Text;
                    Atual.Email = txbEmail.Text;
                    Atual.perfil = new Perfil();
                    Atual.perfil.Id = txbPerfil.Text;
                    Utils.AtualizaPermissoes(Atual);
                    Utils.SalvarUsuarios();
                    Utils.CarregarUsuarios();
                    MessageBox.Show("Usuario editado com sucesso");
                    LimparCampos();
                    Grid.Rows.Clear();
                    AtualizaGrid();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Erro:");
            }

        }

        /// <summary>
        /// Metodo atualiza o grid de usuarios dps de alguma modificação feita
        /// </summary>
        public void AtualizaGrid()
        {
            try
            {
                foreach (CLUsuario u in Utils.GetListaUsuarios())
                {
                    Grid.Rows.Add(u.Id, u.perfil.Id, u.status, u.Nome);
                }

            }
            catch (Exception)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Metodo cacelar limpa os campos e fecha a tela de acadastros de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            this.Close();
        }
    }
}
