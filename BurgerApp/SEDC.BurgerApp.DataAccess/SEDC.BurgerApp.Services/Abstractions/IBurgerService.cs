using SEDC.BurgerApp.ViewModels.BurgerViewModels;
using SEDC.BurgerApp.ViewModels.HomeViewModels;

namespace SEDC.BurgerApp.Services.Abstractions
{
    public interface IBurgerService
    {
        List<BurgerIndexViewModel> GetBurgersFromDropdown();
        List<BurgerIndexViewModel> GetAllBurgers();
        BurgerCreateViewModel GetBurgerById(int id);
        string GetMostOrderedBurger();
        void AddBurger(BurgerCreateViewModel burgerViewModel);
        void UpdateBurger(BurgerEditViewModel model);
        void DeleteBurger(int id);
    }
}
