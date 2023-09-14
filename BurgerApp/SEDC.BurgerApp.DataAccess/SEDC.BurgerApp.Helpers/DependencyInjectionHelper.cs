using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.DataAccess.Repositories.EntityFrameworkImp;
using SEDC.BurgerApp.DataAccess.Repositories.StaticDbImp;
using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.Services;
using SEDC.BurgerApp.Services.Abstractions;

namespace SEDC.BurgerApp.Helpers
{
    // package Microsoft.Extensions.DependencyInjection.Abstractions v6.0.0

    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IBurgerService, BurgerService>();
            services.AddTransient<ILocationService, LocationService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            // static db
            //services.AddTransient<IRepository<Order>, OrderRepo>();
            //services.AddTransient<IBurgerRepository, BurgerRepo>();
            //services.AddTransient<IRepository<Location>, LocationRepo>();


            // entity framework
            services.AddTransient<IRepository<Order>, OrderRepoEntity>();
            services.AddTransient<IRepository<Location>, LocationRepoEntity>();
            services.AddTransient<IBurgerRepository, BurgerRepoEntity>();

        }

        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BurgerAppDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }

    }
}
