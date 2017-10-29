using GerenciadorJogos.Business.Interfaces;
using GerenciadorJogos.DataAccess.Context;
using GerenciadorJogos.Domain.Entities;
using System.Linq;

namespace GerenciadorJogos.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        public GerenciadorJogosContext _dbContext { get; set; }

        public bool ValidarUsuario(Usuario usuario)
        {
            return _dbContext.Usuarios.Any(x => x.NomeUsuario == usuario.NomeUsuario && x.Senha == usuario.Senha);
        }
    }
}
