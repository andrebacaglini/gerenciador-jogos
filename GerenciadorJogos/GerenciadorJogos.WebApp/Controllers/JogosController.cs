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
    public class JogosController : Controller
    {
        #region Propriedades (Autowired)

        public IMapper Mapper { get; set; }
        public IJogoBusiness JogoBusiness { get; set; }

        #endregion

        #region Metodos GET

        // GET: Jogos
        public ActionResult Index()
        {
            var listaJogos = JogoBusiness.Listar();
            var listaJogosVm = Mapper.Map<List<JogoViewModel>>(listaJogos);
            return View(listaJogosVm);
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jogo = JogoBusiness.ConsultarPorId(id.Value);

            if (jogo == null)
            {
                return HttpNotFound();
            }
            var jogoVm = Mapper.Map<JogoViewModel>(jogo);
            return View(jogoVm);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jogo = JogoBusiness.ConsultarPorId(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            var jogoVm = Mapper.Map<JogoViewModel>(jogo);
            return View(jogoVm);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jogo = JogoBusiness.ConsultarPorId(id.Value);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            var jogoVm = Mapper.Map<JogoViewModel>(jogo);
            return View(jogoVm);
        }

        #endregion

        #region Metodos POST

        // POST: Jogos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JogoId,Nome,Plataforma")] JogoViewModel jogoVm)
        {
            if (ModelState.IsValid)
            {
                var jogo = Mapper.Map<Jogo>(jogoVm);
                JogoBusiness.Salvar(jogo);
                
                return RedirectToAction("Index");
            }
            return View(jogoVm);
        }

        // POST: Jogos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JogoId,Nome,Plataforma")] JogoViewModel jogoVm)
        {
            if (ModelState.IsValid)
            {
                var jogo = Mapper.Map<Jogo>(jogoVm);
                JogoBusiness.Salvar(jogo);
                return RedirectToAction("Index");
            }
            return View(jogoVm);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            JogoBusiness.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
