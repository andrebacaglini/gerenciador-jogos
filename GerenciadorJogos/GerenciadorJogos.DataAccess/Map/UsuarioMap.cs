using GerenciadorJogos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorJogos.DataAccess.Map
{
    public class UsuarioMap: EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("tb_usuario");

            HasKey(x => x.UsuarioId);

            Property(x => x.NomeUsuario).HasMaxLength(50).IsRequired();
            Property(x => x.Senha).HasMaxLength(50).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.Email).HasMaxLength(100).IsRequired();
            Ignore(x => x.EstaValido);

        }
    }
}
