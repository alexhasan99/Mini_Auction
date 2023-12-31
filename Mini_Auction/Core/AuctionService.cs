﻿using Mini_Auction.Core.Interfaces;
using Mini_Auction.Persistence.Interfaces;
using System.Globalization;

namespace Mini_Auction.Core
{
    public class AuctionService : IAuctionService
    {

        private IAuctionPersistence _auctionPersistence;

        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }

        public bool AddAuction(Auction a)
        {
            throw new NotImplementedException();
        }

        public List<Auction> GetAllByUser(string username)
        {
            return _auctionPersistence.GetAllByUsername(username);
        }


        public bool CreateAuction(Auction auction)
        {
            
            return _auctionPersistence.CreateAuction(auction);
        }

        public void UpdateAuctionStatus()
        {
            _auctionPersistence.UpdateAuctionStatus();
        }

        public Auction GetAuctionById(int id)
        {
            return _auctionPersistence.GetAuctionById(id);
        }

        public List<Auction> GetAllAuctions()
        {
            return _auctionPersistence.GetAllActiveAuctions();
        }

        public bool UpdateDescription(Auction auction)
        {
            return _auctionPersistence.UpdateDescr(auction);
        }

        public bool PlaceBid(Bid bid)
        {
            if (!_auctionPersistence.CanPlaceBid(bid))
            {
                return false;
            }
            _auctionPersistence.PlaceBid(bid);
            return true;
        }

        public List<Auction> GetAllActiveBiddenAuctions(string userName)
        {
            return _auctionPersistence.GetAllActiveBiddenAuctions(userName);
        }


        public List<Auction> GetClosedAuctionsWonByUser(string username)
        {
            return _auctionPersistence.GetClosedAuctionsWonByUser(username);
        }

        public bool CheckWinner(string userName, int id)
        {
            return _auctionPersistence.CheckWinner(userName, id);
        }

    }
}
