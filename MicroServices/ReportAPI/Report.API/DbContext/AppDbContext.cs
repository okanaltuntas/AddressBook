using Microsoft.EntityFrameworkCore;
using Report.API.Model;

namespace Report.API
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

        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContactInformation> ContactInformation { get; set; }
        public virtual DbSet<NumbersOfAtLocation> NumbersOfAtLocation { get; set; }
    }
}
