using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClEntidades
{
    public class ClContato
    {

        public string Id { get; set; }// CPF do cliente a qual este contato foi regristrado
        public  string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public ClContato() { }

        public ClContato(string cep,string rua , string bairro, string num,string city,string Estate )
        {
            this.Id = "";
            this.CEP = cep;
            this.Rua = rua;
            this.Bairro = bairro;
            this.Numero = num;
            this.Cidade = city;
            this.Estado = Estate;
            
        }
    }
}
