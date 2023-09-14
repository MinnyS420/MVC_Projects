using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.OrderViewModels;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILocationService _locationService;
        private readonly IBurgerService _burgerService;

        public OrderController(IOrderService orderService, ILocationService locationService, IBurgerService burgerService)
        {
            _orderService = orderService;
            _locationService = locationService;
            _burgerService = burgerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<OrderDetailsViewModel> orderListViewModels = _orderService.GetAllOrders();
            return View(orderListViewModels);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id);
                return View(orderDetailsViewModel);
            }
            catch (Exception e)
            {
                return View("ExceptionPage");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Location = _locationService.GetAllLocations();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionPage");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderDetailsViewModel model = _orderService.GetOrderForEditing(id);
                ViewBag.Locations = _locationService.GetAllLocations();

                return View(model);
            }
            catch (Exception e)
            {
                return View("ResourceNotFound");
            }
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.EditOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ResourceNotFound");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var order = _orderService.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            try
            {
                _orderService.DeleteOrder(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult AddBurger(int id)
        {
            BurgerOrderViewModel burgerOrderViewModel = new BurgerOrderViewModel();
            burgerOrderViewModel.OrderId = id;
            ViewBag.Burgers = _burgerService.GetAllBurgers();
            return View(burgerOrderViewModel);
        }

        [HttpPost]
        public IActionResult AddBurger(BurgerOrderViewModel burgerOrderViewModel)
        {
            try
            {
                _orderService.AddBurgerToOrder(burgerOrderViewModel);
                return RedirectToAction("Details", new { id = burgerOrderViewModel.OrderId });
            }
            catch (Exception e)
            {
                return View("ExceptionPage");
            }
        }
        [HttpPost]
        public IActionResult DeleteBurger(int orderId, int burgerIndex)
        {
            try
            {
                _orderService.DeleteBurgerFromOrder(orderId, burgerIndex);
                return RedirectToAction("Details", new { id = orderId });
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}
