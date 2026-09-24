using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace VapeUnity.Models
{
    public class Contexto : IdentityDbContext<IdentityUser, IdentityRole<string>, string> // Atualizado para usar IdentityRole<string> como tipo genérico
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Fornecedores> Fornecedores { get; set; }
        public DbSet<Faturas> Faturas { get; set; }
        public DbSet<Fatura_Detalhes> FaturaDetalhes { get; set; }
        public DbSet<DadosTemporarios> DadosTemporarios { get; set; }
        public DbSet<Encomendas> Encomendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Usuarios");
            modelBuilder.Entity<IdentityRole>().ToTable("Funcoes");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("ReivindicacoesUsuarios");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsuariosFuncoes");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("LoginsUsuarios");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("TokensUsuarios");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("ReivindicacoesFuncoes");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("ReivindicacoesUsuarios");
            // Configurações do Identity
            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable("Usuarios"); // Nome da tabela no banco de dados
                entity.Property(e => e.Id).HasMaxLength(128); // Tamanho máximo da coluna 'Id' no MySQL (128 é um valor sugerido para GUIDs em formato string)
            });

            // Outras configurações do modelo
            // ...
        }
    }
}
