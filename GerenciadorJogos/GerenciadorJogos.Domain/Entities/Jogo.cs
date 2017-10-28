using GerenciadorJogos.Util.Enums;

namespace GerenciadorJogos.Domain.Entities
{
    public class Jogo
    {
        public int JogoId { get; set; }
        public string Nome { get; set; }
        public EnumPlataforma Plataforma { get; set; }
    }
}
