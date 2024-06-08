using MeuSiteEmMVC.Filter;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuariosRepository _usuarioRepository;
        public UsuarioController(IUsuariosRepository repository)
        {
            _usuarioRepository = repository;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioRepository.FindAll();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel NewUser)
        {
            try
            {
                if (NewUser != null)
                {
                    _usuarioRepository.Adicionar(NewUser);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(NewUser);
            }
            catch (System.Exception err)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o seu contato, detalhe do erro: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var usuario = _usuarioRepository.FindById(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                if (_usuarioRepository.Apagar(id))
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, occoreu um erro";
                }

            }catch(Exception err)
            {
                TempData["MensagemErro"] = $"Ops, occoreu um erro: {err.Message}";

            }

            return View();
            
        }

        [HttpPost]
        public IActionResult Atualizar(UsuarioSemSenhaModel usuario)
        {
            try
            {
                UsuarioModel usuarioPrincipal = null;
                if (ModelState.IsValid)
                {
                    usuarioPrincipal = new UsuarioModel()
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Login = usuario.Login,
                        Email = usuario.Email,
                        Perfil = usuario.Perfil
                    };

                    usuarioPrincipal = _usuarioRepository.Atualizar(usuarioPrincipal);
                    TempData["MensagemSucesso"] = "Usuario Atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar",usuario);

            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Houve um erro ao tentar atualizar usuários: {err.Message}";
                return RedirectToAction("Index");
            }
        
        }

        public IActionResult Editar(int id)
        {
            var usuario = _usuarioRepository.FindById(id);
            return View(usuario);
        }
    }
}
