using GerenciadorJogos.WebApp.Models;
using System.Net;
using System.Web.Mvc;

namespace GerenciadorJogos.WebApp.Controllers
{
    [Authorize]
    public class JogosController : Controller
    {
        //private GerenciadorJogosContext db = new GerenciadorJogosContext();

        // GET: Jogos
        public ActionResult Index()
        {
            //return View(db.Jogos.ToList());
            return View();
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Jogo jogo = db.Jogos.Find(id);
            JogoViewModel jogo = new JogoViewModel();
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JogoId,Nome,Plataforma")] JogoViewModel jogo)
        {
            if (ModelState.IsValid)
            {
                //db.Jogos.Add(jogo);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Jogo jogo = db.Jogos.Find(id);
            JogoViewModel jogo = new JogoViewModel();
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JogoId,Nome,Plataforma")] JogoViewModel jogo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(jogo).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Jogo jogo = db.Jogos.Find(id);
            JogoViewModel jogo = new JogoViewModel();
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Jogo jogo = db.Jogos.Find(id);
            //db.Jogos.Remove(jogo);
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
