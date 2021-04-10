using ArquiteturaLimpa.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArquiteturaLimpa.Infra.Repositorio.EntityConfiguracoes
{
    public class ContatosConfiguracoes : IEntityTypeConfiguration<Contatos>
    {
        public void Configure(EntityTypeBuilder<Contatos> builder)
        {
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Telefone).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.CPF).HasMaxLength(14).IsRequired();
        }
    }
}