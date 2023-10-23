namespace Mini_Auction.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAllByUser(string username);

        bool AddAuction(Auction a);

        public bool CreateAuction(Auction auction);

        public Auction GetAuctionById(int id);

        List<Auction> GetAllAuctions();

        public bool PlaceBid(Bid bid);

        public void UpdateAuctionStatus();

        public bool UpdateDescription(Auction auction);

        public List<Auction> GetAllActiveBiddenAuctions(string userName);

        public List<Auction> GetClosedAuctionsWonByUser(string username);

        public bool CheckWinner(string userName, int id);

    }
}
