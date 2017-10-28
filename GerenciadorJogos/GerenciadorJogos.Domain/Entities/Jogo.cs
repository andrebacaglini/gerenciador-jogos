using GerenciadorJogos.Util.Enums;
using System.Collections.Generic;

namespace GerenciadorJogos.Domain.Entities
{
    public class Jogo
    {
        public int JogoId { get; set; }
        public string Nome { get; set; }
        public EnumPlataforma Plataforma { get; set; }
    }
}
