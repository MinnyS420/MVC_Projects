using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.OrderViewModels;

namespace SEDC.BurgerApp.Services.Abstractions
{
    public interface IOrderService
    {
        List<OrderDetailsViewModel> GetAllOrders();
        Order GetOrderById(int id);
        OrderDetailsViewModel GetOrderDetails(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        void EditOrder(OrderViewModel orderViewModel);
        OrderDetailsViewModel GetOrderForEditing(int id);
        void DeleteOrder(int id);
        void DeleteBurgerFromOrder(int orderId, int burgerIndex);
        void AddBurgerToOrder(BurgerOrderViewModel burgerOrderViewModel);
        decimal GetAverageOrderPrice();
        string GetMostOrderedBurger();
        string GetMostOrderedBurgerImageName();
    }
}