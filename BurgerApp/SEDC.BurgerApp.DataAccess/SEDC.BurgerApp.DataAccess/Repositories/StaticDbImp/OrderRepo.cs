using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;
using System;

namespace SEDC.BurgerApp.DataAccess.Repositories.StaticDbImp
{
    public class OrderRepo : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            Order order = StaticDb.Orders.FirstOrDefault(order => order.Id == id);
            StaticDb.Orders.Remove(order);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders
                .FirstOrDefault(order => order.Id == id);
        }

        public int Insert(Order entity)
        {
            entity.Id = ++StaticDb.OrderId;
            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order order = StaticDb.Orders.FirstOrDefault(order => order.Id == entity.Id);
            if (order == null)
            {
                throw new Exception($"Order with id {entity.Id} was not found");
            }
            int index = StaticDb.Orders.IndexOf(order);
            StaticDb.Orders[index] = entity;
        }

    }
}
