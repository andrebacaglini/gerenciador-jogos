using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorJogos.WebApp.Models
{
    public class AmigoViewModel
    {
        public int AmigoId { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
    }
}