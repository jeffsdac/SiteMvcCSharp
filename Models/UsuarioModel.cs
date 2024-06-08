using MeuSiteEmMVC.Enum;
using MeuSiteEmMVC.Helper;

namespace MeuSiteEmMVC.Models
{
    public class UsuarioModel
    {
        public int Id
        {
            get; set;
        }
        public string Nome
        {
            get; set;
        }
    

        public string Login
        {
            get;set;
        }
      

        public string Email
        {
            get;set;
        }
        

        public PerfilEnum Perfil
        {
            get; set;
        }
        public virtual List<Contato> Contatos
        {
            get; set;
        }


        public string Senha
        {
            get;set;
        }
        

        public DateTime DataDeCadastro
        {
            get;set;
        }

        public DateTime? DataDeAtualizacao
        {
            get;set;
        }

        public void setSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
    }
}
