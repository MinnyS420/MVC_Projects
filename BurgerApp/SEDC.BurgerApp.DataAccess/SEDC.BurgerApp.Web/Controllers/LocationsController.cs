using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.Mappers;
using SEDC.BurgerApp.Services;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.BurgerViewModels;
using SEDC.BurgerApp.ViewModels.LocationViewModels;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;


        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;

        }
        public IActionResult Index()
        {
            var locations = _locationService.GetAllLocations();
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new LocationViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _locationService.AddLocation(model);

                    return RedirectToAction("Index", "Locations");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while adding the burger. Please try again later.");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var locationViewModel = _locationService.GetLocationById(id);
            if (locationViewModel == null)
            {
                return NotFound();
            }

            return View(locationViewModel);
        }

        [HttpPost]
        public IActionResult Edit(LocationViewModel model) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _locationService.UpdateLocation(model);
                    return RedirectToAction("Index", "Locations");
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _locationService.DeleteLocation(id);

                return RedirectToAction("Index", "Locations");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


    }
}