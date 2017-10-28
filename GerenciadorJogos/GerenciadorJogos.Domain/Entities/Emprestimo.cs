using System;

namespace GerenciadorJogos.Domain.Entities
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }

        public int AmigoId { get; set; }
        public Amigo Amigo { get; set; }

        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }

        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
