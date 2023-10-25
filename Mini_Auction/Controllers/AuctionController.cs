using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Auction.Core;
using Mini_Auction.ViewModel;
using Mini_Auction.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Mini_Auction.Persistence;
using System.Collections.Generic;

namespace Mini_Auction.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: AuctionController
        public ActionResult ActiveAuctions()
        {
            _auctionService.UpdateAuctionStatus();
            List<AuctionVM> auctionVMs = new();
            List<Auction> auctions = _auctionService.GetAllAuctions();
            foreach (Auction auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }

            return View(auctionVMs);
        }

        //GET
        public ActionResult GetUserAuctions()
        {
            _auctionService.UpdateAuctionStatus();
            string userName = User.Identity.Name;
            List<AuctionVM> auctionVMs = new List<AuctionVM>();
            List<Auction> auctions = _auctionService.GetAllByUser(userName);

            if(auctionVMs.Count == 0) NotFound();

            foreach (Auction auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }

            return View("UserAuctions", auctionVMs); // Använd namnet på din nya vy här.
        }

        // GET: AuctionController/Details/5
        public ActionResult Details(int id)
        {
            AuctionVM auctionVm = AuctionVM.FromAuction(_auctionService.GetAuctionById(id));

            if (!auctionVm.SellerId.Equals(User.Identity.Name) && auctionVm.Status == 0 &&
                !_auctionService.CheckWinner(User.Identity.Name, id))
                return BadRequest();

            return View(auctionVm);
        }

        public ActionResult BiddenAuctions()
        {

            List<AuctionVM> auctionVMs = new();
            List<Auction> auctions = _auctionService.GetAllActiveBiddenAuctions(User.Identity.Name);

            if (auctionVMs.Count == 0) NotFound();

            foreach (Auction auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }

            return View(auctionVMs);
        }

        public ActionResult WinningAuctions()
        {
            List<AuctionVM> auctionVMs = new();
            List<Auction> auctions = _auctionService.GetClosedAuctionsWonByUser(User.Identity.Name);

            if (auctions.Count == 0)
            {
                TempData["Message"] = "Du har ingen vinnande auktioner.";
                return RedirectToAction("ActiveAuctions");
            }

            foreach (Auction auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }

            return View(auctionVMs);
        }

        // POST: AuctionController/Create

        [HttpPost]
        public ActionResult Create(AuctionVM auctionVM)
        {
            auctionVM.SellerId = User.Identity.Name;
            _auctionService.CreateAuction(Auction.FromAuctionVM(auctionVM));

            return RedirectToAction(nameof(ActiveAuctions));
        }

        // POST: AuctionController/PlaceBid
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceBid(BidVM b)
        {
            
            if (_auctionService.PlaceBid(Bid.FromBidVM(b)))
            {
                return RedirectToAction("Details", "Auction", new { id = b.AuctionId });
            }
            else
            {
                TempData["WarningMessage"] = "Du lagd lägre bud, vänligen lägg en högre bud!";
                return RedirectToAction("Details", "Auction", new { id = b.AuctionId });
            }
           
        }

        
        

        public ActionResult PlaceBid()
        {
            return View();
        }

        // GET: AuctionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: AuctionController/Edit/5
        public ActionResult EditDescr()
        {
            return View();
        }

        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDescr(AuctionVM auction)
        {
            auction.SellerId = User.Identity.Name;
            if (_auctionService.UpdateDescription(Auction.FromAuctionVM(auction)))
            {
                return RedirectToAction("Details", "Auction", new { id = auction.Id});
            }

            return RedirectToAction("Details", "Auction", new { id = auction.Id });
        }

    }
}
