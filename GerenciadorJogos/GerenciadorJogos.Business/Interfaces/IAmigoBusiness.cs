using GerenciadorJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorJogos.Business.Interfaces
{
    public interface IAmigoBusiness
    {
        List<Amigo> ListarAmigos();
        Amigo ConsultarPorId(int? id);
        void Salvar(Amigo amigo);
        void ExcluirPorId(int id);
    }
}
