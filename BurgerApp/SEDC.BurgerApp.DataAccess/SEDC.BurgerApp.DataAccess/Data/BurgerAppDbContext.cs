using Microsoft.EntityFrameworkCore;
using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.DataAccess.Data
{
    //Microsoft.EntityFrameworkCore
    //Microsoft.EntityFrameworkCore.Design
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.Tools
    public class BurgerAppDbContext : DbContext
    {
        public BurgerAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Burger> Burgers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Defining relations 
            modelBuilder.Entity<Order>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Location)
                .WithMany()
                .HasForeignKey(x => x.LocationId);

            modelBuilder.Entity<Burger>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Burger)
                .HasForeignKey(x => x.BurgerId);

            // Seeding
            modelBuilder.Entity<Burger>()
                .HasData(
                new Burger
                {
                    Id = 1,
                    Name = "Chicken Burger",
                    Price = 2,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = false,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 2,
                    Name = "Ham Burger",
                    Price = 3,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 3,
                    Name = "Veggie Burger",
                    Price = 2,
                    IsVegan = false,
                    IsVegetarian = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 4,
                    Name = "Cheeseburger",
                    Price = 3.5,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 5,
                    Name = "Double Cheeseburger",
                    Price = 5.0,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 6,
                    Name = "Bacon Burger",
                    Price = 4.5,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 7,
                    Name = "Fish Burger",
                    Price = 3.8,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 8,
                    Name = "Mushroom Burger",
                    Price = 3.2,
                    IsVegan = true,
                    IsVegetarian = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 9,
                    Name = "BBQ Burger",
                    Price = 4.0,
                    IsVegan = false,
                    IsVegetarian = false,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                },
                new Burger
                {
                    Id = 10,
                    Name = "Vegan Burger",
                    Price = 3.5,
                    IsVegan = true,
                    IsVegetarian = true,
                    HasFries = true,
                    BurgerOrders = new List<BurgerOrder> { }
                }
                );

            modelBuilder.Entity<Location>()
                .HasData(
                new Location
                {
                    Id = 1,
                    Name = "Tehno Burgeri",
                    Address = "Skopje",
                    OpensAt = new TimeSpan(07, 00, 00),
                    ClosesAt = new TimeSpan(22, 00, 00),
                },
                new Location
                {
                    Id = 2,
                    Name = "Anhoch Burgeri",
                    Address = "Bitola",
                    OpensAt = new TimeSpan(07, 00, 00),
                    ClosesAt = new TimeSpan(22, 00, 00),
                },
                new Location
                {
                    Id = 3,
                    Name = "Setek Burgeri",
                    Address = "Veles",
                    OpensAt = new TimeSpan(07, 00, 00),
                    ClosesAt = new TimeSpan(22, 00, 00),
                }
                );

            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    Id = 1,
                    FullName = "Bob Bobsky",
                    IsDelivered = true,
                    Address = "Ilinden",
                    LocationId = 1,
                },
                new Order
                {
                    Id = 2,
                    FullName = "Boki Boksan",
                    IsDelivered = false,
                    Address = "Marion",
                    LocationId = 2,
                },
                new Order
                {
                    Id = 3,
                    FullName = "Jhon Wick",
                    IsDelivered = false,
                    Address = "Marion",
                    LocationId = 3,
                }
                );

            modelBuilder.Entity<BurgerOrder>()
                .HasData(
                new BurgerOrder
                {
                    Id = 1,
                    BurgerId = 1,
                    OrderId = 1,
                },
                new BurgerOrder
                {
                    Id = 2,
                    BurgerId = 1,
                    OrderId = 1,
                },
                new BurgerOrder
                {
                    Id = 3,
                    BurgerId = 3,
                    OrderId = 2,
                },
                new BurgerOrder
                {
                    Id= 4,
                    BurgerId = 2,
                    OrderId = 3,
                }
                );
        }
    }
}
