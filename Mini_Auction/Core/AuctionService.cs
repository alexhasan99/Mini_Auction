using Mini_Auction.Core.Interfaces;
using System.Globalization;

namespace Mini_Auction.Core
{
    public class AuctionService : IAuctionService
    {
        List<Auction> l = new List<Auction>();
        public List<Auction> GetAllAuctions()
        {
            string dateStr = "2023-10-18 15:30:00";
            DateTime parsedDateTime = DateTime.ParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Auction a1 = new Auction(1, "Playstation 5", "Konsol", "mohhas", 1999, parsedDateTime, Status.Active);

            l.Add(a1);
            return l;
        }

        public bool AddAuction(Auction a)
        {
            if (a == null)
            {
                return false;
            }
            l.Add((Auction)a);
            return true;
        }
    }
}
