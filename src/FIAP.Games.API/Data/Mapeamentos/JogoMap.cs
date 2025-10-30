using FIAP.Games.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Games.API.Data.Mapeamentos;

public class JogoMap : IEntityTypeConfiguration<Jogo>
{
    public void Configure(EntityTypeBuilder<Jogo> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Titulo)
            .HasMaxLength(255)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(p => p.Preco)
            .HasPrecision(18, 2);

        builder.ToTable("Jogos");
    }
}
