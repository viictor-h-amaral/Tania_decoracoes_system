using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.Clientes;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Enderecos
{
    internal class EnderecoClienteTypeConfiguration : IEntityTypeConfiguration<EnderecoCliente>
    {
        public void Configure(EntityTypeBuilder<EnderecoCliente> entity)
        {
            entity
                .ToTable("end_enderecosclientes");

            #region Propriedades

            entity
                .Property(e => e.Id)
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
                .Property(a => a.TipoEnderecoClienteId)
                .HasColumnName("TipoEndereco")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(a => a.NumeroEndereco)
                .HasColumnName("NumeroEndereco")
                .HasColumnType("integer")
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
                .HasKey(ec => ec.Id);

            entity
                .HasOne(ec => ec.EstadoInstance)
                .WithMany(e => e.EnderecosClientes)
                .HasForeignKey(ec => ec.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ec => ec.MunicipioInstance)
                .WithMany(m => m.EnderecosClientes)
                .HasForeignKey(ec => ec.MunicipioId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ec => ec.BairroInstance)
                .WithMany(b => b.EnderecosClientes)
                .HasForeignKey(ec => ec.BairroId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ec => ec.LogradouroInstance)
                .WithMany(l => l.EnderecosClientes)
                .HasForeignKey(ec => ec.LogradouroId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(ec => ec.TipoEnderecoClienteInstance)
                .WithMany(t => t.EnderecosClientes)
                .HasForeignKey(ec => ec.TipoEnderecoClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}