using GerenciadorJogos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorJogos.Business.Interfaces
{
    public interface IJogoBusiness
    {
        List<Jogo> Listar(string nomeUsuario);
        Jogo ConsultarPorId(int id);
        void Salvar(Jogo jogo);
        void ExcluirPorId(int id);
        List<Jogo> ConsultarJogosAindaNaoEmprestados(string nomeUsuario);
    }
}
