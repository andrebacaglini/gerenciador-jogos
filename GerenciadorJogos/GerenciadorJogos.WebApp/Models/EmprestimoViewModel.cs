using GerenciadorJogos.Util.Constantes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciadorJogos.WebApp.Models
{
    public class EmprestimoViewModel
    {
        public int EmprestimoId { get; set; }

        [Display(Name = "Amigo")]
        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        public int AmigoId { get; set; }

        [Display(Name = "Jogo")]
        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        public int JogoId { get; set; }

        public AmigoViewModel Amigo { get; set; }
        public JogoViewModel Jogo { get; set; }

        [Display(Name = "Data do empréstimo")]
        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        public DateTime DataEmprestimo { get; set; }

        [Display(Name = "Data da devolução")]
        public DateTime? DataDevolucao { get; set; }
    }
}