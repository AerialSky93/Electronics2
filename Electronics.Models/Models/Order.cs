using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models
{

    public class Order
    {

        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "Please enter Valid Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

    }
}