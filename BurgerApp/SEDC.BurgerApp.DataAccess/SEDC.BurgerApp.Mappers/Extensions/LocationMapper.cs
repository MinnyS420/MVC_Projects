using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.LocationViewModels;

namespace SEDC.BurgerApp.Mappers
{
    public static class LocationMapper
    {
        public static LocationViewModel MapToViewModel(this Location location)
        {
            return new LocationViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                OpensAt = location.OpensAt,
                ClosesAt = location.ClosesAt
            };
        }

        public static Location MapToLocation(this LocationViewModel locationViewModel)
        {
            return new Location
            {
                Name = locationViewModel.Name,
                Address = locationViewModel.Address,
                OpensAt = locationViewModel.OpensAt,
                ClosesAt = locationViewModel.ClosesAt
            };
        }
    }
}
