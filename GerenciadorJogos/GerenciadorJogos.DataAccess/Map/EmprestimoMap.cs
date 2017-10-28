using GerenciadorJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorJogos.DataAccess.Map
{
    public class EmprestimoMap : EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoMap()
        {
            ToTable("tb_emprestimo");

            HasKey(x => x.EmprestimoId);
            
            HasRequired(x => x.Jogo);
            HasRequired(x => x.Amigo)
                .WithMany(x => x.ListaEmprestimos)
                .HasForeignKey(x => x.AmigoId);

            Property(x => x.DataEmprestimo).IsRequired();
            Property(x => x.DataDevolucao).IsOptional();
        }
    }
}
