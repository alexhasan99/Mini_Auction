using Mini_Auction.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Mini_Auction.Core
{
    public class Bid
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public string BidderId { get; set; }

        public double Amount { get; set; }

        public DateTime BidTime { get; set; }

        public Bid(int id, int auctionId, string bidderId, 
            double amount, DateTime bidTime)
        {
            Id = id;
            AuctionId = auctionId;
            BidderId = bidderId;
            Amount = amount;
            BidTime = bidTime;
        }

        public static Bid FromBidVM (BidVM vm)
        {
            return new Bid(vm.Id, vm.AuctionId, vm.BidderId, vm.Amount, vm.BidTime);
        }
    }
}
