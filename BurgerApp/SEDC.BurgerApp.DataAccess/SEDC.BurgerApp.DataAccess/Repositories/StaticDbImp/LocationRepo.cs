using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.DataAccess.Repositories.StaticDbImp
{
    public class LocationRepo : IRepository<Location>
    {
        public void DeleteById(int id)
        {
            Location location = StaticDb.Locations.FirstOrDefault(l => l.Id == id);
            if (location != null)
            {
                StaticDb.Locations.Remove(location);
            }
        }

        public List<Location> GetAll()
        {
            return StaticDb.Locations.ToList();
            //return StaticDb.Locations.ToList();
        }

        public Location GetById(int id)
        {
            return StaticDb.Locations.FirstOrDefault(l => l.Id == id);
        }

        public int Insert(Location entity)
        {
            entity.Id = ++StaticDb.LocationId;
            StaticDb.Locations.Add(entity);
            return entity.Id;
        }

        public void Update(Location entity)
        {
            Location location = StaticDb.Locations.FirstOrDefault(x => x.Id == entity.Id);
            if (location == null)
            {
                throw new Exception($"Burger with id {entity.Id} was not found");
            }
            int index = StaticDb.Locations.IndexOf(location);
            StaticDb.Locations[index] = entity;
        }
    }
}
