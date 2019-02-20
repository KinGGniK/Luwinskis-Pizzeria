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
    public class PizzaViewModel
    {
        [Required]
        public string Size { get; set; }

        public string Name { get; set; }

        public bool? Bacon { get; set; }

        public bool? BBQ { get; set; }

        public bool? Cheese { get; set; }

        public bool? Mushroom { get; set; }

        public bool? Onion { get; set; }

        public bool? Pepperoni { get; set; }

        public bool? Pepper { get; set; }

        public bool? Pineapple { get; set; }

        public bool? Sausage { get; set; }

        public bool? Shrimp { get; set; }

        public bool? Delivery { get; set; }
    }
}