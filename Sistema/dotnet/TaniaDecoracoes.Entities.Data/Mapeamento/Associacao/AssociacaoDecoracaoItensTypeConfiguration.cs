using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Associacao;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Associacao
{
    internal class AssociacaoDecoracaoItensTypeConfiguration : IEntityTypeConfiguration<AssociacaoDecoracaoItens>
    {
        public void Configure(EntityTypeBuilder<AssociacaoDecoracaoItens> entity)
        {
            entity
                .ToTable("assoc_decoracoes_itens");

            #region Propriedades

            entity
                .Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(a => a.DecoracaoId)
                .HasColumnName("Decoracao")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(a => a.ItemId)
                .HasColumnName("Item")
                .HasColumnType("integer")
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(a => a.Id);

            entity
                .HasOne(a => a.DecoracaoInstance)
                .WithMany(d => d.AssociacaoDecoracaoItens)
                .HasForeignKey(a => a.DecoracaoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(a => a.ItemInstance)
                .WithMany(i => i.AssociacaoDecoracaoItens)
                .HasForeignKey(a => a.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}
