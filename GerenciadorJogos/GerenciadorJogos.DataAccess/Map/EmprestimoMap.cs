using GerenciadorJogos.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GerenciadorJogos.DataAccess.Map
{
    public class EmprestimoMap : EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoMap()
        {
            ToTable("tb_emprestimo");            

            HasRequired(x => x.Jogo)
                .WithMany(x => x.ListaEmprestimos)
                .HasForeignKey(x => x.JogoId);
                
            HasRequired(x => x.Amigo)
                .WithMany(x => x.ListaEmprestimos)
                .HasForeignKey(x => x.AmigoId);            

            Property(x => x.DataEmprestimo).IsRequired();
            Property(x => x.DataDevolucao).IsOptional();
        }
    }
}
