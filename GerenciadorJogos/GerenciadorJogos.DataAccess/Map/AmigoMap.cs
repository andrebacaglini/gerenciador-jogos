using GerenciadorJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorJogos.DataAccess.Map
{
    public class AmigoMap : EntityTypeConfiguration<Amigo>
    {
        public AmigoMap()
        {

            ToTable("tb_amigo");

            HasKey(x => x.AmigoId);

            HasRequired(x => x.Usuario)
                .WithMany(x => x.ListaAmigos)
                .HasForeignKey(x => x.UsuarioId);

            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Sobrenome).HasMaxLength(100).IsRequired();
            Property(x => x.Apelido).HasMaxLength(50).IsOptional();
        }
    }
}
