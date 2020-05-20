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
    public partial class FrmUsuarios : Form
    {
        public CLUsuario Usuario;
        
        /// <summary>
        /// O construtor carrega os dados e bloqueia as checkbox
        /// </summary>
        public FrmUsuarios(CLUsuario user)
        {
            this.Usuario = user;

            if (Usuario.perfil.Gravacao)
            {
                InitializeComponent();
                PreencheGridUsuarios();

            }
            else if (!Usuario.perfil.Gravacao)
            {
                InitializeComponent();
                PreencheGridUsuarios();
                btnEditar.Visible = false;
                btnExcluir.Visible = false;
                btnIncluir.Visible = false;

            }

        }

        /// <summary>
        /// Metodo adiciona os usuarios ao grid view
        /// </summary>
        public void PreencheGridUsuarios()
        {
            string status ="";
            string Permissao = "";
            foreach (CLUsuario u in Utils.GetListaUsuarios())
            {
                if (u.perfil == null)
                {
                    Permissao = "null";
                }
                else
                {

                    if (u.perfil.Id == ConstantesApp.Administrador)
                    {
                        Permissao = ConstantesApp.Administrador;
                    }
                    else if (u.perfil.Id == ConstantesApp.Gerente)
                    {
                        Permissao = ConstantesApp.Gerente;
                    }

                    else
                    {
                        Permissao = ConstantesApp.basico;
                    }
                }
                if (u.status == true)
                {
                    status = "Ativo";
                }
                else
                {
                    status = "Inativo";
                }


                dgvUsers.Rows.Add(u.Id, Permissao, status, u.Nome);

            }

        }

        /// <summary>
        /// Determina ação do click do mouse no check box especifico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvUsers.Rows.Clear();
        }

        /// <summary>
        /// Botao registrar usa os dados passados para adicionar um novo usuario ao sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuario cadastro = new FrmCadastroUsuario(false, dgvUsers);
            cadastro.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja Fechar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                dgvUsers.Rows.Clear();
                this.Close();
            }
        }

        /// <summary>
        /// Metodo define a Ação do botao esc 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnVoltar_Click(sender, e);
            }
        }

        /// <summary>
        /// Metodo que permite editar o usuario escolhido no grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection gridUserRow = dgvUsers.SelectedRows;
            if (gridUserRow.Count >= 1)
            {
                FrmCadastroUsuario cadastro = new FrmCadastroUsuario(true, dgvUsers);
                cadastro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Escolha um usuario primeiro!");
            }
        }

        /// <summary>
        /// Metodo de exclusao de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection gridUserRow = dgvUsers.SelectedRows;
                if (gridUserRow.Count >= 1)
                {
                    foreach (DataGridViewRow rowA in gridUserRow)
                    {
                        string Id = dgvUsers.Rows[rowA.Index].Cells["ID"].Value.ToString();
                        var User = Utils.GetListaUsuarios().Where(x => x.Id == Id).ToList();
                        DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir este usuario?", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Utils.Remover(User.First());
                            dgvUsers.Rows.Clear();
                            PreencheGridUsuarios();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Escolha um usuario primeiro!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Escolha apenas um de cada vez", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
