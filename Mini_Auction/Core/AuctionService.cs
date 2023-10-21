﻿using Mini_Auction.Core.Interfaces;
using Mini_Auction.Persistence;
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
            Console.WriteLine(username);
            return _auctionPersistence.GetAllByUsername(username);

        }
        
    }
}
