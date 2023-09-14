using SEDC.BurgerApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [Display(Name = "Is Delivered")]
        public bool IsDelivered { get; set; }
        [Display(Name = "Location")]
        public Location Location { get; set; } // Change the type to Location
        [Display(Name = "User")]
        public int LocationId { get; set; }
        [Display(Name = "Burgers")]
        public List<string>? BurgerNames { get; set; }
    }
}
