using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MeuSiteEmMVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (sessaoUsuario == null || sessaoUsuario == "")
                return null;

            UsuarioModel user = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
            return View(user);
        }
    }
}
