using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Data.Mapeamento.Utilitários;
using TaniaDecoracoes.Entities.Models.Pagamentos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Pagamentos
{
    public class TaxaParcelamentoTypeConfiguration : IEntityTypeConfiguration<TaxaParcelamento>
    {
        public void Configure(EntityTypeBuilder<TaxaParcelamento> entity)
        {
            entity
                .ToTable("pg_taxasparcelamento");

            #region Propriedades

            entity
                .Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(t => t.Juros)
                .HasColumnName("Juros")
                .HasColumnType("decimal(6,3)")
                .IsRequired();

            entity
                .Property(t => t.Meses)
                .HasColumnName("Meses")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(t => t.JurosCompostos)
                .HasColumnName("JurosCompostos")
                .HasColumnType("TinyInt(1)");
                //.IsRequired(false);

            entity
                .Property(t => t.JurosCompostos)
                .HasColumnName("JurosCompostos")
                .HasColumnType("TinyInt")
                .HasConversion(new TinyIntToBoolConverter());

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(t => t.Id);

            #endregion Relacionamentos
        }
    }
}