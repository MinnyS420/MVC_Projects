namespace SEDC.BurgerApp.Domain.Models
{
    public class Burger : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
        public List<BurgerOrder> BurgerOrders { get; set; }
        //public string ImageName { get; set; }
    }
}