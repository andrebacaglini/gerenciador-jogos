using System;
using System.Collections.Generic;

namespace GerenciadorJogos.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            ListaJogos = new List<Jogo>();
            ListaAmigos = new List<Amigo>();
            ListaEmprestimos = new List<Emprestimo>();
        }
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual bool EstaValido{ get; set; }

        public virtual List<Jogo> ListaJogos { get; set; }
        public virtual List<Amigo> ListaAmigos { get; set; }
        public virtual List<Emprestimo> ListaEmprestimos { get; set; }

    }
}
