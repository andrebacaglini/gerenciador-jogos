using GerenciadorJogos.WebApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace GerenciadorJogos.MvcWebApp.Controllers
{
    [Authorize]
    public class AmigosController : Controller
    {
        //private GerenciadorJogosContext db = new GerenciadorJogosContext();

        // GET: Amigos
        public ActionResult Index()
        {
            //return View(db.Amigos.ToList());
            var lista = new List<AmigoViewModel>();
            return View(lista);
        }

        // GET: Amigos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AmigoViewModel amigo = db.Amigos.Find(id);
            AmigoViewModel amigo = new AmigoViewModel();
            if (amigo == null)
            {
                return HttpNotFound();
            }
            return View(amigo);
        }

        // GET: Amigos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amigos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmigoId,Nome,Sobrenome,Apelido")] AmigoViewModel amigo)
        {
            if (ModelState.IsValid)
            {
                //db.Amigos.Add(amigo);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amigo);
        }

        // GET: Amigos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Amigo amigo = db.Amigos.Find(id);
            AmigoViewModel amigo = new AmigoViewModel();
            if (amigo == null)
            {
                return HttpNotFound();
            }
            return View(amigo);
        }

        // POST: Amigos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmigoId,Nome,Sobrenome,Apelido")] AmigoViewModel amigo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(amigo).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amigo);
        }

        // GET: Amigos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Amigo amigo = db.Amigos.Find(id);
            AmigoViewModel amigo = new AmigoViewModel();
            if (amigo == null)
            {
                return HttpNotFound();
            }
            return View(amigo);
        }

        // POST: Amigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Amigo amigo = db.Amigos.Find(id);
            //db.Amigos.Remove(amigo);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
