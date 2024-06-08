using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly BancoContext _bancoContext;

        public UsuariosRepository(BancoContext banco)
        {
            _bancoContext = banco;
        }

        public UsuarioModel Adicionar(UsuarioModel NewUser)
        {
            NewUser.DataDeCadastro = DateTime.Now.ToUniversalTime();
            NewUser.setSenhaHash();
            _bancoContext.Usuarios.Add(NewUser);
            _bancoContext.SaveChanges();

            return NewUser; 
        }

        public bool Apagar(int id)
        {
            var UsuarioDb = FindById(id);

            if (UsuarioDb == null)
            {
                throw new Exception("Não foi encontrado nenhum usuário com esse ID");
            }

            _bancoContext.Usuarios.Remove(UsuarioDb);
            _bancoContext.SaveChanges();

            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel UpdatedUser)
        {
            var UsuarioDb = FindById(UpdatedUser.Id);

            if (UsuarioDb == null)
            {
                throw new Exception("Não foi encontrado nenhum usuário com esse ID");
            }

            UsuarioDb.Perfil = UpdatedUser.Perfil;
            UsuarioDb.Login = UpdatedUser.Login;
            UsuarioDb.Email = UpdatedUser.Email;
            UsuarioDb.Nome = UpdatedUser.Nome;
            UsuarioDb.DataDeAtualizacao = DateTime.Now.ToUniversalTime();



            _bancoContext.Usuarios.Update(UsuarioDb);
            _bancoContext.SaveChanges();
            return UsuarioDb;
        }

        public List<UsuarioModel> FindAll()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel FindById(int Id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(UsuarioDb => UsuarioDb.Id == Id);
        }

        public UsuarioModel FindByLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(UsuarioInput => UsuarioInput.Login.ToUpper() == login.ToUpper());
        }
    }
}
