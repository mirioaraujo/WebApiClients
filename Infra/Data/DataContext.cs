using Microsoft.EntityFrameworkCore;
using WebApiClients.Model;

namespace WebApiClients.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ClientModel> Clientes { get; set; }
        public DbSet<AddressModel> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressModel>()
                        .HasOne(p => p.Usuario)
                        .WithMany(b => b.Endereco)
                        .HasForeignKey(p => p.IdCliente);
        }

    }
}
