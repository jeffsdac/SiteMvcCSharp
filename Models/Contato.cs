using System.ComponentModel.DataAnnotations;

namespace MeuSiteEmMVC.Models
{
    public class Contato
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe um nome de contato")]
        public string nome { get; set;}
        [Required(ErrorMessage= "Informe o E-mail do usuário")]
        public string email { get;set;}
        [Required(ErrorMessage= "Informe o celular do usuário")]
        public string celular
        {
            get;set;
        }
        public int? UsuarioId
        {
            get; set;
        }

        public UsuarioModel Usuario {
            get; set;
        }
    }
}
