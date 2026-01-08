using Microsoft.EntityFrameworkCore;
using BolaoDaCopa2026.Models;

namespace BolaoDaCopa2026.Data
{
    public class BolaoContext : DbContext
    {
        public BolaoContext(DbContextOptions<BolaoContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apostador> Apostadores { get; set; }
        public DbSet<Selecao> Selecoes { get; set; }
        public DbSet<Aposta> Apostas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Usuario <-> Apostador (1:1) com shadow FK
            modelBuilder.Entity<Apostador>()
                .HasOne(a => a.Usuario)
                .WithOne(u => u.Apostador)
                .HasForeignKey<Apostador>("UsuarioId")
                .OnDelete(DeleteBehavior.Cascade);

            // Apostador -> Apostas (1:N)
            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.Apostador)
                .WithMany(ap => ap.Apostas)
                .HasForeignKey(a => a.ApostadorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Aposta -> Selecao A (shadow FK)
            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.SelecaoA)
                .WithMany()
                .HasForeignKey("SelecaoAId")
                .OnDelete(DeleteBehavior.Restrict);

            // Aposta -> Selecao B (shadow FK)
            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.SelecaoB)
                .WithMany()
                .HasForeignKey("SelecaoBId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
