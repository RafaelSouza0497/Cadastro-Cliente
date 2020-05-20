using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Configuration;
using ClEntidades;

namespace ClData
{
    public static class Crud
    {
       #region Paths dos arquivos    
        
        private static string PathCliente = ConfigurationManager.AppSettings["CaminhoCliente"].ToString();
        private static string PathContato = ConfigurationManager.AppSettings["CaminhoContatos"].ToString();
        private static string PathUser = ConfigurationManager.AppSettings["CaminhoUsuarios"].ToString();
        private static string PathJogos = ConfigurationManager.AppSettings["CaminhoGames"].ToString();
        private static string PathDir = ConfigurationManager.AppSettings["CaminhoPasta"].ToString();
        #endregion

        #region Listas de Dados
        public static List<ClCliente> Lista_Clientes = new List<ClCliente>();
        public static List<ClContato> Lista_Contatos = new List<ClContato>();
        public static List<CLUsuario> Lista_Usuarios = new List<CLUsuario>();
        public static List<CLGames> Lista_Games = new List<CLGames>();
        #endregion

        //Metodos referentes a inserção de arquivos de clientes e contatos//    

        #region Crud clientes/Contatos

        /// <summary>
        /// Metodo encontra um cliente na lista
        /// </summary>
        /// <param name="Id">cpf do cliente usado como parametro na busca</param>
        /// <returns></returns>
        public static ClCliente Buscar(string Id)
        {
            try
            {
                return Lista_Clientes.Where(x => x.cpf == Id).ToList().Single();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        /// <summary>
        ///Metodo Adiciona um novo cliente na lista 
        /// </summary>
        /// <param name="novo">O objeto cliente a ser adicionado </param>
        /// <returns></returns>
        public static bool AdicionaCliente(ClCliente novo)
        {
            try
            {
                Lista_Clientes.Add(novo);
                SalvarClientes();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }

        }

        /// <summary>
        ///Metodo Adiciona um novo contato na lista
        /// </summary>
        /// <param name="novo">O objeto contato a ser adicionado</param>
        /// <returns></returns>
        public static bool AdicionaContato(ClContato novo)
        {
            try
            {

                if (Lista_Contatos.Count(c => c.Equals(novo)) > 0)
                {
                    throw new Exception("Este contato ja existe");
                }

                else
                {
                   Lista_Contatos.Add(novo);
                    SalvarContatos();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }


        }

        /// <summary>
        /// Metodo generico que remove um objeto da lista, podendo ser passado um objeto Cliente ou um Contato
        /// </summary>
        /// <param name="atual">Objeto que sera removido(CLCliente/CLContato)</param>
        public static void Remover(Object atual)
        {
            try
            {
                if (atual is ClCliente)
                {
                    ClCliente aux = (ClCliente)atual;
                    Lista_Clientes.Remove(aux);
                    XmlSerializer serial = new XmlSerializer(typeof(List<ClCliente>));
                    FileStream fileCliente = new FileStream(PathCliente, FileMode.Create);
                    serial.Serialize(fileCliente, Lista_Clientes);
                    fileCliente.Close();

                }
                else if (atual is ClContato)
                {
                    ClContato aux = (ClContato)atual;
                    Lista_Contatos.Remove(aux);
                    XmlSerializer serial = new XmlSerializer(typeof(List<ClContato>));
                    FileStream fileContato = new FileStream(PathContato, FileMode.Create);
                    serial.Serialize(fileContato, Lista_Contatos);
                    fileContato.Close();
                    // SalvarContatos();d

                }
                else if (atual is CLGames)
                {
                    CLGames aux = (CLGames)atual;
                    Lista_Games.Remove(aux);
                    XmlSerializer serial = new XmlSerializer(typeof(List<CLGames>));
                    FileStream fileGames = new FileStream(PathJogos, FileMode.Create);
                    serial.Serialize(fileGames, Lista_Games);
                    fileGames.Close();

                }
                else if (atual is CLUsuario)
                {
                    CLUsuario aux = (CLUsuario)atual;
                    Lista_Usuarios.Remove(aux);
                    XmlSerializer serial = new XmlSerializer(typeof(List<CLUsuario>));
                    FileStream fileUser = new FileStream(PathUser, FileMode.Create);
                    serial.Serialize(fileUser, Lista_Usuarios);
                    fileUser.Close();
                }

            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }

        }

        /// <summary>
        /// Metodo Salva o arquivo de clientes para que seja atualizado com possiveis alterações feitas
        /// </summary>
        public static void SalvarContatos()
        {
            try
            {
                XmlSerializer serial2 = new XmlSerializer(typeof(List<ClContato>));
                FileStream fileContato = new FileStream(PathContato, FileMode.OpenOrCreate);
                serial2.Serialize(fileContato, Lista_Contatos);
                fileContato.Close();
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }
        }

        /// <summary>
        /// Metodo Salva o arquivo de contatos para que seja atualizado com possiveis alterações feitas
        /// </summary>
        public static void SalvarClientes()
        {
            try
            {
                XmlSerializer serial = new XmlSerializer(typeof(List<ClCliente>));//cria um objeto serializer
                FileStream fileCliente = new FileStream(PathCliente, FileMode.OpenOrCreate);//Cria um arquivo, FileMode.OpenOrCreate abre o arquivo se ja existir, se nao ele cria o arquivo
                serial.Serialize(fileCliente,Lista_Clientes);//os parametros sao o diretorio e de qual estrutura vai sair os dados
                fileCliente.Close();//fecha o arquivo depois de criado ou editado
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }
        }

        /// <summary>
        /// Metodo Salva simultaneamente o arquivo de cliente e contato
        /// </summary>
        public static void Salvar()
        {
            SalvarContatos();
            SalvarClientes();

        }

        /// <summary>
        /// Carrega as listas de cliente e contato com os dados dos arquivo XML
        /// </summary>
        public static void Carregar()
        {
            try
            {
                XmlSerializer serial1 = new XmlSerializer(typeof(List<ClCliente>));//cria um objeto serializer
                XmlSerializer serial2 = new XmlSerializer(typeof(List<ClContato>));


                if (!Directory.Exists(PathDir))
                {
                    Directory.CreateDirectory(PathDir);
                }
                else
                {

                    if (File.Exists(PathCliente))
                    {
                        FileStream fileCliente = new FileStream(PathCliente, FileMode.Open);//Cria um arquivo, FileMode.OpenOrCreate abre o arquivo se ja existir, se nao ele cria o arquivo
                        Lista_Clientes = serial1.Deserialize(fileCliente) as List<ClCliente>;// usa o metodo Deserialize para ler o arquivo e salvar em uma List<>
                        fileCliente.Close();
                    }
                    else
                    {
                        FileStream fileCliente = new FileStream(PathCliente, FileMode.Create);
                        serial1.Serialize(fileCliente,Lista_Clientes);
                        fileCliente.Close();
                    }

                    if (File.Exists(PathContato))
                    {
                        FileStream fileContato = new FileStream(PathContato, FileMode.Open);
                        Lista_Contatos = serial2.Deserialize(fileContato) as List<ClContato>;
                        fileContato.Close();
                    }
                    else
                    {
                        FileStream fileContato = new FileStream(PathContato, FileMode.Create);
                        serial2.Serialize(fileContato,Lista_Contatos);
                        fileContato.Close();
                    }

                }
            }
            catch (Exception) { }
        }
        #endregion
        
        //######Metodos referentes aos Usuarios do sistema#####//
        #region Crud usuarios
        /// <summary>
        /// Metodo que busca um usuario especifico no arquivo e retorn
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static CLUsuario BuscarUser(string Id)
        {
            try
            {
                return Lista_Usuarios.Where(x => x.Id == Id).ToList().First();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo Adiciona um novo usuario a lista de usuarios
        /// </summary>
        /// <param name="novo">O objeto usuario que vai ser adicionado a list ja com os parametros preenchidos</param>
        /// <returns></returns>    
        public static bool AdicionaUsuario(CLUsuario novo)
        {
            try
            {
                if (Lista_Usuarios.Count(c => c.Id.Equals(novo.Id)) > 0)
                {
                    return false;
                }
                else
                {
                    Lista_Usuarios.Add(novo);
                    SalvarUsers();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);

            }
        }

        /// <summary>
        /// Salva o usuario criado no arquivo XML
        /// </summary>
        public static void SalvarUsers()
        {
            try
            {
                XmlSerializer serial = new XmlSerializer(typeof(List<CLUsuario>));//cria um objeto serializer
                FileStream file = new FileStream(PathUser, FileMode.Create);//Cria um arquivo, FileMode.OpenOrCreate abre o arquivo se ja existir, se nao ele cria o arquivo        
                serial.Serialize(file,Lista_Usuarios);//os parametros sao o diretorio e de qual estrutura vai sair os dados
                file.Close();//fecha o arquivo depois de criado ou editado
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }
        }

        /// <summary>
        /// Carrega os dados do arquivo para o objeto list
        /// </summary>
        public static void CarregarUsers()
        {
            XmlSerializer serial3 = new XmlSerializer(typeof(List<CLUsuario>));
            FileStream fileUser = new FileStream(PathUser, FileMode.OpenOrCreate);


            try
            {
                Lista_Usuarios = serial3.Deserialize(fileUser) as List<CLUsuario>;
            }
            catch (Exception)
            {
                serial3.Serialize(fileUser,Lista_Usuarios);
            }
            finally
            {
                fileUser.Close();
            }
        }
        #endregion

        //###### Metodos referentes ao Games cadastrados#####//
        #region Crud Jogos

        /// <summary>
        /// Metodo busca um jogo especifico e retorna o objeto
        /// </summary>
        /// <param name="Titulo"></param>
        /// <returns></returns>
        public static CLGames BuscarJogos(string Titulo)
        {
            try
            {
                return Lista_Games.Where(x => x.Titulo == Titulo).ToList().Single();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Adiciona um novo jogo a lista e no arquivo
        /// </summary>
        /// <param name="novo"></param>
        /// <returns></returns>
        public static bool Adicionagame(CLGames novo)
        {
            if (Lista_Games.Count(c => c.Titulo.Equals(novo.Titulo)) > 0)
            {
                return false;
            }
            else
            {
                novo.Id = Lista_Games.Count();
                Lista_Games.Add(novo);
                SalvarGames();
                return true;

            }
        }
       
        /// <summary>
        /// Salva o arquivo com a lista de games atual
        /// </summary>
        public static void SalvarGames()
        {
            try
            {
                XmlSerializer serial = new XmlSerializer(typeof(List<CLGames>));//cria um objeto serializer
                FileStream file = new FileStream(PathJogos, FileMode.Create, FileAccess.Write);//Cria um arquivo, FileMode.OpenOrCreate abre o arquivo se ja existir, se nao ele cria o arquivo
                serial.Serialize(file,Lista_Games);//os parametros sao o diretorio e de qual estrutura vai sair os dados
                file.Close();//fecha o arquivo depois de criado ou editado}

            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }
        }
        
        /// <summary>
        /// Carrega os dados do arquivo na lista de games
        /// </summary>
        public static void CarregarJogos()
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<CLGames>));
            FileStream file = new FileStream(PathJogos, FileMode.OpenOrCreate);
            try
            {
               Lista_Games = serial.Deserialize(file) as List<CLGames>;// usa o metodo Deserialize para ler o arquivo e salvar em uma List<>
            }
            catch (Exception)
            {
                serial.Serialize(file,Lista_Games);
            }
            finally
            {
                file.Close();
            }
        }
    }
}
#endregion  
