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
    public partial class FrmContatos : Form
    {
        
        public ClCliente ClienteAtual;//Cliente que tera o contato editado ou adicionado
        public DataGridView Grid;//grid view do formulario Cliente passado como parametro para ser atualizado
        public bool edit;//variavel de validação para definir se sera uma adição ou um edição
        public ClContato cont;//O contato que esta sendo editado

        /// <summary>
        /// Metodo usado apenas quando um contato estiver sendo editado
        /// Preenche as caixas de texto com os dados do contato escolhido
        /// </summary>
        public void PreencheTexto()
        {
            if (Grid != null)
            {
                DataGridViewSelectedRowCollection gridContatosRow = Grid.SelectedRows;

                foreach (DataGridViewRow rowA in gridContatosRow)
                {
                    string id = Grid.Rows[rowA.Index].Cells["CEP"].Value.ToString();
                    string num = Grid.Rows[rowA.Index].Cells["Numero"].Value.ToString();
                    var contato = Utils.GetListaContatos().Where((x => x.CEP == id && x.Numero == num)).ToList();
                    this.cont = contato.First();
                    txtCEP.Text = contato.First().CEP;
                    txtRua.Text = contato.First().Rua;
                    txtBairro.Text = contato.First().Bairro;
                    txtNumero.Text = contato.First().Numero;
                }
            }
            else
            {
                MessageBox.Show("Carregue um usuario primeiro");
            }

        }

        /// <summary>
        /// O construtor 
        /// </summary>
        /// <param name="Cliente"> o cliente atual o qual esta sendo editado</param>
        /// <param name="Contatos"> a lista de contatos deste cliente. Passada para realizar a adição do novo contato</param>
        /// <param name="editar">variavel de validação. O formulario pode ser chamado para adicionar ou editar um contato</param>
        public FrmContatos(ClCliente Cliente, DataGridView Contatos, bool editar)
        {
            this.ClienteAtual = Cliente;
            this.Grid = Contatos;
            this.edit = editar;
            if (edit)
            {
                InitializeComponent();
                PreencheTexto();
            }
            else InitializeComponent();

        }

        /// <summary>
        /// Preenche o grid com a lista de contatos atualizada apos edição
        /// metodo chamado na ação de fechamento da tela
        /// </summary>
        public void PreencheGrid()
        {
            try
            {
                var cont = Utils.GetListaContatos().Where(x => x.Id == ClienteAtual.cpf).ToList();

                foreach (ClContato c in cont)
                {
                    Grid.Rows.Add(c.CEP, c.Rua, c.Bairro, c.Numero);
                }

            }
            catch (Exception)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Limpa todas das caixas de texto
        /// </summary>
        private void LimparCampos()
        {
            txtCEP.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtNumero.Clear();

        }

        /// <summary>
        /// Cancela a operção e limpa os campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            this.Close();
        }

        /// <summary>
        /// Metodo salva a edição feita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                try
                {
                    ClContato NovoContato = new ClContato();
                    NovoContato.CEP = txtCEP.Text;
                    NovoContato.Rua = txtRua.Text;
                    NovoContato.Bairro = txtBairro.Text;
                    NovoContato.Numero = txtNumero.Text;
                    NovoContato.Id = ClienteAtual.cpf;
                    // ClienteAtual.Contatos.Add(NovoContato);
                    if (Utils.AddContatos(NovoContato))
                    {                    
                        MessageBox.Show("Contato adicionado com sucesso", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Ja existe este contato registrado");
                        LimparCampos();
                    }



                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Primeiro escolha o cliente que deseja atualizar");
                    LimparCampos();
                    this.Close();
                }
            }
            else
            {
                try
                {
                    cont.CEP = txtCEP.Text;
                    cont.Rua = txtRua.Text;
                    cont.Bairro = txtBairro.Text;
                    cont.Numero = txtNumero.Text;
                    cont.Id = ClienteAtual.cpf;
                    Utils.SalvarContatos();
                    Utils.Carregar();                    
                    MessageBox.Show("Contato editado com sucesso", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocorreu algum erro");
                }
            }



        }

        /// <summary>
        /// Fecha o formulario e atualiza o grid de contatos atualizado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFechar_Click(object sender, EventArgs e)
        {
            PreencheGrid();
            this.Close();
        }
    
        /// <summary>
        /// Metodo que faz a consulta do cep informado no web service dos correios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsultaCEP_Click(object sender, EventArgs e)
        {
            ClContato Contato = new ClContato();
            try
            {
                var ws = new WSCorreios.AtendeClienteClient();
                var endereco = ws.consultaCEP(txtCEP.Text);
                txtEstado.Text = endereco.uf;
                txtCidade.Text = endereco.cidade;
                txtBairro.Text = endereco.bairro;
                txtRua.Text = endereco.end;

            }
            catch (Exception ex)
            {            
                MessageBox.Show("Erro ao efetuar busca do CEP: {0}"+ ex.Message, this.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
