﻿using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MeuSiteEmMVC.Filter
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string SessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (String.IsNullOrEmpty(SessaoUsuario))
            {
                context.Result = new Microsoft.AspNetCore.Mvc.RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UsuarioModel user = JsonSerializer.Deserialize<UsuarioModel>(SessaoUsuario);

                if (user == null)
                {
                    context.Result = new Microsoft.AspNetCore.Mvc.RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            
            }

            base.OnActionExecuting(context);

        }
    }
}
