using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.DataAccess.Repositories.EntityFrameworkImp
{
    public class LocationRepoEntity : IRepository<Location>
    {
        private BurgerAppDbContext _burgerAppDbContext;
        public LocationRepoEntity(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }
        public void DeleteById(int id)
        {
            Location locationDb = _burgerAppDbContext.Locations.FirstOrDefault(user => user.Id == id);

            if (locationDb == null)
            {
                throw new Exception($"The users with id {id} was not found!");
            }

            _burgerAppDbContext.Locations.Remove(locationDb);
            _burgerAppDbContext.SaveChanges();
        }
        public List<Location> GetAll()
        {
            return _burgerAppDbContext.Locations.ToList();
        }
        public Location GetById(int id)
        {
            return _burgerAppDbContext.Locations.FirstOrDefault(x => x.Id == id);
        }
        public int Insert(Location entity)
        {
            _burgerAppDbContext.Locations.Add(entity);
            return _burgerAppDbContext.SaveChanges();
        }
        public void Update(Location entity)
        {
            _burgerAppDbContext.Locations.Update(entity);
            _burgerAppDbContext.SaveChanges();
        }
    }
}