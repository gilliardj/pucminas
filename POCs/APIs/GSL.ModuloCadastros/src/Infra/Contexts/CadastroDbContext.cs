using Domain.Entidades;
using Domain.Interfaces.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts
{
    public class CadastroDbContext : DbContext, IUnitOfWork
    {
        public DbSet<ClienteEntity> Clientes { get; set; }

        public CadastroDbContext(DbContextOptions<CadastroDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ClienteEntity => Clientes

            modelBuilder.Entity<ClienteEntity>(
                        t => t
                        .ToTable("clientes")
                        .HasKey(k => k.Id)
                        );

            modelBuilder.Entity<ClienteEntity>()
                        .Property(p => p.Id)
                        .HasColumnName("id")
                        .IsRequired();

            modelBuilder.Entity<ClienteEntity>()
                        .Property(p => p.Nome)
                        .HasColumnName("nome")
                        .IsRequired();

            modelBuilder.Entity<ClienteEntity>()
                        .Property(p => p.Endereco)
                        .HasColumnName("endereco")
                        .IsRequired();

            modelBuilder.Entity<ClienteEntity>()
                        .Property(p => p.Email)
                        .HasColumnName("email")
                        .IsRequired();

            modelBuilder.Entity<ClienteEntity>()
                        .Property(p => p.Documento)
                        .HasColumnName("documento")
                        .IsRequired();

            modelBuilder.Entity<ClienteEntity>()
                        .Property(p => p.Telefone)
                        .HasColumnName("telefone")
                        .IsRequired();

            #endregion ClienteEntity => Clientes

            base.OnModelCreating(modelBuilder);
        }

        public void Persistir()
        {
            base.SaveChanges();
        }
    }
}