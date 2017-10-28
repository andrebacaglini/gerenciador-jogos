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

            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Sobrenome).HasMaxLength(100).IsRequired();
            Property(x => x.Apelido).HasMaxLength(50).IsOptional();
        }
    }
}
