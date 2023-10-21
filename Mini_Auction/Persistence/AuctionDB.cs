using Mini_Auction.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Auction.Persistence
{
    public class AuctionDB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        
        public string userName { get; set; }

        [Required]
        public double StartingPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        public Status Status { get; set; }

        public IEnumerable<BidDB> Bids { get; set; } = new List<BidDB>();
    }
}