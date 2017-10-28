using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.DataAccess.Context;
using GerenciadorJogos.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;

namespace GerenciadorJogos.Business
{
    public class AmigoBusiness : IAmigoBusiness
    {
        public GerenciadorJogosContext _dbContext { get; set; }

        public Amigo ConsultarPorId(int? id)
        {
            var query = _dbContext.Amigos
                .Include(x => x.ListaEmprestimos.Select(y => y.Jogo));

            return query.FirstOrDefault(x => x.AmigoId == id.Value);
        }

        public void ExcluirPorId(int id)
        {
            var amigo = ConsultarPorId(id);
            _dbContext.Amigos.Remove(amigo);
            _dbContext.SaveChanges();
        }

        public List<Amigo> ListarAmigos()
        {
            return _dbContext.Amigos.ToList(); 
        }

        public void Salvar(Amigo amigo)
        {
            _dbContext.Amigos.AddOrUpdate(amigo);
            _dbContext.SaveChanges();
        }

    }
}
