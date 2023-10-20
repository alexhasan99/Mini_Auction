namespace Mini_Auction.Persistence
{
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

    public class BidDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDB AuctionDB { get; set; }

        [ForeignKey("BidderId")]
        public UserDB UserDB { get; set; }

        public double Amount { get; set; }

        public DateTime BidTime { get; set; }

    }
}
