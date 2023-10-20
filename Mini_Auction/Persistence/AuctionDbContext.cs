using Microsoft.EntityFrameworkCore;

namespace Mini_Auction.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<AuctionDB> Auctions { get; set; }

        public DbSet<BidDB> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDB>().HasData(
                new AuctionDB
                {

                })
        }
    }
}
