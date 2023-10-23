using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Auction.Persistence
{
    public class ClosedAuctionDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AuctionDb")]
        public int AuctionId { get; set; }
        public AuctionDB AuctionDb { get; set; }

        [ForeignKey("WinningBid")]
        public int WinningBidId { get; set; }
        public BidDB WinningBid { get; set; }
    }
}
