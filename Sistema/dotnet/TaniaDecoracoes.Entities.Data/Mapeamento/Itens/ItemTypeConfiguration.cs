using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Itens
{
    internal class ItemTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> entity)
        {
            entity
                .ToTable("it_itens");

            #region Propriedades

            entity
                .Property(i => i.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(i => i.Apelido)
                .HasColumnName("Apelido")
                .HasColumnType("varchar")
                .HasMaxLength(120)
                .IsRequired(false);

            entity
                .Property(i => i.TipoItemId)
                .HasColumnName("TipoItem")
                .HasColumnType("integer")
                .IsRequired(true);

            entity
                .Property(i => i.QuantidadeEstoque)
                .HasColumnName("QuantidadeEstoque")
                .HasColumnType("integer")
                .IsRequired(true);

            entity
                .Property(i => i.Preco)
                .HasColumnName("Preco")
                .HasColumnType("decimal(10,0)")
                .IsRequired(false);

            entity
                .Property(i => i.CorId)
                .HasColumnName("Cor")
                .HasColumnType("integer")
                .IsRequired(false);

            entity
                .Property(i => i.TamanhoId)
                .HasColumnName("Tamanho")
                .HasColumnType("integer")
                .IsRequired(false);

            entity
                .Property(i => i.Altura)
                .HasColumnName("Altura")
                .HasColumnType("float")
                .IsRequired(false);

            entity
                .Property(i => i.Comprimento)
                .HasColumnName("Comprimento")
                .HasColumnType("float")
                .IsRequired(false);

            entity
                .Property(i => i.Largura)
                .HasColumnName("Largura")
                .HasColumnType("float")
                .IsRequired(false);

            entity
                .Property(i => i.EnderecoImagem)
                .HasColumnName("Imagem")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired(false);

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(i => i.Id);

            entity
                .HasOne(i => i.TipoItemInstance)
                .WithMany(t => t.Itens)
                .HasForeignKey(i => i.TipoItemId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(i => i.CorInstance)
                .WithMany(c => c.Itens)
                .HasForeignKey(i => i.CorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(i => i.TamanhoInstance)
                .WithMany(c => c.Itens)
                .HasForeignKey(i => i.TamanhoId)
                .OnDelete(DeleteBehavior.Restrict);


            #endregion Relacionamentos
        }
    }
}