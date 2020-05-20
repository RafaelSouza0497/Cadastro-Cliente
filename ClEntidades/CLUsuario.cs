using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClEntidades
{
    public class CLUsuario
    {
        public string Id { get; set; }
        public string Senha { get; set; }
        public string Confirmacao { get; set; }
        public bool status { get; set; }
        public string Nome { get; set; }
        public string Email { get; set;}
        //public bool Adm { get; set; }
        public Perfil perfil { get; set; }

        public CLUsuario(string id, string senha,string email,string nome)
        {
            perfil = new Perfil();        
            this.status = true;
            this.Id = id;
            this.Senha = senha;
            Email = email;
            Nome = nome;
        }
        public CLUsuario() { }
        

        
        
    }
    
}
