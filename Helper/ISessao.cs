using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Helper
{
    public interface ISessao 
    {
        void CreateSession(UsuarioModel usuario);
        void RemoveUserSession();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
