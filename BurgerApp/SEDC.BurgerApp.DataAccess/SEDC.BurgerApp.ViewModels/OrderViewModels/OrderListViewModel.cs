using SEDC.BurgerApp.ViewModels.LocationViewModels;
using System.ComponentModel.DataAnnotations;

namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsDelivered { get; set; }
        public string Address { get; set; }
        public LocationViewModel Location { get; set; }
        [Display(Name = "Burgers")]
        public List<string>? BurgerNames { get; set; }
        public int LocationId { get; set; }

    }
}
