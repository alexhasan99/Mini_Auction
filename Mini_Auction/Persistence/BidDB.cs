namespace Mini_Auction.Persistence
using System.ComponentModel.DataAnnotations;
{
using System.ComponentModel.DataAnnotations.Schema;

public class BidDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDB AuctionDB { get; set; }

        [ForeignKey("BidderId")]
        public UserDB UserDB { get; set; }

        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }

    }
}
