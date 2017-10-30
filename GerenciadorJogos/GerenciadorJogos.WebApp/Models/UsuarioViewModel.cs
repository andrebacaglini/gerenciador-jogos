using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.Util.Constantes;
using GerenciadorJogos.Util.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogos.WebApp.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        [MaxLength(50, ErrorMessage = MensagensInterface.TAMANHO_INVALIDO)]
        public string NomeUsuario { get; set; }

        private string _senha;

        [Display(Name = "Senha")]
        [Required(ErrorMessage = MensagensInterface.CAMPO_OBRIGATORIO)]
        public virtual string Senha
        {
            get { return _senha; }

            set
            {
                _senha = CriptografiaHelper.Criptografar(value);

            }
        }

        [Display(Name = "E-mail")]
        [Required]
        [MaxLength(100, ErrorMessage = MensagensInterface.TAMANHO_INVALIDO)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }


    }
}