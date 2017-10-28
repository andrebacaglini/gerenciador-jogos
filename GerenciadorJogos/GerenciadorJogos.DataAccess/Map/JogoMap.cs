using GerenciadorJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorJogos.DataAccess.Map
{
    public class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {

            ToTable("tb_jogo");

            HasKey(x => x.JogoId);

            Property(x => x.Nome).HasMaxLength(100).IsRequired();
            Property(x => x.Plataforma).IsRequired();
        }
    }
}
