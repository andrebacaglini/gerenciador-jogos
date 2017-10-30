using GerenciadorJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorJogos.Business.Interfaces
{
    public interface IEmprestimoBusiness
    {
        void ExcluirPorId(int idAmigo, int idJogo, string nomeUsuario);
        List<Emprestimo> Listar(string nomeUsuario);
        void Salvar(Emprestimo emprestimo);
        List<Amigo> ConsultarAmigos(string nomeUsuario);
        List<Jogo> ConsultarJogosDisponiveis(string nomeUsuario);
        Emprestimo ConsultarEmprestimoEspecifico(int idAmigo, int idJogo, string nomeUsuario);
        List<Emprestimo> ListarUltimosEmprestimos(int qtdade, string nomeUsuario);
    }
}
