using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Associacao.Tabelas;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Associacao
{
    internal class AssociacaoDecoracaoItensTypeConfiguration : IEntityTypeConfiguration<AssociacaoDecoracaoItens>
    {
        private AssociacaoDecoracaoItensTabela tabela = new AssociacaoDecoracaoItensTabela();

        public void Configure(EntityTypeBuilder<AssociacaoDecoracaoItens> entity)
        {
            entity
                .ToTable(tabela.NameInDataBase);

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
