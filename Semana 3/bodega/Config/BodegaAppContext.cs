using Bodega.Models;
using Microsoft.EntityFrameworkCore;

namespace Bodega.Config
{
    public class BodegaAppContext:DbContext
    {
        public BodegaAppContext(DbContextOptions contexto):base(contexto) 
        {
            
        }

        /*stock*/

        public DbSet<ProductosModel> Productos { get; set; }
        public DbSet<ProveedorModel> Proveedores { get; set; }
        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
    }
}


//add-migration   nombre_migracion

// update-database
