using System.ComponentModel.DataAnnotations;

namespace Mini_Auction.Core
{
    public class Bid
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public string BidderId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime BidTime { get; set; }

        public Bid(int id, int auctionId, string bidderId, 
            decimal amount, DateTime bidTime)
        {
            Id = id;
            AuctionId = auctionId;
            BidderId = bidderId;
            Amount = amount;
            BidTime = bidTime;
        }
    }
}
