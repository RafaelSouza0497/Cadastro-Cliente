using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClEntidades
{
    public static class ConstantesApp
    {
        public const string Gerente = "Gerente";
        public const string Administrador = "Administrador";
        public const string basico = "basico";
        public const string MsgGenerica = "Cadastro efetuado com sucesso!";
        #region Listas de Dados
        public static List<ClCliente> Lista_Clientes = new List<ClCliente>();
        public static List<ClContato> Lista_Contatos = new List<ClContato>();
        public static List<CLUsuario> Lista_Usuarios = new List<CLUsuario>();
        public static List<CLGames> Lista_Games = new List<CLGames>();
        #endregion
       
    }
}
