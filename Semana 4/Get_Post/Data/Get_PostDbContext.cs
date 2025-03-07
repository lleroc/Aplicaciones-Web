namespace Get_Post.Data
{
    using Get_Post.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class Get_PostDbContext:IdentityDbContext
    {
        public Get_PostDbContext(DbContextOptions<Get_PostDbContext> db):base(db)
        {
            //que tipo de proyecto ????
            //conectar con una API de IA
        }

        public DbSet<TipoPreguntaModel> TipoPreguntas { get; set; }
        public DbSet<PreguntasModel> Preguntas { get; set; }
    }
}
