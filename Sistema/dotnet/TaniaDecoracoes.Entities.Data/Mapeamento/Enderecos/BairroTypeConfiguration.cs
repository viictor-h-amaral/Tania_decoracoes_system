using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class BairroTypeConfiguration : IEntityTypeConfiguration<Bairro>
    {
        public void Configure(EntityTypeBuilder<Bairro> entity)
        {

            entity
                .ToTable("end_bairros");

            #region Propriedades

            entity
                .Property(b => b.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(b => b.MunicipioId)
                .HasColumnName("Municipio")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(b => b.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(45)
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(b => b.Id);

            entity
                .HasOne(b => b.MunicipioInstance)
                .WithMany(m => m.Bairros)
                .HasForeignKey(b => b.MunicipioId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}
