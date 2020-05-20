using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClEntidades
{
    public class ClCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string cpf { get; set; }
        public string RG { get; set; }     
        public string telefone_fixo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string senha { get; set; }
        //public List<ClContato> Contatos { get; set; }

        public ClCliente()
        {

        }
        public ClCliente(string nome, string cpf, string RG, string telefone_fixo, string Celular,string email)
        {
            //this.Contatos = new List<ClContato>();
            this.Nome = nome;
            this.cpf = cpf;
            this.RG = RG;
            this.telefone_fixo = telefone_fixo;
            this.Celular = Celular;
            this.Email = email;
        }

      
    }
}
