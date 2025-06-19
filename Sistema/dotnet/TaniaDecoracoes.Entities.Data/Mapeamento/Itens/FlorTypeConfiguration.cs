using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Itens
{
    internal class FlorTypeConfiguration : IEntityTypeConfiguration<Flor>
    {
        public void Configure(EntityTypeBuilder<Flor> entity)
        {
            entity
                .ToTable("it_flores");

            #region Propriedades

            entity
                .Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd(); ;

            entity
                .Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(f => f.PrecoTemporada)
                .HasColumnName("PrecoTemporada")
                .HasColumnType("decimal(10,0)")
                .IsRequired(false);

            entity
                .Property(f => f.PrecoPadrao)
                .HasColumnName("PrecoPadrao")
                .HasColumnType("decimal(10,0)")
                .IsRequired();
            
            entity
                .Property(f => f.EnderecoImagem)
                .HasColumnName("Imagem")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);

            entity
                .Property(f => f.CorId)
                .HasColumnName("Cor")
                .HasColumnType("integer")
                .IsRequired(false);

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(f => f.Id);

            entity
                .HasOne(f => f.CorInstance)
                .WithMany(c => c.Flores)
                .HasForeignKey(f => f.CorId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}