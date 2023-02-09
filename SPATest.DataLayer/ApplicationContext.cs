using Microsoft.EntityFrameworkCore;
using SPATest.DataLayer.Entities;

namespace SPATest.DataLayer
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<MusicOffer> MusicOffers { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=spatestdb;Trusted_Connection=True;");
        }
    }
}
