using AutoMapper;
using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.WebApp.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GerenciadorJogos.WebApp.Controllers
{
    public class ContaController : Controller
    {
        public IUsuarioBusiness UsuarioBusiness { get; set; }
        public IMapper Mapper { get; set; }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "NomeUsuario,Senha")] UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                if (UsuarioEstaValido(usuario))
                {
                    FormsAuthentication.RedirectFromLoginPage(usuario.NomeUsuario, true);                    
                }
                else
                {
                    ModelState.AddModelError("", "Credenciais inválidas.");
                }
            }
            return View(usuario);
        }

        private bool UsuarioEstaValido(UsuarioViewModel usuario)
        {
            var objUsuario = Mapper.Map<Usuario>(usuario);
            return UsuarioBusiness.ValidarUsuario(objUsuario);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private void CriaCookieAutenticacao(string nomeUsuario)
        {
            var authTicket = new FormsAuthenticationTicket(1, nomeUsuario, DateTime.Now,
                                      DateTime.Now.AddMinutes(30), true, "");

            string cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };

            if (HttpContext != null)
            {
                HttpContext.Response.Cookies.Add(cookie);
            }
        }

    }
}
