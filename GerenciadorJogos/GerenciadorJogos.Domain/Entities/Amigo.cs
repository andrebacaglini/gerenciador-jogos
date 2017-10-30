using System.Collections.Generic;

namespace GerenciadorJogos.Domain.Entities
{
    public class Amigo
    {
        public Amigo()
        {
            ListaEmprestimos = new List<Emprestimo>();
        }

        public int AmigoId { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set;}
        public string Apelido { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public virtual List<Emprestimo> ListaEmprestimos { get; set; }

    }
}
