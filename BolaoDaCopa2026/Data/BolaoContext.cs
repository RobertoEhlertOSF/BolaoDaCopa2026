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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // Usuario <-> Apostador (1:1)
            // =========================
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Apostador)
                .WithOne(a => a.Usuario)
                .HasForeignKey<Apostador>(a => a.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // Usuario <-> Apostador (1:1)
            // =========================
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Apostador)
                .WithOne(a => a.Usuario)
                .HasForeignKey<Apostador>(a => a.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            // =========================
            // Apostador -> Apostas (1:N)
            // =========================
            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.Apostador)
                .WithMany(ap => ap.Apostas)
                .HasForeignKey(a => a.ApostadorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // =========================
            // Aposta -> Selecao A
            // =========================
            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.SelecaoA)
                .WithMany()
                .HasForeignKey("SelecaoAId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // Aposta -> Selecao B
            // =========================
            modelBuilder.Entity<Aposta>()
                .HasOne(a => a.SelecaoB)
                .WithMany()
                .HasForeignKey("SelecaoBId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // =========================
            // Selecao
            // =========================
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

        }
    }
}


