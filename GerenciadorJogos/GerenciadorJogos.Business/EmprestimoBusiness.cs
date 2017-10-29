using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.DataAccess.Context;
using GerenciadorJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace GerenciadorJogos.Business
{
    public class EmprestimoBusiness : IEmprestimoBusiness
    {
        public GerenciadorJogosContext _dbContext { get; set; }
        public IAmigoBusiness _amigoBusiness { get; set; }
        public IJogoBusiness _jogoBusiness { get; set; }

        public List<Amigo> ConsultarAmigos()
        {
            return _amigoBusiness.ListarAmigos();
        }

        public List<Jogo> ConsultarJogosDisponiveis()
        {
            return _jogoBusiness.ConsultarJogosAindaNaoEmprestados();
        }

        public Emprestimo ConsultarPorId(int id)
        {
            var emprestimo = _dbContext.Emprestimos
                .Include(x => x.Amigo)
                .Include(x => x.Jogo)
                .FirstOrDefault();

            emprestimo.Amigo.ListaEmprestimos.ForEach(x => { x.Amigo = null; x.Jogo.ListaEmprestimos = null; });
            emprestimo.Jogo.ListaEmprestimos.ForEach(x => { x.Jogo = null; x.Amigo.ListaEmprestimos = null; });
            return emprestimo;
        }

        public void ExcluirPorId(int id)
        {
            var emprestimo = ConsultarPorId(id);
            _dbContext.Emprestimos.Remove(emprestimo);
            _dbContext.SaveChanges();
        }

        public List<Emprestimo> Listar()
        {
            var lista = _dbContext.Emprestimos
                .Include(x => x.Amigo)
                .Include(x => x.Jogo)
                .ToList();
            lista.ForEach(x => { x.Amigo.ListaEmprestimos = null; x.Jogo.ListaEmprestimos = null; });            
            return lista;
        }

        public void Salvar(Emprestimo emprestimo)
        {
            _dbContext.Emprestimos.AddOrUpdate(emprestimo);
            _dbContext.SaveChanges();
        }
    }
}
