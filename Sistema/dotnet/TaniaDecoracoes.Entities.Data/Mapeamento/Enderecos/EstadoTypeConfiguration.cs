using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class EstadoTypeConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> entity)
        {
            entity
                .ToTable("end_estados");

            #region Propriedades

            entity
                .Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            entity
                .Property(m => m.Sigla)
                .HasColumnName("Sigla")
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(e => e.Id);

            #endregion Relacionamentos
        }
    }
}
