using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class TipoLogradouroTypeConfiguration : IEntityTypeConfiguration<TipoLogradouro>
    {
        public void Configure(EntityTypeBuilder<TipoLogradouro> entity)
        {
            entity
                .ToTable("end_tiposlogradouros");

            #region Propriedades

            entity
                .Property(tl => tl.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(tl => tl.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(tl => tl.Id);

            #endregion Relacionamentos
        }
    }
}
