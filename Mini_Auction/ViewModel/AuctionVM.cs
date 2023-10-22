using Mini_Auction.Core;
using Mini_Auction.Persistence;
using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace Mini_Auction.ViewModel
{
    public class AuctionVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string SellerId { get; set; }

        public double StartingPrice { get; set; }

        public DateTime EndTime { get; set; }

        public List<BidVM> Bids { get; set; }

        public Status Status { get; set; }

        public static AuctionVM FromAuction (Auction auction)
        {
            AuctionVM a= new AuctionVM()
            {
                Id = auction.Id,
                Title = auction.Title,
                Description = auction.Description,
                SellerId = auction.UserName,
                StartingPrice = auction.StartingPrice,
                EndTime = auction.EndTime,
                Status = auction.Status,
            };
            foreach (Bid b in auction.Bids)
            {
                a.AddBids(new BidVM(b.Id, b.AuctionId, b.BidderId, b.Amount, b.BidTime));
            }

            return a;
        }
        
        public bool AddBids (BidVM b)
        {
            Bids.Add(b);
            if (Bids.Contains (b))
            {
                return true;
            }
            return false;
        }
    }

}
