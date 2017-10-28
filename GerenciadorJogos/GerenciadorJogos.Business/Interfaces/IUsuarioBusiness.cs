using GerenciadorJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorJogos.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        bool ValidarUsuario(Usuario usuario);
    }
}
