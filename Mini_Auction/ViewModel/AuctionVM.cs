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

        public List<BidVM> BidsVMs { get; set; }

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
                BidsVMs = new List<BidVM>()
            };
            foreach (Bid b in auction.Bids)
            {
                a.AddBids(BidVM.FromBid(b));
            }

            return a;
        }
        
        public bool AddBids (BidVM b)
        {
            BidsVMs.Add(b);
            if (BidsVMs.Contains (b))
            {
                return true;
            }
            return false;
        }
    }

}
