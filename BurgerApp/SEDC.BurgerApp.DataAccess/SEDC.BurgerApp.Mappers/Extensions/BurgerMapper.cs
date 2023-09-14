using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.BurgerViewModels;

namespace SEDC.BurgerApp.Mappers.Extensions
{
    public static class BurgerMapper
    {
        public static BurgerIndexViewModel MapToViewModel(this Burger burger)
        {
            return new BurgerIndexViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                HasFries = burger.HasFries,
                //Image = $"/images/burgers/{burger.ImageName}"
            };
        }
        public static Burger MapToBurger(this BurgerCreateViewModel burgerViewModel)
        {
            return new Burger
            {
                Id = burgerViewModel.Id,
                Name = burgerViewModel.Name,
                Price = burgerViewModel.Price,
                IsVegan = burgerViewModel.IsVegan,
                IsVegetarian = burgerViewModel.IsVegetarian,
                HasFries = burgerViewModel.HasFries
            };
        }
        public static BurgerEditViewModel MapToEditViewModel(Burger burger)
        {
            return new BurgerEditViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                HasFries = burger.HasFries
            };
        }
        public static BurgerCreateViewModel MapToCreateViewModel(this Burger burger)
        {
            return new BurgerCreateViewModel
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsVegan = burger.IsVegan,
                IsVegetarian = burger.IsVegetarian,
                HasFries = burger.HasFries
            };
        }
    }
}
