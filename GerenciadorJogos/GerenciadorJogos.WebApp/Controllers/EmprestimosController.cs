using AutoMapper;
using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GerenciadorJogos.WebApp.Controllers
{
    [Authorize]
    public class EmprestimosController : Controller
    {
        #region Propriedades (Autowired)

        public IMapper Mapper { get; set; }
        public IEmprestimoBusiness EmprestimoBusiness { get; set; }
        public IJogoBusiness JogoBusiness { get; set; }

        #endregion

        #region Metodos GET

        // GET: Emprestimoes
        public ActionResult Index()
        {
            var emprestimos = EmprestimoBusiness.Listar();
            var emprestimosVm = Mapper.Map<List<EmprestimoViewModel>>(emprestimos);
            return View(emprestimosVm);
        }

        // GET: Emprestimoes/Details/5
        public ActionResult Details(int? idAmigo, int? idJogo)
        {
            if (idAmigo == null || idJogo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var emprestimo = EmprestimoBusiness.ConsultarEmprestimoEspecifico(idAmigo.Value, idJogo.Value);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }

            var emprestimoVm = Mapper.Map<EmprestimoViewModel>(emprestimo);
            return View(emprestimoVm);
        }

        // GET: Emprestimoes/Create
        public ActionResult Create()
        {
            CriaViewBagDropdownAmigos();
            CriaViewBagDropdownJogosDisponiveis();
            return View();
        }

        // GET: Emprestimoes/Edit/5
        public ActionResult Edit(int? idAmigo, int? idJogo)
        {
            if (idAmigo == null || idJogo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emprestimo = EmprestimoBusiness.ConsultarEmprestimoEspecifico(idAmigo.Value, idJogo.Value);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }

            var emprestimoVm = Mapper.Map<EmprestimoViewModel>(emprestimo);
            emprestimoVm.JogoIdAntigo = emprestimo.JogoId;

            CriaViewBagDropdownAmigos(emprestimoVm.AmigoId);
            CriaViewBagDropdownJogosDisponiveisEdicao(emprestimo.Jogo);

            return View(emprestimoVm);
        }

        // GET: Emprestimoes/Delete/5
        public ActionResult Delete(int? idAmigo, int? idJogo)
        {
            if (idAmigo == null || idJogo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var emprestimo = EmprestimoBusiness.ConsultarEmprestimoEspecifico(idAmigo.Value, idJogo.Value);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            var emprestimoVm = Mapper.Map<EmprestimoViewModel>(emprestimo);
            return View(emprestimoVm);
        }

        #endregion

        #region Metodos POST

        // POST: Emprestimoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmigoId,JogoId,DataEmprestimo,DataDevolucao")] EmprestimoViewModel emprestimoVm)
        {
            if (ModelState.IsValid && DataDevolucaoValidas(emprestimoVm))
            {
                var emprestimo = Mapper.Map<Emprestimo>(emprestimoVm);
                EmprestimoBusiness.Salvar(emprestimo);
                return RedirectToAction("Index");
            }

            CriaViewBagDropdownAmigos();
            CriaViewBagDropdownJogosDisponiveis();
            return View(emprestimoVm);
        }

        // POST: Emprestimoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmprestimoViewModel emprestimoVm)
        {
            if (ModelState.IsValid && DataDevolucaoValidas(emprestimoVm))
            {
                EmprestimoBusiness.ExcluirPorId(emprestimoVm.AmigoId, emprestimoVm.JogoIdAntigo);
                EmprestimoBusiness.Salvar(Mapper.Map<Emprestimo>(emprestimoVm));
                return RedirectToAction("Index");
            }

            CriaViewBagDropdownAmigos(emprestimoVm.AmigoId);
            var jogo = JogoBusiness.ConsultarPorId(emprestimoVm.JogoIdAntigo);
            CriaViewBagDropdownJogosDisponiveisEdicao(jogo);
            return View(emprestimoVm);
        }       

        // POST: Emprestimoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idAmigo, int idJogo)
        {
            EmprestimoBusiness.ExcluirPorId(idAmigo, idJogo);
            return RedirectToAction("Index");
        }

        #endregion

        #region Metodos Privados

        private void CriaViewBagDropdownAmigos(params int[] idAmigoSelecionado)
        {
            var amigos = EmprestimoBusiness.ConsultarAmigos();
            var amigosVm = Mapper.Map<List<AmigoViewModel>>(amigos);
            if (idAmigoSelecionado.Any())
            {
                ViewBag.DropDownAmigos = new SelectList(amigosVm, "AmigoId", "Nome", idAmigoSelecionado[0]);
            }
            else
            {
                ViewBag.DropDownAmigos = new SelectList(amigosVm, "AmigoId", "Nome");
            }
        }

        private void CriaViewBagDropdownJogosDisponiveis()
        {
            var jogosDisponiveis = EmprestimoBusiness.ConsultarJogosDisponiveis();
            var jogosDisponiveisVm = Mapper.Map<List<JogoViewModel>>(jogosDisponiveis);
            ViewBag.DropDownJogos = new SelectList(jogosDisponiveisVm, "JogoId", "Nome");
        }

        private void CriaViewBagDropdownJogosDisponiveisEdicao(Jogo jogoAnterior)
        {
            var jogosDisponiveis = EmprestimoBusiness.ConsultarJogosDisponiveis();
            jogosDisponiveis.Add(jogoAnterior);
            var jogosDisponiveisVm = Mapper.Map<List<JogoViewModel>>(jogosDisponiveis);
            ViewBag.DropDownJogos = new SelectList(jogosDisponiveisVm, "JogoId", "Nome", jogoAnterior.JogoId);
        }

        private bool DataDevolucaoValidas(EmprestimoViewModel emprestimoVm)
        {
            if (emprestimoVm.DataDevolucao.HasValue && emprestimoVm.DataDevolucao < emprestimoVm.DataEmprestimo)
            {
                ModelState.AddModelError("", "Data de devolução não pode ser menor que a data de empréstimo.");
                return false;
            }
            return true;
        }

        #endregion
    }
}
