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

        public bool CreateAuction(Auction auction)
        {

            AuctionDB auctionDb = new AuctionDB
            {
                Title = auction.Title,
                Description = auction.Description,
                userName = auction.UserName,
                StartingPrice = auction.StartingPrice,
                EndTime = auction.EndTime,
                Status = (int)auction.Status 
            };

            Console.WriteLine(auctionDb.Title + " " + auctionDb.Description);
            _dbContext.Auctions.Add(auctionDb);

            _dbContext.SaveChanges();

            return true;
        }

        public List<Auction> GetAllActiveAuctions()
        {
            _dbContext.SaveChanges();
            var auctionDbs = _dbContext.Auctions.
                Where(a => a.Status.Equals(1)).ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB aDB in auctionDbs)
            {
                Auction auction = new Auction(aDB.Id, aDB.Title, aDB.Description, aDB.userName, aDB.StartingPrice, aDB.EndTime, (Status)aDB.Status);
                result.Add(auction);
            }
            return result;
        }

        public List<Auction> GetAllByUsername(string username)
        {

            _dbContext.SaveChanges();
            var auctionDbs=  _dbContext.Auctions.
                Where(a => a.userName.Equals(username)).ToList();

            List<Auction> result = new List<Auction>();
            foreach(AuctionDB aDB in auctionDbs) {
                Auction auction = new Auction(aDB.Id, aDB.Title, aDB.Description, aDB.userName, aDB.StartingPrice, aDB.EndTime, (Status)aDB.Status);
                result.Add(auction);
            }
            return result;
        }

        public Auction GetAuctionById(int id)
        {
            Console.WriteLine(id);
            var aDB = _dbContext.Auctions.Find(id);

            return new Auction(aDB.Id, aDB.Title, aDB.Description, aDB.userName, aDB.StartingPrice, aDB.EndTime, (Status)aDB.Status);
        }
    }
}
