using SEDC.BurgerApp.ViewModels.LocationViewModels;

namespace SEDC.BurgerApp.Services.Abstractions
{
    public interface ILocationService
    {
        List<LocationViewModel> GetAllLocations();
        LocationViewModel GetLocationById(int id);
        void AddLocation(LocationViewModel model);
        void UpdateLocation(LocationViewModel model);
        void DeleteLocation(int id);
    }
}
