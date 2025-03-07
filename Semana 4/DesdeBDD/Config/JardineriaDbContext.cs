using Microsoft.EntityFrameworkCore;

namespace DesdeBDD.Config
{
    public class JardineriaDbContext:DbContext
    {
        public JardineriaDbContext( DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
    }
}
