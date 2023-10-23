using Microsoft.AspNetCore.Mvc;
using Mini_Auction.Core.Interfaces;
using Mini_Auction.Models;
using System.Diagnostics;

namespace Mini_Auction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAuctionService _auctionService;

        public HomeController(ILogger<HomeController> logger, IAuctionService auctionService)
        {
            _logger = logger;
            _auctionService = auctionService;
        }

        public IActionResult Index()
        {
            _auctionService.UpdateAuctionStatus();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}