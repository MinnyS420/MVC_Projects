using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.DataAccess.Repositories.StaticDbImp
{
    public class BurgerRepo : IBurgerRepository
    {
        public void DeleteById(int id)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
            if (burger == null)
            {
                throw new Exception($"Burger with id {id} was not found");
            }
            StaticDb.Burgers.Remove(burger);
        }

        public List<Burger> GetAll()
        {
            return StaticDb.Burgers;
        }

        public Burger GetById(int id)
        {
            return StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Burger entity)
        {
            entity.Id = ++StaticDb.BurgerId;
            StaticDb.Burgers.Add(entity);
            return entity.Id;
        }

        public void Update(Burger entity)
        {
            Burger burger = StaticDb.Burgers.FirstOrDefault(x => x.Id == entity.Id);
            if (burger == null)
            {
                throw new Exception($"Burger with id {entity.Id} was not found");
            }
            int index = StaticDb.Burgers.IndexOf(burger);
            StaticDb.Burgers[index] = entity;
        }
    }
}
