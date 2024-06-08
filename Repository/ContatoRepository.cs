using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repository
{
    public class ContatoRepository : IContatoRepository
    {

        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bcontext)
        {
            _bancoContext = bcontext;
        }


        public Contato Adicionar(Contato contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public bool Apagar(int id)
        {
            var contatoDb = findById(id);

            if (contatoDb == null)
                throw new Exception("Houve um erro na deleção do contato!");

            _bancoContext.Remove(contatoDb);
            _bancoContext.SaveChanges();

            return true;



        }

        public Contato Atualizar(Contato contato)
        {
            var contatoDb = findById(contato.Id);

            if (contatoDb == null)
                throw new Exception("Houve um erro na atualização do contato!");

            contatoDb.nome = contato.nome;
            contatoDb.email = contato.email;
            contatoDb.celular = contato.celular;
            

            _bancoContext.Contatos.Update(contatoDb);
            _bancoContext.SaveChanges();

            return contatoDb;
        }

        public List<Contato> findAll(int id)
        {

            return _bancoContext.Contatos.Where(ContatoBanco => ContatoBanco.UsuarioId == id).ToList();
        }

        public Contato findById(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(contato => contato.Id == id);
        }
    }
}
