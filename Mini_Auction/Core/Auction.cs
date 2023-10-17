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

        public List<Bid> Bids { get; set; }

        public Auction(int id, string title, string description, 
            string sellerId, decimal startingPrice, DateTime endTime, List<Bid> bids)
        {
            Id = id;
            Title = title;
            Description = description;
            SellerId = sellerId;
            StartingPrice = startingPrice;
            EndTime = endTime;
            Bids = bids;
        }
    }
}
