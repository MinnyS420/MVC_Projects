using Microsoft.EntityFrameworkCore;
using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Mappers;
using SEDC.BurgerApp.Mappers.Extensions;
using SEDC.BurgerApp.Services.Abstractions;
using SEDC.BurgerApp.ViewModels.OrderViewModels;

namespace SEDC.BurgerApp.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepo;
        private IRepository<Location> _locationRepo;
        private IBurgerRepository _burgerRepo;

        public OrderService(IRepository<Order> orderRepo,
                            IRepository<Location> locationRepo,
                            IBurgerRepository burgerRepo)
        {
            _orderRepo = orderRepo;
            _locationRepo = locationRepo;
            _burgerRepo = burgerRepo;
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            List<Order> dbOrders = _orderRepo.GetAll();
            return dbOrders.Select(order => order.MapToOrderDetailsViewModel()).ToList();
        }
        public Order GetOrderById(int id)
        {
            Order orderDb = _orderRepo.GetById(id);

            if (orderDb == null)
            {
                throw new ArgumentException($"Order with ID {id} not found.");
            }

            return orderDb;
        }
        public void AddBurgerToOrder(BurgerOrderViewModel burgerOrderViewModel)
        {
            var burgerDb = _burgerRepo.GetById(burgerOrderViewModel.BurgerId);
            if (burgerDb == null)
            {
                throw new Exception($"Burger with id {burgerOrderViewModel.BurgerId} was not found");
            }

            var orderDb = _orderRepo.GetById(burgerOrderViewModel.OrderId);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {burgerOrderViewModel.OrderId} was not found");
            }

            var burgerOrder = new BurgerOrder
            {
                Burger = burgerDb,
                BurgerId = burgerDb.Id,
                Order = orderDb,
                OrderId = orderDb.Id
            };

            orderDb.BurgerOrders.Add(burgerOrder);

            _orderRepo.Update(orderDb);
        }
        public void CreateOrder(OrderViewModel orderListViewModel)
        {
            Location locationDb = _locationRepo.GetById(orderListViewModel.LocationId);

            if (locationDb == null)
            {
                throw new Exception($"Order with id {orderListViewModel.LocationId} was not found!");
            }

            Order order = orderListViewModel.MapToCreateOrder();
            order.Location = locationDb;

            int newOrderId = _orderRepo.Insert(order);
            if (newOrderId <= 0)
            {
                throw new Exception("An error occurred while saving to the database!");
            }

        }
        public void EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = _orderRepo.GetById(orderViewModel.Id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {orderViewModel.Id} was not found!");
            }

            Location locationDb = _locationRepo.GetById(orderViewModel.LocationId);
            if (locationDb == null)
            {
                throw new Exception($"The location with id {orderViewModel.LocationId} was not found!");
            }

            orderViewModel.MapToOrder(orderDb, locationDb);
            _orderRepo.Update(orderDb);
        }
        public OrderDetailsViewModel GetOrderForEditing(int id)
        {
            Order orderDb = _orderRepo.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            return orderDb.MapToOrderDetailsViewModel();
        }
        public void DeleteOrder(int id)
        {
            Order orderDb = _orderRepo.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            _orderRepo.DeleteById(id);
        }
        public void DeleteBurgerFromOrder(int orderId, int burgerIndex)
        {
            Order orderDb = _orderRepo.GetById(orderId);

            if (orderDb == null)
            {
                throw new Exception($"The order with id {orderId} was not found!");
            }

            if (burgerIndex < 0 || burgerIndex >= orderDb.BurgerOrders.Count)
            {
                throw new Exception($"Invalid burger index: {burgerIndex}");
            }

            orderDb.BurgerOrders.RemoveAt(burgerIndex);

            _orderRepo.Update(orderDb);
        }

        public OrderDetailsViewModel GetOrderDetails(int id)
        {
            Order orderDb = _orderRepo.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            return orderDb.MapToOrderDetailsViewModel();
        }
        public decimal GetAverageOrderPrice()
        {
            var orders = _orderRepo.GetAll(); // Fetch all orders from the repository

            if (orders.Count == 0)
            {
                return 0;
            }

            decimal totalOrderPrice = (decimal)orders.Sum(order => order.BurgerOrders.Sum(burgerOrder => burgerOrder.Burger.Price));
            decimal averagePrice = totalOrderPrice / orders.Count;

            return averagePrice;
        }
        public string GetMostOrderedBurger()
        {
            List<Order> orders = _orderRepo.GetAll();
            var groupedBurgers = orders
                .SelectMany(order => order.BurgerOrders)
                .GroupBy(bo => bo.Burger.Name)
                .OrderByDescending(group => group.Count());

            string mostOrderedBurger = groupedBurgers.FirstOrDefault()?.Key ?? "No burgers";
            return mostOrderedBurger;
        }
        public string GetMostOrderedBurgerImageName()
        {
            List<Order> orders = _orderRepo.GetAll();
            var groupedBurgers = orders
                .SelectMany(order => order.BurgerOrders)
                .GroupBy(bo => bo.Burger.Name)
                .OrderByDescending(group => group.Count());

            string mostOrderedBurgerImageName = groupedBurgers.FirstOrDefault()?.FirstOrDefault()?.Burger?.Name.Replace(" ", "")?.ToLower();
            return mostOrderedBurgerImageName;
        }
    }
}