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
    internal class TamanhoTypeConfiguration : IEntityTypeConfiguration<Tamanho>
    {
        public void Configure(EntityTypeBuilder<Tamanho> entity)
        {
            entity
                .ToTable("ta_tamanhos");

            #region Propriedades

            entity
                .Property(t => t.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(t => t.Valor)
                .HasColumnName("Tamanho")
                .HasColumnType("varchar")
                .HasMaxLength(25)
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(t => t.Id);

            #endregion Relacionamentos
        }
    }
}
