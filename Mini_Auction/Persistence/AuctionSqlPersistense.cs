using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mini_Auction.Core;
using Mini_Auction.Persistence.Interfaces;
using Mini_Auction.ViewModel;

namespace Mini_Auction.Persistence
{
    public class AuctionSqlPersistense : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        //private IMapper _mapper;


        public AuctionSqlPersistense(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
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
                Status = (int)Status.Active
            };
            _dbContext.Add(auctionDb);
            _dbContext.SaveChanges();

            return true;
        }

        public List<Auction> GetAllActiveAuctions()
        {
            _dbContext.SaveChanges();
            var auctionDbs = _dbContext.Auctions.
                Where(a => a.Status.Equals(1))
                .OrderBy(a => a.EndTime)
                .ToList(); ;

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB aDB in auctionDbs)
            {
                Auction auction = new Auction(aDB.Id, aDB.Title, aDB.Description, aDB.userName, aDB.StartingPrice, aDB.EndTime, (Status)aDB.Status);
                result.Add(auction);
            }
            return result;
        }


        public List<Auction> GetAllActiveBiddenAuctions(string userName)
        {
            var now = DateTime.Now;

            var activeAuctions = _dbContext.Auctions
                .Where(a => a.Status == (int)Status.Active && a.Bids.Any(b => b.userName == userName))
                .OrderBy(a => a.EndTime)
                .ToList();

            List<Auction> result = new List<Auction>();

            foreach (var aDB in activeAuctions)
            {
                Auction auction = new Auction(aDB.Id, aDB.Title, aDB.Description, 
                        aDB.userName, aDB.StartingPrice, aDB.EndTime, (Status)aDB.Status);

                var bidsDbs = _dbContext.Bids
                    .Where(b => b.AuctionId == aDB.Id)
                    .ToList();

                foreach (var b in bidsDbs)
                {
                    auction.AddBids(new Bid(b.Id, b.AuctionId, b.userName, b.Amount, b.BidTime));
                }

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

        public void UpdateAuctionStatus()
        {
            var now = DateTime.Now;

            
            var endedAuctions = _dbContext.Auctions
                .Where(a => a.Status == (int)Status.Active && a.EndTime <= now)
                .ToList();

            foreach (var auction in endedAuctions)
            {
                auction.Status = (int)Status.Ended; 

                var winningBid = _dbContext.Bids
                    .Where(b => b.AuctionId == auction.Id)
                    .OrderByDescending(b => b.Amount)
                    .FirstOrDefault();

                if (winningBid != null)
                {
                    
                    var closedAuction = new ClosedAuctionDB
                    {
                        AuctionId = auction.Id,
                        WinningBidId = winningBid.Id
                    };

                    _dbContext.ClosedAuctionDBs.Add(closedAuction);
                }
            }

            _dbContext.SaveChanges();
        }

        public Auction GetAuctionById(int id)
        {
            var aDB = _dbContext.Auctions.Find(id);

            var bidsDbs = _dbContext.Bids.Where(b => b.AuctionId ==id).ToList();
            Auction auction= new Auction(aDB.Id, aDB.Title, aDB.Description, 
                            aDB.userName, aDB.StartingPrice, aDB.EndTime, (Status)aDB.Status);
            foreach(var b in bidsDbs)
            {
                auction.AddBids(new Bid(b.Id, b.AuctionId, b.userName, b.Amount, b.BidTime));
            }
            return auction;

        }

        public bool UpdateDescr(Auction auction)
        {
            var auctionDb = _dbContext.Auctions.Find(auction.Id);

            if (auctionDb == null)
            {
                return false;
            }

            if (auctionDb.userName != auction.UserName)
            {
                return false;
            }

            auctionDb.Description = auction.Description;
            _dbContext.SaveChanges();

            return true;
        }

        public bool CheckWinner(string userName, int id)
        {
            var closedAuction = _dbContext.ClosedAuctionDBs
        .Include(c => c.WinningBid)
        .Where(c => c.AuctionId == id)
        .FirstOrDefault();

            if (closedAuction != null)
            {
                
                if (closedAuction.WinningBid != null && closedAuction.WinningBid.userName == userName)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Auction> GetClosedAuctionsWonByUser(string username)
        {
            
            var closedAuctionsWonByUser = _dbContext.ClosedAuctionDBs
                .Where(ca => ca.WinningBid.userName == username)
                .ToList();

            List<Auction> closedAuctions = new List<Auction>();

            foreach (var closedAuction in closedAuctionsWonByUser)
            {
                var auction = _dbContext.Auctions.Find(closedAuction.AuctionId);

                if (auction != null)
                {
                    
                    Auction c = new Auction(
                        auction.Id,
                        auction.Title,
                        auction.Description,
                        auction.userName,
                        auction.StartingPrice,
                        auction.EndTime,
                        (Status)auction.Status
                    );

                    closedAuctions.Add(c);
                }
            }

            return closedAuctions;
        }

        public bool PlaceBid(Bid bid)
        {
            var newBid = new BidDB
            {
                AuctionId = bid.AuctionId, 
                userName = bid.BidderId,
                Amount = bid.Amount,
                BidTime =bid.BidTime,
            };
            _dbContext.Bids.Add(newBid);
            _dbContext.SaveChanges();
            return true;
        }

        public bool CanPlaceBid(Bid bid)
        {
            var auctionDb = _dbContext.Auctions.Find(bid.AuctionId);

            if (auctionDb == null)
            {
                return false;
            }
            
            if (auctionDb.Status == (int)Status.Active && !auctionDb.userName.Equals(bid.BidderId))
            {
                var highestBid = auctionDb.Bids.Max(b => (double?)b.Amount);
                var startingPrice = (double?) auctionDb.StartingPrice;
                if (bid.Amount > startingPrice && highestBid == null)
                {
                    return true;
                }

                if (highestBid != null && bid.Amount > highestBid)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
