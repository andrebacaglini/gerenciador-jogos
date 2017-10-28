using GerenciadorJogos.Util.Constantes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogos.WebApp.Models
{
    public class AmigoViewModel
    {
        public int AmigoId { get; set; }

        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        [MaxLength(100, ErrorMessage = MensagensInterface.TAMANHO_INVALIDO)]
        public string Nome { get; set; }

        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        [MaxLength(100, ErrorMessage = MensagensInterface.TAMANHO_INVALIDO)]
        public string Sobrenome { get; set; }

        [MaxLength(50, ErrorMessage = MensagensInterface.TAMANHO_INVALIDO)]
        public string Apelido { get; set; }

        public ICollection<EmprestimoViewModel> ListaEmprestimos { get; set; }
    }
}