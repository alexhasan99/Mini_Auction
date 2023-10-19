using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Auction.Core;
using Mini_Auction.ViewModel;
using Mini_Auction.Core.Interfaces;

namespace Mini_Auction.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        // GET: AuctionController
        public ActionResult Index()
        {
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in _auctionService.GetAllAuctions())
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }

            return View(auctionVMs);
        }

        // POST: AuctionController/Create
        [HttpPost]
        public ActionResult Create(AuctionVM auctionVM)
        {
            _auctionService.AddAuction(Auction.FromAuctionVM(auctionVM));

            return RedirectToAction(nameof(Index));
        }

        // GET: AuctionController/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuctionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: AuctionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuctionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuctionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuctionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
