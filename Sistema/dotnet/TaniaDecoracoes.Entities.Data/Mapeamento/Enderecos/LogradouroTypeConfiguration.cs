using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class LogradouroTypeConfiguration : IEntityTypeConfiguration<Logradouro>
    {
        public void Configure(EntityTypeBuilder<Logradouro> entity)
        {

            entity
                .ToTable("end_logradouros");

            #region Propriedades

            entity
                .Property(l => l.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(l => l.BairroId)
                .HasColumnName("Bairro")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(l => l.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(120)
                .IsRequired();

            entity
                .Property(l => l.TipoLogradouroId)
                .HasColumnName("Tipo")
                .HasColumnType("integer");

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(entity => entity.Id);

            entity
                .HasOne(l => l.BairroInstance)
                .WithMany(b => b.Logradouros)
                .HasForeignKey(l => l.BairroId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(l => l.TipoLogradouroInstance)
                .WithMany(tl => tl.Logradouros)
                .HasForeignKey(l => l.TipoLogradouroId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}
