using GerenciadorJogos.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.DataAccess.Context;

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
