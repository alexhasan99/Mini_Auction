using Mini_Auction.Core;

namespace Mini_Auction.Persistence.Interfaces
{
    public interface IAuctionPersistence
    {
        public List<Auction> GetAllByUsername(string username);

        public bool CreateAuction(Auction auction);

        public Auction GetAuctionById(int id);

        public List<Auction> GetAllActiveAuctions();

        public bool CanPlaceBid(Bid bid);

        public bool PlaceBid(Bid bid);

        public void UpdateAuctionStatus();

        public bool UpdateDescr(Auction auction);

        public List<Auction> GetAllActiveBiddenAuctions(string userName);

        public List<Auction> GetClosedAuctionsWonByUser(string username);

    }
}
