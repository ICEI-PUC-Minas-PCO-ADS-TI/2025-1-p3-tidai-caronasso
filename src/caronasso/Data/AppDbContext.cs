using caronasso.Models;
using Microsoft.EntityFrameworkCore;

namespace caronasso.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatParticipante>()
            .HasKey(chatp => new { chatp.ChatId, chatp.UsuarioId });

        modelBuilder.Entity<CaronaPassageiro>()
            .HasKey(caronap => new { caronap.CaronaId, caronap.UsuarioId });

        modelBuilder.Entity<CaronaPassageiro>()
            .HasOne(caronap => caronap.Usuario)
            .WithMany(u => u.CaronasComoPassageiro)
            .HasForeignKey(caronap => caronap.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Mensagem> Mensagens { get; set; }
    public DbSet<ChatParticipante> ChatParticipantes { get; set; }
    public DbSet<Carona> Caronas { get; set; }
    public DbSet<CaronaPassageiro> CaronaPassageiros { get; set; }
}
