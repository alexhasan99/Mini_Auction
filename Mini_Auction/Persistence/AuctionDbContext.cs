using Microsoft.EntityFrameworkCore;

namespace Mini_Auction.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<AuctionDB> Auctions { get; set; }

        public DbSet<BidDB> Bids { get; set; }
    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        // Förhindra kaskad borttagning från UserDB till Bids
        modelBuilder.Entity<UserDB>()
            .HasMany(u => u.Bids)
            .WithOne(b => b.Bidder)
            .OnDelete(DeleteBehavior.NoAction);

        // Ange beteendet för kaskad borttagning mellan andra tabeller om det är nödvändigt
    }*/
}
