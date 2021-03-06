﻿using GerenciadorJogos.Util.Constantes;
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

        public int JogoIdAntigo { get; set; }

        public AmigoViewModel Amigo { get; set; }
        public JogoViewModel Jogo { get; set; }

        [Display(Name = "Data do empréstimo")]
        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = MensagensInterface.DATA_INVALIDA)]
        public DateTime DataEmprestimo { get; set; }

        [Display(Name = "Data da devolução")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = MensagensInterface.DATA_INVALIDA)]
        public DateTime? DataDevolucao { get; set; }
    }
}