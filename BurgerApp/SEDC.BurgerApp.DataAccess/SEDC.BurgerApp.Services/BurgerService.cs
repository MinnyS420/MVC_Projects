using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers.Extensions;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.BurgerViewModels;

namespace SEDC.BurgerApp.Services
{
    public class BurgerService : IBurgerService
    {

        private IBurgerRepository _burgerRepo;

        public BurgerService(IBurgerRepository burgerRepo)
        {
            _burgerRepo = burgerRepo;
        }

        public List<BurgerIndexViewModel> GetBurgersFromDropdown()
        {
            List<Burger> burgersDb = _burgerRepo.GetAll();
            return burgersDb.Select(b => b.MapToViewModel()).ToList();
        }

        public List<BurgerIndexViewModel> GetAllBurgers()
        {
            List<Burger> burgersDb = _burgerRepo.GetAll();
            return burgersDb.Select(b => b.MapToViewModel()).ToList();
        }

        public string GetMostOrderedBurger()
        {
            // Get all orders from the StaticDb
            List<Order> allOrders = StaticDb.Orders;

            // Group the burger orders by burger ID and count the occurrences
            var orderedBurgers = allOrders
                .SelectMany(order => order.BurgerOrders)
                .GroupBy(burgerOrder => burgerOrder.BurgerId)
                .Select(group => new
                {
                    BurgerId = group.Key,
                    OrderCount = group.Count()
                })
                .OrderByDescending(group => group.OrderCount)
                .FirstOrDefault();

            if (orderedBurgers == null)
            {
                return ("No information available");
            }

            // Get the most ordered burger from the StaticDb by its ID
            var mostOrderedBurger = StaticDb.Burgers.FirstOrDefault(burger => burger.Id == orderedBurgers.BurgerId);
            if (mostOrderedBurger == null)
            {
                return ("No information available");
            }

            return (mostOrderedBurger.Name /*mostOrderedBurger.ImageName*/);
        }
        public BurgerCreateViewModel GetBurgerById(int id)
        {
            var burger = _burgerRepo.GetById(id);
            if (burger == null)
            {
                return null;
            }

            // Map the domain model to the view model and return it
            return burger.MapToCreateViewModel();
        }
        public void AddBurger(BurgerCreateViewModel burgerViewModel)
        {
            try
            {
                // Map the view model to the Burger entity
                Burger newBurger = burgerViewModel.MapToBurger();

                // Add the new burger to the database using the Insert method from the repository
                _burgerRepo.Insert(newBurger);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or display an error message)
                throw new Exception("An error occurred while adding the burger.", ex);
            }
        }
        public void UpdateBurger(BurgerEditViewModel model)
        {
            var existingBurger = _burgerRepo.GetById(model.Id);
            if (existingBurger == null)
            {
                throw new ArgumentException($"Burger with ID {model.Id} not found");
            }

            // Update the properties of the existing burger with the values from the view model
            existingBurger.Name = model.Name;
            existingBurger.Price = model.Price;
            existingBurger.IsVegan = model.IsVegan;
            existingBurger.IsVegetarian = model.IsVegetarian;
            existingBurger.HasFries = model.HasFries;

            // Call the repository method to update the burger
            _burgerRepo.Update(existingBurger);
        }

        public void DeleteBurger(int id)
        {
            _burgerRepo.DeleteById(id);
        }
    }
}