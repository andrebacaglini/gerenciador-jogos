using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.Util.Constantes;
using GerenciadorJogos.Util.Helpers;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogos.WebApp.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        [MaxLength(50, ErrorMessage = MensagensInterface.TAMANHO_INVALIDO)]
        public string NomeUsuario { get; set; }

        private string _senha;

        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        public virtual string Senha
        {
            get { return _senha; }

            set
            {
                _senha = CriptografiaHelper.Criptografar(value);

            }
        }
    }
}