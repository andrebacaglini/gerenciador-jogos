using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorJogos.WebApp.Models
{
    public class EmprestimoViewModel
    {
        public int EmprestimoId { get; set; }

        public AmigoViewModel Amigo { get; set; }
        public JogoViewModel Jogo { get; set; }

        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}