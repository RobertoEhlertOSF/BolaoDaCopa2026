using BolaoDaCopa2026.Data.Seeds;
using BolaoDaCopa2026.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Apostador)
                .WithOne(a => a.Usuario)
                .HasForeignKey<Apostador>(a => a.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.Apostador)
                .WithMany(ap => ap.Apostas)
                .HasForeignKey(a => a.ApostadorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.SelecaoA)
                .WithMany()
                .HasForeignKey(a => a.SelecaoAId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.SelecaoB)
                .WithMany()
                .HasForeignKey(a => a.SelecaoBId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.SelecaoVencedora)
                .WithMany()
                .HasForeignKey(a => a.SelecaoVencedoraId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Selecao>()
                .Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Selecao>()
                .Property(s => s.Grupo)
                .HasMaxLength(1);

            modelBuilder.Entity<Selecao>()
                .Property(s => s.BandeiraUrl)
                .HasMaxLength(300);

            SelecaoSeed.Seed(modelBuilder);

            modelBuilder.Entity<Jogo>()
                .HasOne(j => j.SelecaoA)
                .WithMany()
                .HasForeignKey(j => j.SelecaoAId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jogo>()
                .HasOne(j => j.SelecaoB)
                .WithMany()
                .HasForeignKey(j => j.SelecaoBId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jogo>()
                .HasOne(j => j.SelecaoVencedora)
                .WithMany()
                .HasForeignKey(j => j.SelecaoVencedoraId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PasswordResetToken>()
                .HasOne(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PasswordResetToken>()
                .HasIndex(t => t.TokenHash)
                .IsUnique();
        }
    }
}


