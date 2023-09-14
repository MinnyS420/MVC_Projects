using SEDC.BurgerApp.Domain.Models;
using SEDC.BurgerApp.ViewModels.LocationViewModels;
using System.ComponentModel.DataAnnotations;

namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class OrderDetailsViewModel
    {
        [Display(Name = "Is Delivered")]
        public bool IsDelivered { get; set; }
        [Display(Name = "Order Location")]
        public string LocationName { get; set; }
        public LocationViewModel Location { get; set; }
        public string LocationAddress { get; set; }
        public string Address { get; set; }
        public int LocationId { get; set; }
        [Display(Name = "User")]
        public string FullName { get; set; }
        [Display(Name = "Burgers")]
        public List<string>? BurgerNames { get; set; }
        public int Id { get; set; }
    }
}
