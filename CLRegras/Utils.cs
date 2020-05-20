using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Correios.Net;
using ClData;
using ClEntidades;
using System.Xml.Serialization;
using System.IO;

namespace CLRegras
{
    public static  class Utils
    {      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  static ClCliente GetClient(string id)
        {
            
            return Crud.Buscar(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CLUsuario GetUsuarios(string id)
        {
            
            return Crud.BuscarUser(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CLGames GetGames(string id)
        {
           
            return Crud.BuscarJogos(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static  List<ClCliente>  GetListaCliente()
        {
            return Crud.Lista_Clientes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ClContato>  GetListaContatos()
        {
            return Crud.Lista_Contatos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<CLUsuario> GetListaUsuarios()
        {
            return Crud.Lista_Usuarios;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<CLGames> GetListaGames()
        {
            return Crud.Lista_Games;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="novo"></param>
        /// <returns></returns>
        public static bool AddContatos(ClContato novo)
        {
            try
            {
                Crud.AdicionaContato(novo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static bool AddClientes(ClCliente cliente)
        {
           

            try
            {
                Crud.AdicionaCliente(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public static bool AddUsuarios(CLUsuario User)
        {
            

            try
            {
                Crud.AdicionaUsuario(User);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static bool AddGames(CLGames game)
        {
            try
            {
                Crud.Adicionagame(game);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="atual"></param>
        public static void Remover(Object atual)
        {
            Crud.Remover(atual);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Carregar()
        {
            Crud.Carregar();    
        }
        /// <summary>
        /// 
        /// </summary>
        public static void CarregarGames()
        {
           
            Crud.CarregarJogos();
        }
        /// <summary>
        /// 
        /// </summary>
        public static  void CarregarUsuarios()
        {
            
            Crud.CarregarUsers();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void SalvarContatos()
        {
            
            Crud.SalvarContatos();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public static void EditarCliente(ClCliente client)
        {

            ClCliente ClienteAtual = Crud.Lista_Clientes.Where(c => c.cpf == client.cpf).ToList().Single();
            try
            {
                ClienteAtual.cpf = client.cpf;
                ClienteAtual.Nome = client.Nome;
                ClienteAtual.RG = client.RG;
                ClienteAtual.telefone_fixo = client.telefone_fixo;
                ClienteAtual.Celular = client.Celular;
                ClienteAtual.Email = client.Email;
                SalvarClientes();
                Carregar();
            }
            catch (Exception)
            {

            }
        }
        public static void EditarContato(ClContato contato)
        {
            ClContato ContatoAtual = Crud.Lista_Contatos.Where(c => c.Id == contato.Id).ToList().Single();
            try
            {
                ContatoAtual.Id = contato.Id;
                ContatoAtual.Rua = contato.Rua;
                ContatoAtual.Bairro = contato.Bairro;
                ContatoAtual.Cidade = contato.Cidade;
                ContatoAtual.Numero = contato.Numero;
                ContatoAtual.Estado = contato.Estado;
                ContatoAtual.CEP = contato.CEP;
               
                Carregar();
            }
            catch (Exception)
            {

            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Game"></param>
        public static void EditarGame(CLGames Game)
        {

                CLGames JogoAtual = Crud.Lista_Games.Where(g => g.Id == Game.Id).ToList().Single();
                
                JogoAtual.Plataforma = Game.Plataforma;
                JogoAtual.Preco = Game.Preco;
                JogoAtual.Produtora = Game.Produtora;
                JogoAtual.Titulo = Game.Titulo;
                JogoAtual.Ano = Game.Ano;
                JogoAtual.Genero = Game.Genero;
               
                SalvarGames();
                CarregarGames();
            
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public static void EditarUsuario(CLUsuario user)
        {
            CLUsuario UsuarioAtual = Crud.Lista_Usuarios.Where(g => g.Id == user.Id).ToList().Single();
            UsuarioAtual.Nome = user.Nome;
            UsuarioAtual.perfil = user.perfil;
            UsuarioAtual.Senha = user.Senha;
            UsuarioAtual.status = user.status;
            UsuarioAtual.Email = user.Email;
            UsuarioAtual.Confirmacao = user.Confirmacao;
            SalvarUsuarios();
            CarregarUsuarios();
               
        }
        /// <summary>
        /// 
        /// </summary>
        public static void SalvarClientes()
        {
            
            Crud.SalvarClientes();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void SalvarUsuarios()
        {
            
            Crud.SalvarUsers();
        }
        /// <summary>
        /// 
        /// </summary>
        public static void SalvarGames()
        {
            
            Crud.SalvarGames();
        }
        /// <summary>
        /// Metodo verifica se a senha criada pelo usuario tem ao menos uma letra maiuscula,um caracter especial e minimo de 6 caracteres
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static bool ValidaSenha(string senha)
        {

            var CaracterEspecial = senha.Where(x => x == '@' || x == '#' || x == '$' || x == '%' || x == '&' || x == '*' || x == '!' || x == '+' || x == '-' || x == '=');

            if (CaracterEspecial != null && !(senha.ToLower() == senha) && (senha.Count() >= 6))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Metodo que Valida o cpf
        /// </summary>
        /// <param name="cpf"> cpf do cliente passado como parametro</param>
        /// <returns></returns>
        public static bool ValidaCpf(string cpf)
        {
            int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCPF, digito;
            int resto, soma;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }
            tempCPF = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCPF[i].ToString()) * mult1[i];
            }
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            tempCPF += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCPF[i].ToString()) * mult2[i];
            }
            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito += resto.ToString();

            return cpf.EndsWith(digito);

        }

        /// <summary>
        /// Metodo Valida o login 
        /// </summary>
        /// <param name="User"> Parametro 'cpf' Do cliente usado para identificar o usuario</param>
        /// <param name="Pass">Parametro senha , individual usada para validar o acesso</param>
        /// <param name="ListClient"></param>
        /// <returns></returns>
        public static bool ValidaLogin(String User, String Pass, List<CLUsuario> Users)
        {
            try
            {
                if (Users.Exists(x => x.Senha == Pass && x.Id == User))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex.InnerException);
            }

        }

        /// <summary>
        /// Metodo de envio de e-mail.Mesengem disparada assim que um cadastro é realizado
        /// </summary>
        /// <param name="textoEmHtml"> parametro booleano define se o corpo da mesangem sera html ou nao </param>
        /// <returns></returns>
        public static bool EnviarEmailSistema(string Remetente, bool textoEmHtml, string Assunto, string Msg)
        {
            try
            {
                // List<string> destinatarios;
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress(Remetente, string.Empty);
                mensagem.To.Add("rafael.rezende@meioambiente.mg.gov.br");

                //foreach (var email in destinatarios)
                //{
                //    mensagem.To.Add(email);
                //}

                mensagem.Subject = Assunto;
                mensagem.Body = Msg;
                mensagem.IsBodyHtml = textoEmHtml;
                mensagem.Priority = MailPriority.High;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "10.47.16.60";
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Send(mensagem);
                return true;

            }
            catch (SmtpException ex)
            {
                throw new Exception("Inconformidade ao enviar e-mail!", ex);

            }
        }

        /// <summary>
        /// Metodo envia um emal do tipo gmail caso haja possibilidade
        /// </summary>
        /// <param name="textoEmHtml"></param>
        /// <param name="remetente"></param>
        /// <param name="destinatario"></param>
        /// <returns></returns>
        public static bool SendGmail(bool textoEmHtml, string remetente, string destinatario)
        {
            try
            {
                // List<string> destinatarios;
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress(remetente, string.Empty);
                mensagem.To.Add(destinatario);

                //foreach (var email in destinatarios)
                //{
                //    mensagem.To.Add(email);
                //}

                mensagem.Subject = "Cadastro Realizado com sucesso";
                mensagem.Body = "E-mai informativo, nao responda";
                mensagem.IsBodyHtml = textoEmHtml;
                mensagem.Priority = MailPriority.High;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "10.47.16.60";
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Send(mensagem);
                return true;

            }
            catch (SmtpException ex)
            {
                throw new Exception("Inconformidade ao enviar e-mail!", ex);

            }
        }


        /// <summary>
        /// Atualiza as permissoes do usuarios de acordo com o tipo de perfil
        /// </summary>
        /// <param name="Usuario"></param>
        public static void AtualizaPermissoes(CLUsuario Usuario)
        {
            if (Usuario.perfil.Id == ConstantesApp.Gerente)
            {
                Usuario.perfil.Gravacao = true;
                Usuario.perfil.Leitura = true;

            }
            else if (Usuario.perfil.Id == ConstantesApp.Administrador)
            {
                Usuario.perfil.Gravacao = true;
                Usuario.perfil.Leitura = true;
            }
            else if (Usuario.perfil.Id == ConstantesApp.basico)
            {
                Usuario.perfil.Gravacao = false;
                Usuario.perfil.Leitura = true;
            }
        }
    }
}
