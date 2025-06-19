using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class MunicipioTypeConfiguration : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> entity)
        {
            entity
                .ToTable("end_municipios");

            #region Propriedades

            entity
                .Property(m => m.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(m => m.EstadoId)
                .HasColumnName("Estado")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(m => m.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            entity
                .Property(m => m.CodigoIBGE)
                .HasColumnName("Codigo_IBGE")
                .HasColumnType("integer");

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(m => m.Id);

            entity
                .HasOne(m => m.EstadoInstance)
                .WithMany(e => e.Municipios)
                .HasForeignKey(m => m.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}
