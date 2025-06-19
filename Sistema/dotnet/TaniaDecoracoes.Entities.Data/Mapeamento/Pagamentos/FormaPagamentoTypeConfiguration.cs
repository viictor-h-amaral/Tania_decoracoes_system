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
    public class FormaPagamentoTypeConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> entity)
        {
            entity
                .ToTable("fp_formaspagamento");

            #region Propriedades

            entity
                .Property(fp => fp.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(fp => fp.Nome)
                .HasColumnName("FormaPagamento")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            entity
                .Property(fp => fp.Parcelado)
                .HasColumnName("Parcelado")
                .HasColumnType("tinyint")
                .IsRequired()
                .HasConversion(new TinyIntToBoolConverter());

            entity
                .Property(fp => fp.NumeroParcelas)
                .HasColumnName("NumeroParcelas")
                .HasColumnType("integer")
                .IsRequired(false);

            entity
                .Property(fp => fp.TaxaParcelamentoId)
                .HasColumnName("TaxaParcelamento")
                .HasColumnType("integer")
                .IsRequired(false);

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(fp => fp.Id);

            entity
                .HasOne(fp => fp.TaxaParcelamentoInstance)
                .WithMany(tx => tx.FormasPagamento)
                .HasForeignKey(fp => fp.TaxaParcelamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasMany(fp => fp.DecoracoesPagamentosEntradas)
                .WithOne(dp => dp.FormaPagamentoEntradaInstance)
                .HasForeignKey(dp => dp.FormaPagamentoEntradaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasMany(fp => fp.DecoracoesPagamentosRestante)
                .WithOne(dp => dp.FormaPagamentoRestanteInstance)
                .HasForeignKey(dp => dp.FormaPagamentoRestanteId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}