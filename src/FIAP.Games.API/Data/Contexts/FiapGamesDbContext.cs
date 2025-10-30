using FIAP.Games.API.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FIAP.Games.API.Data.Contexts;

public class FiapGamesDbContext : DbContext
{
    public FiapGamesDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Jogo> Jogos { get; set; }
}
