using AutoMapper;
using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.WebApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace GerenciadorJogos.WebApp.Controllers
{
    [Authorize]
    public class AmigosController : Controller
    {
        #region Propriedades (Autowired)
        public IAmigoBusiness AmigoBusiness { get; set; }
        public IMapper Mapper { get; set; }
        #endregion

        #region Metodos GET
        // GET: Amigos
        public ActionResult Index()
        {
            var lista = AmigoBusiness.ListarAmigos();
            var listaAmigoVm = Mapper.Map<List<Amigo>, List<AmigoViewModel>>(lista);

            return View(listaAmigoVm);
        }

        // GET: Amigos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var amigo = AmigoBusiness.ConsultarPorId(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            var amigoVm = Mapper.Map<Amigo, AmigoViewModel>(amigo);
            return View(amigoVm);
        }

        // GET: Amigos/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Amigos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var amigo = AmigoBusiness.ConsultarPorId(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            var amigoVm = Mapper.Map<AmigoViewModel>(amigo);
            return View(amigoVm);
        }

        // GET: Amigos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var amigo = AmigoBusiness.ConsultarPorId(id);
            if (amigo == null)
            {
                return HttpNotFound();
            }

            var amigoVm = Mapper.Map<AmigoViewModel>(amigo);
            return View(amigoVm);
        }

        #endregion

        #region Metodos POST

        // POST: Amigos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmigoId,Nome,Sobrenome,Apelido")] AmigoViewModel amigoVm)
        {
            if (ModelState.IsValid)
            {
                var amigo = Mapper.Map<Amigo>(amigoVm);
                AmigoBusiness.Salvar(amigo);
                return RedirectToAction("Index");
            }

            return View(amigoVm);
        }

        // POST: Amigos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmigoId,Nome,Sobrenome,Apelido")] AmigoViewModel amigoVm)
        {
            if (ModelState.IsValid)
            {
                var amigo = Mapper.Map<Amigo>(amigoVm);
                AmigoBusiness.Salvar(amigo);
                return RedirectToAction("Index");
            }

            return View(amigoVm);
        }

        // POST: Amigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AmigoBusiness.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

        #endregion

        #region AJAX

        [HttpGet]
        public PartialViewResult ListarJogosAmigo(int id)
        {
            var amigo = AmigoBusiness.ConsultarPorId(id);
            var amigoVm = Mapper.Map<Amigo, AmigoViewModel>(amigo);
            return PartialView("~/Views/Amigos/Partial/_modalListaJogosAmigo.cshtml", amigoVm);
        }

        #endregion
    }
}
