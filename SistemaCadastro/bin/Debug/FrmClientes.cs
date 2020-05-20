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
using CLRegras;

namespace SistemaCadastro
{
    public partial class FrmClientes : Form
    {
        ClCliente ClienteAtual;
  
        /// <summary>
        /// Construtor do formulario
        /// </summary>
        public FrmClientes()
        {
            try
            {
                Utils.Carregar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.InnerException);
            }
            InitializeComponent();

        }

        /// <summary>
        /// Metodo que limpa apenas os campos de texto
        /// </summary>
        private void LimparCampos()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtRg.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
            dgvContatos.Rows.Clear();
        }
        
        /// <summary>
        /// Metodo que adiciona um cliente novo a base de dados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void btnAddCliente_Click(object sender, EventArgs e)
        {
            string Nome = txtNome.Text;
            string cpf = txtCpf.Text;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            string RG = txtRg.Text;
            string telefone_fixo = txtTelefone.Text;
            string Celular = txtCelular.Text;
            string Email = txtEmail.Text;
            ClCliente cliente = new ClCliente(Nome, cpf, RG, telefone_fixo, Celular, Email);

            if (Utils.ValidaCpf(cpf))
            {
                if (Utils.AddClientes(cliente))
                {
                    ClienteAtual = Utils.GetClient(cpf);

                    btnAddContatos_Click(sender, e);//Me explique isso por favor.

                    MessageBox.Show("Cliente adicionado com sucesso");
                    LimparCampos();
                    dgvContatos.Rows.Clear();
                    Utils.EnviarEmailSistema("rafael.rezende@meioambiente.mg.gov.br", false, "Cadastro Realizado com sucesso", "E-mai informativo, nao responda");
                }
                else
                {

                    MessageBox.Show("Ja existe um cliente registrado com este CPF", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
            }
            else
            {
                MessageBox.Show("CPF invalido");
                txtCpf.Clear();
            }
        }
        
        /// <summary>
        /// Metodo de acionamento do botao adicionar um contato ao cliente, direciona para tela de contatos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddContatos_Click(object sender, EventArgs e)
        {
            dgvContatos.Rows.Clear();
            bool Editar = false;
            FrmContatos novoContato = new FrmContatos(ClienteAtual, dgvContatos, Editar);
            novoContato.ShowDialog();
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
        /// <param name="Contatos">recebe a lista de contatos referente ao cliente </param>
        public void PreencheGridContatos(List<ClContato> Contatos)
        {
            foreach (ClContato c in Contatos)
            {
                dgvContatos.Rows.Add(c.CEP, c.Rua, c.Bairro, c.Numero);
            }

        }

        public void dgvContatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Metodo que atualiza os contatos do cliente apos a exclusao ou edição dos contatos do mesmo
        /// </summary>
        /// <param name="clienteAtual"> Cliente que teve os dados de contato editados</param>
        /// <returns></returns>
        public List<ClContato> AtualizaContatos(ClCliente clienteAtual)
        {
           
            try
            {
                var Contatos = Utils.GetListaContatos().Where(x => x.Id == clienteAtual.cpf).ToList();
                return Contatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.InnerException);
                return null;
            }

        }
       
        /// <summary>
        /// Metodo que busca por um cliente especifico pelo <cpf> e preenche os campos da tela com os dados do cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnSalvar.Visible = true;
            try
            {
                string cpf = txtCpf.Text;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                ClienteAtual = Utils.GetClient(cpf);
                txtNome.Text = ClienteAtual.Nome;
                txtRg.Text = ClienteAtual.RG;
                txtTelefone.Text = ClienteAtual.telefone_fixo;
                txtCelular.Text = ClienteAtual.Celular;
                txtEmail.Text = ClienteAtual.Email;
                btnAddCliente.Hide();
                BtnCancela.Hide();
                btnLimpar.Visible = true;

                PreencheGridContatos(AtualizaContatos(ClienteAtual));

            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Digite o cpf do cliente que deseja buscar");
            }

        }
        
        /// <summary>
        /// Metodo limpa os campos da tela de cadastro e o grid de contatos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            btnAddCliente.Visible = true;
            BtnCancela.Visible = true;
            btnLimpar.Hide();
            dgvContatos.Rows.Clear();
        }
        
        /// <summary>
        /// Botao fechar limpa os campos e o grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFechar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            dgvContatos.Rows.Clear();

            DialogResult dialogResult = MessageBox.Show("Deseja Fechar?", "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Metodo que permite editar um contato especifico do cliente escolhido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                bool editar = true;
                FrmContatos cont = new FrmContatos(ClienteAtual, dgvContatos, editar);
                dgvContatos.Rows.Clear();
                cont.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.InnerException);
            }

        }
        
        /// <summary>
        /// Metodo que exluir um contato do cliente escolhido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection gridContatosRow = dgvContatos.SelectedRows;
                if (gridContatosRow.Count >= 1)
                {
                    foreach (DataGridViewRow rowA in gridContatosRow)
                    {
                        string id = dgvContatos.Rows[rowA.Index].Cells["CEP"].Value.ToString();
                        string num = dgvContatos.Rows[rowA.Index].Cells["Numero"].Value.ToString();
                        var contato = Utils.GetListaContatos().Where((x => x.CEP == id && x.Numero == num));
                        DialogResult dialogResult = MessageBox.Show("Deseja mesmo excluir este cliente?", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Utils.Remover(contato.First());
                            dgvContatos.Rows.Clear();
                            PreencheGridContatos(AtualizaContatos(ClienteAtual));                         
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
        
        /// <summary>
        /// Ação do botao ESC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnFechar_Click(sender, e);
            }
        }
        
        /// <summary>
        /// Metodo da ação do botao salvar, salva os dados do cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string cpf = txtCpf.Text;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            ClienteAtual.cpf = cpf;
            ClienteAtual.Nome = txtNome.Text;
            ClienteAtual.RG = txtRg.Text;
            ClienteAtual.telefone_fixo = txtTelefone.Text;
            ClienteAtual.Celular = txtCelular.Text;
            ClienteAtual.Email = txtEmail.Text;

            Utils.SalvarClientes();
            LimparCampos();
            dgvContatos.Rows.Clear();
        }
    }
}
