using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.HomeViewModels;
using SEDC.BurgerApp.Web.Models;
using System.Diagnostics;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBurgerService _burgerService;
        private IOrderService _orderService;
        private ILocationService _locationService;

        public HomeController(ILogger<HomeController> logger,
                              IBurgerService burgerService,
                              IOrderService orderService,
                              ILocationService locationService)
        {
            _logger = logger;
            _burgerService = burgerService;
            _orderService = orderService;
            _locationService = locationService;
        }

        // HomeController.cs

        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
            homeIndexViewModel.OrderCount = _orderService.GetAllOrders().Count;
            homeIndexViewModel.Locations = _locationService.GetAllLocations();

            homeIndexViewModel.AverageOrderPrice = _orderService.GetAverageOrderPrice();
            homeIndexViewModel.MostOrderedBurger = _orderService.GetMostOrderedBurger();
            homeIndexViewModel.MostOrderedBurgerImageName = _orderService.GetMostOrderedBurgerImageName();

            return View(homeIndexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
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