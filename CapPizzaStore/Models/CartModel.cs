using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class CartModel
    {
        private List<CartItem> cartItems;

        public CartModel()
        {
            this.cartItems = new List<CartItem>();
        }

        public List<CartItem> findAll()
        {
            return this.cartItems;
        }
    }
}