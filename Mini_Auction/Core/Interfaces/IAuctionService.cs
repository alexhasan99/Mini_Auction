namespace Mini_Auction.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAllAuctions();

        bool AddAuction(Auction a);
    }
}
