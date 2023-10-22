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
    }
}
