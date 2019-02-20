using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public InfoViewModel InfoView { get; set; }

        public string DeliveryTime { get; set; }

        public string Total { get; set; }
    }
}