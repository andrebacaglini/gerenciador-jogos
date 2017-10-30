using AutoMapper;
using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorJogos.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IEmprestimoBusiness EmprestimoBusiness { get; set; }
        public IMapper Mapper { get; set; }

        public ActionResult Index()
        {
            var ultimosEmprestimos = EmprestimoBusiness.ListarUltimosEmprestimos(10, User.Identity.Name);
            var ultimoEmprestimosVm = Mapper.Map<List<EmprestimoViewModel>>(ultimosEmprestimos);
            return View(ultimoEmprestimosVm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}