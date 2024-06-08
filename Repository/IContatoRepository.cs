using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Repository
{
    public interface IContatoRepository 
    {
        Contato findById(int id);
        Contato Adicionar(Contato contato);
        List<Contato> findAll(int id);

        Contato Atualizar(Contato contato);

        bool Apagar(int id);
    }
}
