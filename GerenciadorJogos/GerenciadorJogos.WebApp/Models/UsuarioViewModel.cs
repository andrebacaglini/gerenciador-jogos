using System.ComponentModel.DataAnnotations;

namespace GerenciadorJogos.WebApp.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="Campo obrigatório.")]
        [MaxLength(50,ErrorMessage ="Tamanho inválido.")]
        public string NomeUsuario { get; set; }

        private string _senha;

        [Required(ErrorMessage ="Campo obrigatório.")]
        public virtual string Senha
        {
            get { return _senha; }

            set
            {
                _senha = System.Text.Encoding.ASCII.GetString(
                    new System.Security.Cryptography.SHA256Managed().ComputeHash(
                        System.Text.Encoding.ASCII.GetBytes(value)));

            }
        }
    }
}