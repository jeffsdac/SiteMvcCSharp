using MeuSiteEmMVC.Filter;
using MeuSiteEmMVC.Helper;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MeuSiteEmMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepository contatoRepository, ISessao sessao)
        {
            _contatoRepository = contatoRepository;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            var user = _sessao.BuscarSessaoDoUsuario();
            var contatos = _contatoRepository.findAll(user.Id);
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {

            var contato = _contatoRepository.findById(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var contato = _contatoRepository.findById(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(Contato contatoInput)
        {
            try
            {
                if (contatoInput != null)
                {
                    var user = _sessao.BuscarSessaoDoUsuario();
                    contatoInput.UsuarioId = user.Id;
                    _contatoRepository.Adicionar(contatoInput);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contatoInput);
            }
            catch (System.Exception err)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o seu contato, detalhe do erro: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(Contato ContatoInput)
        {
            try
            {
                if (ContatoInput != null)
                {
                    var user = _sessao.BuscarSessaoDoUsuario();
                    ContatoInput.UsuarioId = user.Id;
                    _contatoRepository.Atualizar(ContatoInput);
                    TempData["MensagemSucesso"] = "Seu usuário editado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", ContatoInput);
            }
            catch (System.Exception err)
            {
                TempData["MensagemErro"] = $"Não foi possível editar seu usário, erro: {err.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Apagar(int id)
        {
            try
            {

                bool IsDeleted = _contatoRepository.Apagar(id);
                if (IsDeleted)
                {
                    TempData["MensagemSucesso"] = "Usuário deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Usuário não foi deletado";
                }
                return RedirectToAction("Index");
            } catch (System.Exception err)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos deletar o seu usuário: {err.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
