using Microsoft.EntityFrameworkCore;

namespace Mini_Auction.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<AuctionDB> Auctions { get; set; }

        public DbSet<BidDB> Bids { get; set; }

        public DbSet<ClosedAuctionDB> ClosedAuctionDBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClosedAuctionDB>()
            .HasOne(c => c.AuctionDb)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClosedAuctionDB>()
                .HasOne(c => c.WinningBid)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            AuctionDB adb = new AuctionDB
            {
                Id = 1,
                Title = "Playstation 5",
                Description = "Konsol",
                userName = "mohammad.hasan19999@gmail.com",
                StartingPrice = 3000,
                EndTime = DateTime.Now,
                Status = 1,

            };
            modelBuilder.Entity<AuctionDB>().HasData(adb);

        }

        

    }

}

