using GerenciadorJogos.WebApp.Models;
using System.Net;
using System.Web.Mvc;

namespace GerenciadorJogos.WebApp.Controllers
{
    [Authorize]
    public class EmprestimosController : Controller
    {
        //private GerenciadorJogosContext db = new GerenciadorJogosContext();

        // GET: Emprestimoes
        public ActionResult Index()
        {
            //var emprestimos = db.Emprestimos.Include(e => e.Amigo).Include(e => e.Jogo);
            //return View(emprestimos.ToList());
            return View();
        }

        // GET: Emprestimoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Emprestimo emprestimo = db.Emprestimos.Find(id);
            EmprestimoViewModel emprestimo = new EmprestimoViewModel();
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimoes/Create
        public ActionResult Create()
        {
            //ViewBag.AmigoId = new SelectList(db.Amigos, "AmigoId", "Nome");
            //ViewBag.JogoId = new SelectList(db.Jogos, "JogoId", "Nome");
            return View();
        }

        // POST: Emprestimoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmprestimoId,AmigoId,JogoId,DataEmprestimo,DataDevolucao")] EmprestimoViewModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                //db.Emprestimos.Add(emprestimo);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AmigoId = new SelectList(db.Amigos, "AmigoId", "Nome", emprestimo.AmigoId);
            //ViewBag.JogoId = new SelectList(db.Jogos, "JogoId", "Nome", emprestimo.JogoId);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Emprestimo emprestimo = db.Emprestimos.Find(id);
            EmprestimoViewModel emprestimo = new EmprestimoViewModel();
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AmigoId = new SelectList(db.Amigos, "AmigoId", "Nome", emprestimo.AmigoId);
            //ViewBag.JogoId = new SelectList(db.Jogos, "JogoId", "Nome", emprestimo.JogoId);
            return View(emprestimo);
        }

        // POST: Emprestimoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmprestimoId,AmigoId,JogoId,DataEmprestimo,DataDevolucao")] EmprestimoViewModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(emprestimo).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AmigoId = new SelectList(db.Amigos, "AmigoId", "Nome", emprestimo.AmigoId);
            //ViewBag.JogoId = new SelectList(db.Jogos, "JogoId", "Nome", emprestimo.JogoId);
            return View(emprestimo);
        }

        // GET: Emprestimoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Emprestimo emprestimo = db.Emprestimos.Find(id);
            EmprestimoViewModel emprestimo = new EmprestimoViewModel();
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Emprestimo emprestimo = db.Emprestimos.Find(id);
            //db.Emprestimos.Remove(emprestimo);
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
