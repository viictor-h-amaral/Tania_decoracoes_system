using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Clientes;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Clientes
{
    internal class DependenteClienteTypeConfiguration : IEntityTypeConfiguration<DependenteCliente>
    {
        public void Configure(EntityTypeBuilder<DependenteCliente> entity)
        {
            entity
                .ToTable("cl_dependentesclientes");

            #region Propriedades

            entity
                .Property(d => d.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(d => d.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(60)")
                .HasMaxLength(60)
                .IsRequired();

            entity
                .Property(d => d.DataAniversario)
                .HasColumnName("DataAniversario")
                .HasColumnType("Date")
                .IsRequired();

            entity
                .Property(d => d.ResponsavelId)
                .HasColumnName("Responsavel")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(d => d.GeneroId)
                .HasColumnName("Genero")
                .HasColumnType("integer")
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(d => d.Id);

            entity
                .HasOne(d => d.ResponsavelInstance)
                .WithMany(r => r.DependentesClientes)
                .HasForeignKey(d => d.ResponsavelId);

            entity
                .HasOne(d => d.GeneroInstance)
                .WithMany(g => g.DependentesClientes)
                .HasForeignKey(d => d.GeneroId);

            #endregion Relacionamentos
        }
    }
}
