using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClEntidades
{
    public class Perfil
    {
        public string Id { get; set; }
        public bool Leitura { get; set; }
        public bool Gravacao { get; set; }

        public Perfil(string id)
        {
            this.Id = id;
        }
        public Perfil() { }

        
        
    }
}
