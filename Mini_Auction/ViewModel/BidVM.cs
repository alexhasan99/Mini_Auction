using Mini_Auction.Core;
using System.ComponentModel.DataAnnotations;

namespace Mini_Auction.ViewModel
{
    public class BidVM
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public string BidderId { get; set; }
        
        public double Amount { get; set; }
        
        public DateTime BidTime { get; set; }

        public static BidVM FromBid(Bid b)
        {
            BidVM bidVM = new BidVM()
            {
                Id = b.Id,
                Amount = b.Amount,
                BidderId = b.BidderId,
                AuctionId = b.AuctionId,
                BidTime = b.BidTime,
            };
            return bidVM;
        }
    }
}
