namespace SEDC.BurgerApp.ViewModels.BurgerViewModels
{
    public class BurgerIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public bool HasFries { get; set; }
        public string Image { get; set; }
    }
}