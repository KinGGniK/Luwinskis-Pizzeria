using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class ShoppingCart
    {
        private InfoViewModel infoView = new InfoViewModel();
        private List<CartItem> aListofItems = new List<CartItem>();

        public InfoViewModel InfoView
        {
            get
            {
                return this.infoView;
            }
            set
            {
                this.infoView = value;
            }
        }

        public List<CartItem> AListofItems
        {
            get
            {
                return this.aListofItems;
            }
            set
            {
                this.aListofItems = value;
            }
        }

        public ShoppingCart()
        {

        }

        public ShoppingCart(InfoViewModel InfoView, List<CartItem> cartItems)
        {
            this.infoView = InfoView;
            this.aListofItems = cartItems;
        }


        public int ItemIndexOf(int ID)
        {
            foreach(CartItem item in aListofItems)
            {
                if(item.ID == ID)
                {
                    return aListofItems.IndexOf(item);
                }
            }
            return -1;
        }

        public void AddtoCart(ref CartItem aCartItem)
        {
            int index = ItemIndexOf(aCartItem.ID);

            aCartItem.ID = aListofItems.Count > 0 ? aListofItems.Max(x => x.ID) + 1 : 1;

            aListofItems.Add(aCartItem);
            
            return;
        }
        public void RemovefromCart(int itemID)
        {
            aListofItems.RemoveAt(itemID);
        }
        public void EditCart(CartItem aCartItem)
        {
            var ListItem = from ci in aListofItems where ci.ID == aCartItem.ID select ci;

            CartItem anItem = (CartItem)ListItem;

            anItem = aCartItem;

            aListofItems.Add(anItem);

            return;
        }

        public List<CartItem> ShowCart(ref List<CartItem> cartItems)
        {

            List<CartItem> leCartItems = cartItems;

            return leCartItems;
        }

        public CartItem FillItem(int id, List<CartItem> cartItems)
        {
            var ListedItem = (CartItem)cartItems.Where(ci => ci.ID.Equals(id)).FirstOrDefault();

            return ListedItem;
        }

        public double TotalsTotal
        {
            get
            {
                if(aListofItems == null)
                {
                    return 0;
                }
                else
                {
                    double total = 0;
                    foreach (CartItem aCartItem in aListofItems)
                    {
                        total += aCartItem.Quant * aCartItem.Pizza.GetCost();
                    }
                    return total;
                }
            }
        }
    }
}