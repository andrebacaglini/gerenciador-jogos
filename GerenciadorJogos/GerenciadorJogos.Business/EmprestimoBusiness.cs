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

        public List<Amigo> ConsultarAmigos(string nomeUsuario)
        {
            return _amigoBusiness.ListarAmigos(nomeUsuario);
        }

        public Emprestimo ConsultarEmprestimoEspecifico(int idAmigo, int idJogo, string nomeUsuario)
        {
            var emprestimo = _dbContext.Emprestimos
                .Include(x => x.Jogo)
                .Include(x => x.Amigo)
                .Include(x => x.Usuario)
                .FirstOrDefault(x => x.AmigoId == idAmigo && x.JogoId == idJogo && string.Equals(x.Usuario.NomeUsuario, nomeUsuario));
            emprestimo.Amigo.ListaEmprestimos = null;
            emprestimo.Jogo.ListaEmprestimos = null;      
            emprestimo.Usuario.ListaEmprestimos = null;
            return emprestimo;
        }

        public List<Jogo> ConsultarJogosDisponiveis(string nomeUsuario)
        {
            return _jogoBusiness.ConsultarJogosAindaNaoEmprestados(nomeUsuario);
        }

        public void ExcluirPorId(int idAmigo, int idJogo, string nomeUsuario)
        {
            var emprestimo = ConsultarEmprestimoEspecifico(idAmigo, idJogo, nomeUsuario);
            _dbContext.Emprestimos.Remove(emprestimo);
            _dbContext.SaveChanges();
        }

        public List<Emprestimo> Listar(string nomeUsuario)
        {
            var lista = _dbContext.Emprestimos
                .Include(x => x.Amigo)
                .Include(x => x.Jogo)
                .Include(x => x.Usuario)
                .Where(x => string.Equals(x.Usuario.NomeUsuario, nomeUsuario))
                .ToList();
            lista.ForEach(x =>
            {
                x.Amigo.ListaEmprestimos = null;
                x.Jogo.ListaEmprestimos = null;
                x.Usuario.ListaJogos = null;
                x.Usuario.ListaAmigos = null;
                x.Usuario.ListaEmprestimos = null;
            });
            return lista;
        }

        public List<Emprestimo> ListarUltimosEmprestimos(int qtdade, string nomeUsuario)
        {
            var lista = _dbContext.Emprestimos
                .Include(x => x.Amigo)
                .Include(x => x.Jogo)
                .Include(x => x.Usuario)
                .OrderByDescending(x => x.DataEmprestimo)
                .Take(qtdade)
                .Where(x => string.Equals(x.Usuario.NomeUsuario, nomeUsuario))
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
