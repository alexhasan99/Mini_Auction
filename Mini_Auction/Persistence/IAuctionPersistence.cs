using Mini_Auction.Core;

namespace Mini_Auction.Persistence
{
    public interface IAuctionPersistence
    {
        public List<Auction> GetAllByUsername(string username);

        public bool CreateAuction(Auction auction);

        public Auction GetAuctionById(int id);

        public List<Auction> GetAllActiveAuctions();

        public bool CanPlaceBid(Bid bid);

        public bool PlaceBid(Bid bid);

    }
}
