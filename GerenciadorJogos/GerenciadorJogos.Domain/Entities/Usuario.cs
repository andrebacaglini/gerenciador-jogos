using System;

namespace GerenciadorJogos.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual bool EstaValido{ get; set; }
    }
}
