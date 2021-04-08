using ArquiteturaLimpa.Dominio.Entidades;
using ArquiteturaLimpa.Infra.Repositorio.EntityConfiguracoes;
using Microsoft.EntityFrameworkCore;


namespace ArquiteturaLimpa.Infra.Repositorio.Contexto
{
    public class ArquiteturaLimpaContexto : DbContext
    {
        public ArquiteturaLimpaContexto(DbContextOptions<ArquiteturaLimpaContexto> options) : base(options) { }

        public DbSet<Contatos> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ContatosConfiguracoes());
        }
    }
}