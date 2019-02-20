using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapPizzaStore.Models;

namespace CapPizzaStore.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(int id, Pizza aPizza)
        {
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>
                {
                    new CartItem { Pizza = aPizza, Quant = 1 }
                };
                Session["cart"] = cart;
            }
            else
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quant++;
                }
                else
                {
                    cart.Add(new CartItem { Pizza = aPizza, Quant = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            int index = IsExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int IsExist(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].ID.Equals(id))
                    return i;
            return -1;
        }
    }
}