using Mini_Auction.Core;

namespace Mini_Auction.Persistence
{
    public interface IAuctionPersistence
    {
        public List<Auction> GetAllByUsername(string username);

    }
}
