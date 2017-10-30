using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.DataAccess.Context;
using GerenciadorJogos.Domain.Entities;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GerenciadorJogos.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        public GerenciadorJogosContext _dbContext { get; set; }

        public Usuario ConsultaUsuario(string nomeUsuario)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => string.Equals(x.NomeUsuario, nomeUsuario));
        }

        public bool NomeUsuarioExistente(string nomeUsuario)
        {
            return _dbContext.Usuarios.Any(x => string.Equals(x.NomeUsuario, nomeUsuario));
        }

        public void Salvar(Usuario usuario)
        {
            _dbContext.Usuarios.AddOrUpdate(usuario);
            _dbContext.SaveChanges();
        }

        public bool ValidarUsuario(Usuario usuario)
        {
            return _dbContext.Usuarios.Any(x => x.NomeUsuario == usuario.NomeUsuario && x.Senha == usuario.Senha);
        }
    }
}
