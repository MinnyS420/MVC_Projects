using SEDC.BurgerApp.Domain.Models;
using System;

namespace SEDC.BurgerApp.DataAccess.Data
{
    public static class StaticDb
    {
        public static int BurgerId { get; set; }
        public static int OrderId { get; set; }
        public static int LocationId { get; set; }
        public static List<Burger> Burgers { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<Location>? Locations { get; set; }

        static StaticDb()
        {
            BurgerId = 10;
            OrderId = 3;
            LocationId = 3;

            Burgers = new List<Burger>
            {
                new Burger
                {
                    Id = 1,
                    Name = "Chicken Burger",
                    Price = 2,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = false,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 2,
                    Name = "Ham Burger",
                    Price = 3,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 3,
                    Name = "Veggie Burger",
                    Price = 2,
                    IsVegan = false,
                    IsVegetarian = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 4,
                    Name = "Cheeseburger",
                    Price = 3.5,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 5,
                    Name = "Double Cheeseburger",
                    Price = 5.0,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 6,
                    Name = "Bacon Burger",
                    Price = 4.5,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 7,
                    Name = "Fish Burger",
                    Price = 3.8,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 8,
                    Name = "Mushroom Burger",
                    Price = 3.2,
                    IsVegan = true,
                    IsVegetarian = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 9,
                    Name = "BBQ Burger",
                    Price = 4.0,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                },
                new Burger
                {
                    Id = 10,
                    Name = "Vegan Burger",
                    Price = 3.5,
                    IsVegan = true,
                    IsVegetarian = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> {}
                }
            };

            Locations = new List<Location>
            {
                new Location
                {
                    Id = 1,
                    Name = "Tehno Burgeri",
                    Address = "Skopje",
                    OpensAt = new TimeSpan(07,00,00),
                    ClosesAt = new TimeSpan(22,00,00),
                },
                new Location
                {
                    Id = 2,
                    Name = "Anhoch Burgeri",
                    Address = "Bitola",
                    OpensAt = new TimeSpan(07,00,00),
                    ClosesAt = new TimeSpan(22,00,00),
                },
                new Location
                {
                    Id = 3,
                    Name = "Setek Burgeri",
                    Address = "Veles",
                    OpensAt = new TimeSpan(07,00,00),
                    ClosesAt = new TimeSpan(22,00,00),
                },
            };

            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    FullName = "Bob Bobsky",
                    Address = "Ilinden",
                    IsDelivered = true,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 1,
                            Burger = Burgers[0],
                            BurgerId = Burgers[0].Id,
                            OrderId = 1,
                        },
                        new BurgerOrder
                        {
                            Id = 2,
                            Burger = Burgers[1],
                            BurgerId = Burgers[1].Id,
                            OrderId = 1,
                        }
                    },
                    Location = Locations[0]
                },
                new Order
                {
                    Id = 2,
                    FullName = "Boki Boksan",
                    Address = "Skopje",
                    IsDelivered = false,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 3,
                            Burger = Burgers[2],
                            BurgerId = Burgers[2].Id,
                            OrderId = 2,
                        },
                    },
                    Location = Locations[1]
                },
                new Order
                {
                    Id = 3,
                    FullName = "Jhon Wick",
                    Address = "Veles",
                    IsDelivered = false,
                    BurgerOrders = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Id = 4,
                            Burger = Burgers[1],
                            BurgerId = Burgers[1].Id,
                            OrderId = 3,
                        },
                    },
                    Location = Locations[2]
                },
                
            };
        }
    }
}
