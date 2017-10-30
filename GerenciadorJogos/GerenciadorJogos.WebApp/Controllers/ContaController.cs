using AutoMapper;
using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.WebApp.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GerenciadorJogos.WebApp.Controllers
{
    [ValidateInput(false)]
    public class ContaController : Controller
    {
        public IUsuarioBusiness UsuarioBusiness { get; set; }
        public IMapper Mapper { get; set; }

        // GET: Conta/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "NomeUsuario,Senha")] UsuarioViewModel usuario)
        {            
            if (!ModelState["NomeUsuario"].Errors.Any() && !ModelState["Senha"].Errors.Any())
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

        // POST: Conta/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NomeUsuario,Senha,Email")] UsuarioViewModel usuarioVm)
        {
            if (ModelState.IsValid)
            {
                if (!NomeUsuarioExistente(usuarioVm.NomeUsuario))
                {
                    var usuario = Mapper.Map<Usuario>(usuarioVm);
                    usuario.DataCadastro = DateTime.Now;
                    UsuarioBusiness.Salvar(usuario);
                    FormsAuthentication.RedirectFromLoginPage(usuario.NomeUsuario, true);
                }
                else
                {
                    ModelState.AddModelError("", "Nome de usuário já existe.");
                }                
            }

            return View(usuarioVm);
        }

        private bool NomeUsuarioExistente(string nomeUsuario)
        {
            return UsuarioBusiness.NomeUsuarioExistente(nomeUsuario);
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
