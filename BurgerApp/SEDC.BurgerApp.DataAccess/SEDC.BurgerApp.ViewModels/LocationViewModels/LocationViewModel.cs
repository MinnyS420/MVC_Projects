namespace SEDC.BurgerApp.ViewModels.LocationViewModels
{
        public class LocationViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public TimeSpan OpensAt { get; set; }
            public TimeSpan ClosesAt { get; set; }
        }
}