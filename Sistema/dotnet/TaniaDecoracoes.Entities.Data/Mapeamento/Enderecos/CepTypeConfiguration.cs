using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class CepTypeConfiguration : IEntityTypeConfiguration<Cep>
    {
        public void Configure(EntityTypeBuilder<Cep> entity)
        {
            entity
                .ToTable("end_ceps");

            #region Propriedades

            entity
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(c => c.LogradouroId)
                .HasColumnName("Logradouro")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(c => c.CepValor)
                    .HasColumnName("Cep")
                    .HasColumnType("varchar")
                    .HasMaxLength(8)
                    .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(c => c.Id); 

            entity
                .HasOne(c => c.LogradouroInstance)
                .WithMany(l => l.Ceps)
                .HasForeignKey(c => c.LogradouroId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }


    }
}
