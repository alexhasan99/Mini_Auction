namespace Mini_Auction.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAllByUser(string username);

        bool AddAuction(Auction a);
    }
}
