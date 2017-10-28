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

        public Jogo ConsultarPorId(int id)
        {
            var jogo = new Jogo();
            //using (_dbContext)
            //{
            //    jogo = _dbContext.Jogos.Include(x => x.Emprestimo).FirstOrDefault(x => x.JogoId == id);
            //}
            return jogo;
        }

        public void ExcluirPorId(int id)
        {
            using (_dbContext)
            {
                var jogo = ConsultarPorId(id);
                _dbContext.Jogos.Remove(jogo);
                _dbContext.SaveChanges();
            }
        }

        public List<Jogo> Listar()
        {
            var lista = new List<Jogo>();
            using (_dbContext)
            {
                lista = _dbContext.Jogos.ToList();
            }
            return lista;
        }

        public void Salvar(Jogo jogo)
        {
            using (_dbContext)
            {
                _dbContext.Jogos.AddOrUpdate(jogo);
                _dbContext.SaveChanges();
            }
        }
    }
}
