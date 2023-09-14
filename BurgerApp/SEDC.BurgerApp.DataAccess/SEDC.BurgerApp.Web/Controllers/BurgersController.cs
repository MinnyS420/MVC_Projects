using Microsoft.AspNetCore.Mvc;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Mappers.Extensions;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.BurgerViewModels;

namespace SEDC.BurgerApp.Web.Controllers
{
    public class BurgersController : Controller
    {
        private readonly IBurgerService _burgerService;
        private readonly IBurgerRepository _burgerRepo;

        public BurgersController(IBurgerService burgerService,
                                 IBurgerRepository burgerRepo)
        {
            _burgerService = burgerService;
            _burgerRepo = burgerRepo;
        }

        public IActionResult Index()
        {
            var burgers = _burgerService.GetAllBurgers();
            return View(burgers);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Get the burger by its ID from the service
            var burgerViewModel = _burgerService.GetBurgerById(id);

            // Check if the burger exists
            if (burgerViewModel == null)
            {
                return NotFound(); // Return a 404 Not Found view if the burger is not found
            }

            // Map the view model to the Burger model
            var burger = BurgerMapper.MapToBurger(burgerViewModel);

            // Map the burger to the BurgerEditViewModel to populate the edit form
            var model = BurgerMapper.MapToEditViewModel(burger);

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BurgerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Call the service method to update the burger
                    _burgerService.UpdateBurger(model);

                    // Redirect to the "Burger Menu" view after successful update
                    return RedirectToAction("Index", "Burgers");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the update process
                    // You can also display an error message or log the error here
                    return View("Error");
                }
            }

            // If the model state is not valid or there was an exception, return the view with the model to display errors
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            // Create a new instance of the BurgerCreateViewModel to populate the form
            var model = new BurgerCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BurgerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Map the view model to the domain model and add the new burger
                    _burgerService.AddBurger(model);

                    // Redirect to the "Burger Menu" view after successful addition
                    return RedirectToAction("Index", "Burgers");
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the creation process
                    ModelState.AddModelError("", "An error occurred while adding the burger. Please try again later.");
                }
            }

            // If the model state is not valid or there was an exception, return the view with the model to display errors
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                // Call the service method to delete the burger by its ID
                _burgerService.DeleteBurger(id);

                // Redirect to the "Burger Menu" view after successful deletion
                return RedirectToAction("Index", "Burgers");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the deletion process
                // You can also display an error message or log the error here
                return View("Error");
            }
        }
    }
}
