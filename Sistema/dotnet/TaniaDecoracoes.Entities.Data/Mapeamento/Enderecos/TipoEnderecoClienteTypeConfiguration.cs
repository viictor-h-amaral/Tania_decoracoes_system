using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class TipoEnderecoClienteTypeConfiguration : IEntityTypeConfiguration<TipoEnderecoCliente>
    {
        public void Configure(EntityTypeBuilder<TipoEnderecoCliente> entity)
        {
            entity
                .ToTable("end_tiposenderecosclientes");

            #region Propriedades

            entity
                .Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(t => t.TipoEndereco)
                .HasColumnName("TipoEndereco")
                .HasColumnType("varchar")
                .HasMaxLength(35)
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(t => t.Id);

            #endregion Relacionamentos
        }
    }
}
