using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Itens;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Itens
{
    internal class TipoItemTypeConfiguration : IEntityTypeConfiguration<TipoItem>
    {
        public void Configure(EntityTypeBuilder<TipoItem> entity)
        {
            entity
                .ToTable("it_tipositens");

            #region Propriedades

            entity
                .Property(ti => ti.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(ti => ti.Nome)
                .HasColumnName("TipoItem")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(ti => ti.Id);

            #endregion Relacionamentos
        }
    }
}