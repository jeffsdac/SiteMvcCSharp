using MeuSiteEmMVC.Helper;
using MeuSiteEmMVC.Models;
using MeuSiteEmMVC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuariosRepository _usuarioRepository;
        private readonly ISessao _session;

        public LoginController(IUsuariosRepository userRepo, ISessao sessao)
        {
            _usuarioRepository = userRepo;
            _session = sessao;
        }

        public IActionResult Index()
        {
            if (_session.BuscarSessaoDoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Sair()
        {
            _session.RemoveUserSession();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel LoginEntrar)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    var LoginDb = _usuarioRepository.FindByLogin(LoginEntrar.Login);
                    if (LoginEntrar.IsLoginValid(LoginDb))
                    {
                        _session.CreateSession(LoginDb);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Parece que o usuário e/ou senha informado são inválidos!";
                        return RedirectToAction("Index");

                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Parece que não conseguimos realizar o seu login: {err.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
