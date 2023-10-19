using Mini_Auction.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Mini_Auction.Core
{
    public class Auction
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string SellerId { get; set; }

        [Required]
        public decimal StartingPrice { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public Status Status { get; set; }

        public List<Bid> Bids { get; set; }

        public Auction(int id, string title, string description, 
            string sellerId, decimal startingPrice, DateTime endTime, Status status)
        {
            Id = id;
            Title = title;
            Description = description;
            SellerId = sellerId;
            StartingPrice = startingPrice;
            EndTime = endTime;
            Bids = new List<Bid>();
            Status = status;    
        }

        public bool AddBids(Bid b)
        {
            Bids.Add(b);
            if (Bids.Contains(b))
            {
                return true;
            }
            return false;
        }
    }
}
