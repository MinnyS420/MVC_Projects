using SEDC.BurgerApp.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace SEDC.BurgerApp.ViewModels.OrderViewModels
{
    public class BurgerOrderViewModel
    {
        [Display(Name = "Order")]
        public Order Order { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "Burger")]
        public Burger Burger  { get; set; }
        public int BurgerId { get; set; }
    }
}
