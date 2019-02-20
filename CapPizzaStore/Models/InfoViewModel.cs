using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CapPizzaStore.Models
{
    public class InfoViewModel
    {
        [Required(ErrorMessage = "A full name is required")]
        [DisplayName("Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "An address is required")]
        [DisplayName("Address")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Must be a valid address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "A city is required")]
        [DisplayName("City")]
        public string City { get; set; }

        public bool? Delivery { get; set; }

        [Required(ErrorMessage = "A zip code is required")]
        [DisplayName("Zip Code")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Must be a valid zip code")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "A phone number is required")]
        [DisplayName("Phone")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Must be a valid U.S number")]
        public string Phone { get; set; }

        public DateTime DeliveryTime { get; set; }
    }
}