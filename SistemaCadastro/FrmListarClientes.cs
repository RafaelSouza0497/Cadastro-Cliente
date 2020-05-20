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
    public partial class FrmListarClientes : Form
    {
       
        
        public FrmListarClientes()
        {

            Utils.Carregar();
            InitializeComponent();
            PreencheGrid();
        }
        /// <summary>
        /// Preenche o data grid com os clientes do arquivo xml
        /// </summary>
        public void PreencheGrid()
        {
            foreach(ClCliente c in Utils.GetListaCliente())
            {

                dgvClientes.Rows.Add(c.Nome,c.cpf,c.RG,c.Celular,c.Email);
            }
        }
        
        /// <summary>
        /// Metodo que busca um cliente pelo cpf e destaca no drig view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int cont = 0;
            dgvClientes.ClearSelection();

            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if (row.Cells["ID"].Value != null)
                {
                    if (row.Cells["ID"].Value.ToString().Equals(txtCpfClientes.Text))
                    {
                        row.Selected = true;
                        cont +=1;
                        break;
                    }
                    
                }
                
            }
            if (cont == 0)
            {
                MessageBox.Show("Cliente nao encontrado!", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtCpfClientes.Clear();
        }
    }
}
