using AutoMapper;
using Mini_Auction.Core;

namespace Mini_Auction.Persistence
{
    public class AuctionSqlPersistense : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        //private IMapper _mapper;


        public AuctionSqlPersistense(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
            //_mapper = mapper;
        }


        public List<Auction> GetAllByUsername(string username)
        {
            
            var auctionDbs=  _dbContext.Auctions.
                Where(a => a.userName.Equals(username)).ToList();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDB aDB in auctionDbs) {
                Auction auction = new Auction(aDB.Id,aDB.Title,aDB.Description,aDB.userName,aDB.StartingPrice,aDB.EndTime,aDB.Status);
                result.Add(auction);
            }
            return result;
        }
    }
}
