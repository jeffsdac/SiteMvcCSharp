using MeuSiteEmMVC.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MeuSiteEmMVC.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
                return null;

            return JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);
        }

        public void CreateSession(UsuarioModel usuario)
        {
            string ToStringUser = JsonSerializer.Serialize(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", ToStringUser);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
