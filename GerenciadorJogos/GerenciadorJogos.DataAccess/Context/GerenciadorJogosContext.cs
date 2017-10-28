using GerenciadorJogos.DataAccess.Map;
using GerenciadorJogos.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GerenciadorJogos.DataAccess.Context
{
    public class GerenciadorJogosContext : DbContext
    {
        public GerenciadorJogosContext() : base("GerenciadorJogosConn")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }       

        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(200));
            modelBuilder.Properties<DateTime>().Configure(p => p.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new AmigoMap());
            modelBuilder.Configurations.Add(new JogoMap());
            modelBuilder.Configurations.Add(new EmprestimoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

        }
    }
}
