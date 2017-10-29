using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.DataAccess.Context;
using GerenciadorJogos.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;

namespace GerenciadorJogos.Business
{
    public class JogoBusiness : IJogoBusiness
    {
        public GerenciadorJogosContext _dbContext { get; set; }

        public List<Jogo> ConsultarJogosAindaNaoEmprestados()
        {
            var jogosDisponiveis = _dbContext.Jogos
                .Include(x => x.ListaEmprestimos)
                .Where(x => !x.ListaEmprestimos.Any())
                .ToList();
            return jogosDisponiveis;
        }

        public Jogo ConsultarPorId(int id)
        {
            var jogo = _dbContext.Jogos.Include(x => x.ListaEmprestimos.Select(y => y.Amigo))
                    .FirstOrDefault(x => x.JogoId == id);
            jogo.ListaEmprestimos.ForEach(x => { x.Amigo.ListaEmprestimos = null; x.Jogo = null; });
            return jogo;
        }

        public void ExcluirPorId(int id)
        {
            var jogo = ConsultarPorId(id);
            _dbContext.Jogos.Remove(jogo);
            _dbContext.SaveChanges();
        }

        public List<Jogo> Listar()
        {
            var lista = _dbContext.Jogos.ToList();
            return lista;
        }

        public void Salvar(Jogo jogo)
        {
            _dbContext.Jogos.AddOrUpdate(jogo);
            _dbContext.SaveChanges();
        }
    }
}
