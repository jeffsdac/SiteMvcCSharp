using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repository
{
    public interface IUsuariosRepository
    {
        UsuarioModel FindByLogin(string login);

        UsuarioModel FindById(int id);

        UsuarioModel Adicionar(UsuarioModel NewUser);

        UsuarioModel Atualizar(UsuarioModel UpdatedUser);

        List<UsuarioModel> FindAll();

        bool Apagar(int id);

    }
}
