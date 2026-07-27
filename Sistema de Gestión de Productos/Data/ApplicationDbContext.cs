using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestión_de_Productos.Models;

namespace Sistema_de_Gestión_de_Productos.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
