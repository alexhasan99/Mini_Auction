using Mini_Auction.ViewModel;


namespace Mini_Auction.Core
{
    public class Auction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }
       
        public double StartingPrice { get; set; }

        public DateTime EndTime { get; set; }

        public Status Status { get; set; }

        public List<Bid> Bids { get; set; }

        public Auction(int id, string title, string description, 
            string userName, double startingPrice, DateTime endTime, Status status)
        {
            Id = id;
            Title = title;
            Description = description;
            UserName = userName;
            StartingPrice = startingPrice;
            EndTime = endTime;
            Bids = new List<Bid>();
            Status = status;    
        }

        public bool AddBids(Bid b){

            Bids.Add(b);
            if (Bids.Contains(b))
            {
                return true;
            }
            return false;
        }

        public bool RemoveBids(Bid b) {

            Bids.Remove(b);
            
            if (Bids.Contains(b)) { 
                return false;
            }
            return true;
        }

        public static Auction FromAuctionVM(AuctionVM auctionVM)
        {
            return new Auction(auctionVM.Id,auctionVM.Title,auctionVM.Description,
                auctionVM.SellerId,auctionVM.StartingPrice, auctionVM.EndTime, auctionVM.Status);
        }


    }
}
