using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClEntidades
{
    public partial class CLGames
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public string Produtora { get; set; }
        public string Genero { get; set; }
        public string Plataforma { get; set; }
        public string Preco { get; set; }
        public int Recorrencia { get; set; }
        public double Avaliacoes { get; set; }
        public int QuantAvaliacao { get; set; }
        

        public CLGames()
        {

        }
        public CLGames(string titulo)
        {
            Titulo = titulo;
        }
        public CLGames(string titulo, string ano, string produtora, string genero, string preco,string plataforma)
        {
            Titulo = titulo;
            Ano = ano;
            Produtora = produtora;
            Genero = genero;
            Plataforma = plataforma;
            Preco = preco;
            Recorrencia = 0;
            Avaliacoes = 0;
            QuantAvaliacao = 0;
        }
    
        public double  GetMediaAvalicao()
        {
            return Avaliacoes / QuantAvaliacao;
        }
    }
}
