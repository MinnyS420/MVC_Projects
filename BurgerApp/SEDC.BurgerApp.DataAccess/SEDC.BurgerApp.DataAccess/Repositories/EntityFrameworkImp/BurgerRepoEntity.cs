using SEDC.BurgerApp.DataAccess.Data;
using SEDC.BurgerApp.DataAccess.Repositories.Abstraction;
using SEDC.BurgerApp.Domain.Models;

namespace SEDC.BurgerApp.DataAccess.Repositories.EntityFrameworkImp
{
    public class BurgerRepoEntity : IBurgerRepository
    {
        private BurgerAppDbContext _burgerAppDbContext;
        public BurgerRepoEntity(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }
        public void DeleteById(int id)
        {
            Burger burgerDb = _burgerAppDbContext.Burgers.FirstOrDefault(pizza => pizza.Id == id);

            if (burgerDb == null)
            {
                throw new Exception($"The pizza with id {id} was not found!");
            }

            _burgerAppDbContext.Burgers.Remove(burgerDb);
            _burgerAppDbContext.SaveChanges();
        }

        public List<Burger> GetAll()
        {
            return _burgerAppDbContext.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            return _burgerAppDbContext.Burgers.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Burger entity)
        {
            _burgerAppDbContext.Burgers.Add(entity);
            return _burgerAppDbContext.SaveChanges();
        }

        public void Update(Burger entity)
        {
            _burgerAppDbContext.Burgers.Update(entity);
            _burgerAppDbContext.SaveChanges();
        }
    }
}
