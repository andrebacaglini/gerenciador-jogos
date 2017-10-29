﻿using GerenciadorJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorJogos.Business.Interfaces
{
    public interface IEmprestimoBusiness
    {
        void ExcluirPorId(int idAmigo, int idJogo);
        List<Emprestimo> Listar();
        void Salvar(Emprestimo emprestimo);
        List<Amigo> ConsultarAmigos();
        List<Jogo> ConsultarJogosDisponiveis();
        Emprestimo ConsultarEmprestimoEspecifico(int idAmigo, int idJogo);
    }
}
