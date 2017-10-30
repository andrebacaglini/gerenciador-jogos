using GerenciadorJogos.Util.Enums;
using System.Collections.Generic;

namespace GerenciadorJogos.Domain.Entities
{
    public class Jogo
    {
        public Jogo()
        {
            ListaEmprestimos = new List<Emprestimo>();
        }
        public int JogoId { get; set; }
        public string Nome { get; set; }
        public EnumPlataforma Plataforma { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public virtual List<Emprestimo> ListaEmprestimos { get; set; }
    }
}
