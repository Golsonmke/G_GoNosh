using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Go_Nosh.Models;
using Go_Nosh.Data;
using Go_Nosh.Contracts;

namespace Go_Nosh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IGoogleMapService _googleMapService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IGoogleMapService googleMapService)
        {
            _logger = logger;
            _context = context;
            _googleMapService = googleMapService;
        }

        public async Task<IActionResult> Index()
        {
            FoodTruckAPI foodTruckAPI = await _googleMapService.GetFoodTrucks();
            return View(foodTruckAPI);

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
