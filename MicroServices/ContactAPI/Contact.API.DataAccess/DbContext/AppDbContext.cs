using Microsoft.EntityFrameworkCore;

namespace Contact.API.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.Contact> Contact { get; set; }
        public virtual DbSet<Entities.ContactInformation> ContactInformation { get; set; }
    }
}
