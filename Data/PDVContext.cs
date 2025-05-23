using Microsoft.EntityFrameworkCore;
using PDVApp.Models;

namespace PDVApp.Data
{
    public class PDVContext : DbContext
    {
        public PDVContext(DbContextOptions<PDVContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
