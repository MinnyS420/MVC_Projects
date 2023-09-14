using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.DataAccess.Repositories.StaticDbImp;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.LocationViewModels;

namespace SEDC.BurgerApp.Services
{
    public class LocationService : ILocationService
    {

        private readonly IRepository<Location> _locationRepo;

        public LocationService(IRepository<Location> locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public List<LocationViewModel> GetAllLocations()
        {
            List<Location> locationsDb = _locationRepo.GetAll();
            return locationsDb.Select(b => b.MapToViewModel()).ToList();
        }

        public LocationViewModel GetLocationById(int id)
        {
            Location location = _locationRepo.GetById(id);
            if (location == null)
            {
                return null;
            }

            // Map the domain model to the view model and return it
            return location.MapToViewModel();
        }

        public void AddLocation(LocationViewModel model)
        {
            try
            {
                Location newLocation = LocationMapper.MapToLocation(model);

                _locationRepo.Insert(newLocation);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the burger.", ex);
            }
        }

        public void UpdateLocation(LocationViewModel model)
        {
            var existingLocation = _locationRepo.GetById(model.Id);
            if (existingLocation == null)
            {
                throw new ArgumentException($"Burger with ID {model.Id} not found");
            }

            existingLocation.Name = model.Name;
            existingLocation.Address = model.Address;
            existingLocation.OpensAt = model.OpensAt;
            existingLocation.ClosesAt = model.ClosesAt;

            _locationRepo.Update(existingLocation);
        }

        public void DeleteLocation(int id)
        {
            _locationRepo.DeleteById(id);
        }
    }
}