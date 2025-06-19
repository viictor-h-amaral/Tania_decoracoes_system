using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Enderecos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class EnderecoEventoTypeConfiguration : IEntityTypeConfiguration<EnderecoEvento>
    {
        public void Configure(EntityTypeBuilder<EnderecoEvento> entity)
        {
            entity
                .ToTable("end_enderecoseventos");

            #region Propriedades

            entity
                .Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(a => a.EstadoId)
                .HasColumnName("Estado")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(a => a.MunicipioId)
                .HasColumnName("Municipio")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(a => a.BairroId)
                .HasColumnName("Bairro")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(a => a.LogradouroId)
                .HasColumnName("Logradouro")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(a => a.TipoEnderecoEventoId)
                .HasColumnName("TipoEndereco")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(a => a.NumeroEndereco)
                .HasColumnName("NumeroEndereco")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(ev => ev.Apelido)
                .HasColumnName("Apelido")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(ec => ec.Observacoes)
                .HasColumnName("Observacoes")
                .HasColumnType("text");

            entity
                .Property(ec => ec.AndarApartamento)
                .HasColumnName("AndarApartamento")
                .HasColumnType("integer");

            entity
                .Property(ec => ec.NumeroApartamento)
                .HasColumnName("NumeroApartamento")
                .HasColumnType("integer");

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(ev => ev.Id);

            entity
                .HasOne(ev => ev.EstadoInstance)
                .WithMany(e => e.EnderecosEventos)
                .HasForeignKey(ev => ev.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ev => ev.MunicipioInstance)
                .WithMany(m => m.EnderecosEventos)
                .HasForeignKey(ev => ev.MunicipioId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ev => ev.BairroInstance)
                .WithMany(b => b.EnderecosEventos)
                .HasForeignKey(ev => ev.BairroId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ev => ev.LogradouroInstance)
                .WithMany(l => l.EnderecosEventos)
                .HasForeignKey(ev => ev.LogradouroId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ev => ev.TipoEnderecoEventoInstance)
                .WithMany(t => t.EnderecosEventos)
                .HasForeignKey(ev => ev.TipoEnderecoEventoId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}
