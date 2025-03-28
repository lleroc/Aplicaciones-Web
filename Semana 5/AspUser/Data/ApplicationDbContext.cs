using AspUser.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspUser.Data
{
    public class ApplicationDbContext : IdentityDbContext<UsuariosModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VentasModel> Ventas { get; set; }

    }
}
