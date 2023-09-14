using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.OrderViewModels;
using System.Net;

namespace SEDC.BurgerApp.Mappers.Extensions
{
    public static class OrderMapper
    {
        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                IsDelivered = order.IsDelivered,
                FullName = order.FullName,
                Address = order.Location.Address,
                BurgerNames = order.BurgerOrders.Select(bo => bo.Burger.Name).ToList()
            };
        }
        public static OrderDetailsViewModel MapToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                LocationId = order.LocationId,
                LocationName = order.Location.Name,
                LocationAddress = order.Location.Address,
                Address = order.Address,
                IsDelivered = order.IsDelivered,
                BurgerNames = order.BurgerOrders?.Select(bo => bo.Burger.Name).ToList() ?? new List<string>()
            };
        }
        //public static OrderDetailsViewModel MapToOrderDetailsViewModel(this Order order)
        //{
        //    if (order == null)
        //    {
        //        throw new ArgumentNullException(nameof(order), "Order cannot be null");
        //    }

        //    var viewModel = new OrderDetailsViewModel
        //    {
        //        Id = order.Id,
        //        FullName = order.FullName,
        //        IsDelivered = order.IsDelivered,
        //        Address = order.Address,
        //        LocationId = order.LocationId,
        //        BurgerNames = new List<string>()
        //    };

        //    if (order.Location != null)
        //    {
        //        viewModel.LocationName = order.Location.Name;
        //        viewModel.LocationAddress = order.Location.Address;
        //    }

        //    if (order.BurgerOrders != null)
        //    {
        //        viewModel.BurgerNames = order.BurgerOrders.Select(bo => bo.Burger?.Name).ToList() ?? new List<string>();
        //    }

        //    return viewModel;
        //}

        public static OrderViewModel MapToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Location = order.Location,
                IsDelivered = order.IsDelivered,
                LocationId = order.LocationId
            };
        }
        public static void MapToOrder(this OrderViewModel orderViewModel, Order order,Location location)
        {
            order.FullName = orderViewModel.FullName;
            order.Address = orderViewModel.Address;
            order.IsDelivered = orderViewModel.IsDelivered;
            order.Location = location;

        }
        public static Order MapToCreateOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                FullName = orderViewModel.FullName,
                Address = orderViewModel.Address,
                Location = orderViewModel.Location,
                LocationId = orderViewModel.LocationId,
                IsDelivered = orderViewModel.IsDelivered,
                BurgerOrders = new List<BurgerOrder>(),
            };
        }
    }
}