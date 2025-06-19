using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Data.Mapeamento.Utilitários;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.TabelasGerais
{
    internal class CarroTypeConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> entity)
        {
            entity
                .ToTable("ta_carros");

            #region Propriedades

            entity
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(c => c.Apelido)
                .HasColumnName("Apelido")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();

            entity
                .Property(c => c.LitrosPorKm)
                .HasColumnName("LitrosPorKm")
                .HasColumnType("float")
                .IsRequired();

            entity
                .Property(c => c.TipoCombustivelId)
                .HasColumnName("TipoCombustivel")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(c => c.EstaAtivo)
                .HasColumnName("EstaAtivo")
                .HasColumnType("tinyint")
                .IsRequired(false)
                .HasConversion(new NullableTinyIntToBoolConverter());

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(c => c.Id);

            entity
                .HasOne(c => c.TipoCombustivelInstance)
                .WithMany(t => t.Carros)
                .HasForeignKey(c => c.TipoCombustivelId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}
