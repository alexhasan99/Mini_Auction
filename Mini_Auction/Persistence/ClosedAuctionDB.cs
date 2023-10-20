using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Auction.Persistence
{
    public class ClosedAuctionDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDB AuctionDb { get; set; }


        [ForeignKey("WinnigBidId")]
        public BidDB WinningBidId { get; set; }
    }
}
