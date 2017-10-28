using GerenciadorJogos.Util.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorJogos.WebApp.Models
{
    public class JogoViewModel
    {
        public int JogoId { get; set; }
        public string Nome { get; set; }
        public EnumPlataforma Plataforma { get; set; }
    }
}