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
    internal class TipoCombustivelTypeConfiguration : IEntityTypeConfiguration<TipoCombustivel>
    {
        public void Configure(EntityTypeBuilder<TipoCombustivel> entity)
        {
            entity
                .ToTable("ta_tiposcombustiveis");

            #region Propriedades

            entity
                .Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(t => t.NomeCombustivel)
                .HasColumnName("TipoCombustivel")
                .HasColumnType("varhcar")
                .HasMaxLength(40)
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(t => t.Id);

            #endregion Relacionamentos
        }
    }
}
