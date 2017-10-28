using GerenciadorJogos.Util.Constantes;
using GerenciadorJogos.Util.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciadorJogos.WebApp.Models
{
    public class JogoViewModel
    {
        public int JogoId { get; set; }

        [Display(Name ="Nome do jogo")]
        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        [MaxLength(50, ErrorMessage = MensagensInterface.TAMANHO_INVALIDO)]
        public string Nome { get; set; }

        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        public EnumPlataforma Plataforma { get; set; }
    }
}