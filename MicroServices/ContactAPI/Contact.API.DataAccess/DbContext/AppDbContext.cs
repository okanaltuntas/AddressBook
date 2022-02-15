using Microsoft.EntityFrameworkCore;

namespace Contact.API.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Contacts;Persist Security Info=True;Trusted_Connection=True");
        }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.Contact> Contact { get; set; }
        public virtual DbSet<Entities.ContactInformation> ContactInformation { get; set; }
    }
}
