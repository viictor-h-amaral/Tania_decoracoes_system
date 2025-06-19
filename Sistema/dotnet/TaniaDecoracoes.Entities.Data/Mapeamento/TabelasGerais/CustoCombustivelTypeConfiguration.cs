using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.TabelasGerais
{
    internal class CustoCombustivelTypeConfiguration : IEntityTypeConfiguration<CustoCombustivel>
    {
        public void Configure(EntityTypeBuilder<CustoCombustivel> entity)
        {
            entity
                .ToTable("ta_custoscombustiveis");

            #region Propriedades

            entity
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(c => c.CombustivelId)
                .HasColumnName("Combustivel")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(c => c.ReaisPorLitro)
                .HasColumnName("ReaisPorLitro")
                .HasColumnType("decimal(10,0)")
                .IsRequired();

            entity
                .Property(c => c.DataInicial)
                .HasColumnName("DataInicial")
                .HasColumnType("date")
                .IsRequired();

            entity
                .Property(c => c.DataFinal)
                .HasColumnName("DataFinal")
                .HasColumnType("date")
                .IsRequired(false);

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(c => c.Id);

            #endregion Relacionamentos
        }
    }
}
