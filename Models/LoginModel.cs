using MeuSiteEmMVC.Helper;
using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o Login do usuário")]
        public string Login
        {
            get; set;
        }

        [Required(ErrorMessage = "Informe a Senha do usuário")]
        public string Password
        {
            get;set;
        }

        public bool IsLoginValid(UsuarioModel user)
        {
            if (user == null) return false;

            return user.Senha == Password.GerarHash();

        }
        
    }
}
