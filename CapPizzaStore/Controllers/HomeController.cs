using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapPizzaStore.Models;
using System.Web.Mvc;

namespace CapPizzaStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePizzaForm()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePizza(string size, string name, bool? bacon, bool? bbq, bool? cheese, bool? mushroom, bool? onion, bool? pepperoni, bool? pepper, bool? pineapple, bool? sausage, bool? shrimp, int amt, bool? deliver, InfoViewModel infoView)
        {
            bool isNum = IsNumber(amt);
            
            if (ModelState.IsValid && !string.IsNullOrEmpty(size) && isNum)
            {
                double totalCost;
                Pizza aPizza = null;

                //Switch statement for the size of the pizza
                switch (size)
                {
                    case "Small":
                        aPizza = new Small();
                        break;

                    case "Medium":
                        aPizza = new Medium();
                        break;

                    case "Large":
                        aPizza = new Large();
                        break;
                }

                //If the topping was selected then it is added to the pizza
                if (bacon == true)
                {
                    aPizza = new Bacon(aPizza);
                }

                if (bbq == true)
                {
                    aPizza = new BBQ(aPizza);
                }

                if (cheese == true)
                {
                    aPizza = new ExCheese(aPizza);
                }

                if (mushroom == true)
                {
                    aPizza = new Mushroom(aPizza);
                }

                if (onion == true)
                {
                    aPizza = new Onion(aPizza);
                }

                if (pepperoni == true)
                {
                    aPizza = new Pepperoni(aPizza);
                }

                if (pepper == true)
                {
                    aPizza = new Peppers(aPizza);
                }

                if (pineapple == true)
                {
                    aPizza = new Pineapple(aPizza);
                }

                if (sausage == true)
                {
                    aPizza = new Sausage(aPizza);
                }

                if (shrimp == true)
                {
                    aPizza = new Shrimp(aPizza);
                }


                //Created a variable to contain and manipulate the cost 
                totalCost = aPizza.GetCost();

                infoView.Delivery = deliver;

                if (Session["cart"] == null)
                {
                    List<CartItem> cart = new List<CartItem>
                {
                    new CartItem {
                                   ID = 1,
                                   Pizza = aPizza,
                                   Quant = amt,
                                   ViewModel = infoView
                                 }
                };
                    Session["info"] = infoView;
                    Session["cart"] = cart;
                    Session["Total"] = cart.Sum(item => item.Pizza.GetCost() * item.Quant);
                }
                else
                {
                    List<CartItem> cart = (List<CartItem>)Session["cart"];
                    int index = IsExist(aPizza);
                    if (index != -1)
                    {
                        cart[index].Quant++;
                    }
                    else
                    {
                        int currentID = cart.Count();
                        cart.Add(new CartItem { ID = currentID, Pizza = aPizza, Quant = amt, ViewModel = infoView });
                    }

                    Session["info"] = infoView;
                    Session["cart"] = cart;
                    Session["Total"] = cart.Sum(item => item.Pizza.GetCost() * item.Quant);
                }



                //Method sends order to database
                //aConnection.InsertPizzaOrder(aPizza, totalCost, name, amt, deliver, addy, city, zip, time);

                //Adds everything to a ViewBag to send to confirmation page
                //ViewBag.APizza = aPizza;
                //ViewBag.Total = totalCost;
                //ViewBag.Name = name;
                //ViewBag.Amt = amt;
                //ViewBag.Deliver = deliver;
                //ViewBag.Addy = addy;
                //ViewBag.City = city;
                //ViewBag.Zip = zip;
                //ViewBag.Time = time;

                return RedirectToAction("DisplayCart");
            }
            else
            {
                if(string.IsNullOrEmpty(size))
                {
                    TempData["Amt"] = "The amount must be a number";
                    TempData["Size"] = "A size must be selected";
                }
                
                return View("CreatePizzaForm", infoView);
            }
        }

        public ActionResult AddMorePizzaForm()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMorePizza(string size, string name, bool? bacon, bool? bbq, bool? cheese, bool? mushroom, bool? onion, bool? pepperoni, bool? pepper, bool? pineapple, bool? sausage, bool? shrimp, int amt)
        {
            if (!string.IsNullOrEmpty(size))
            {
                double totalCost;
                Pizza aPizza = null;

                //Switch statement for the size of the pizza
                switch (size)
                {
                    case "Small":
                        aPizza = new Small();
                        break;

                    case "Medium":
                        aPizza = new Medium();
                        break;

                    case "Large":
                        aPizza = new Large();
                        break;
                }

                //If the topping was selected then it is added to the pizza
                if (bacon == true)
                {
                    aPizza = new Bacon(aPizza);
                }

                if (bbq == true)
                {
                    aPizza = new BBQ(aPizza);
                }

                if (cheese == true)
                {
                    aPizza = new ExCheese(aPizza);
                }

                if (mushroom == true)
                {
                    aPizza = new Mushroom(aPizza);
                }

                if (onion == true)
                {
                    aPizza = new Onion(aPizza);
                }

                if (pepperoni == true)
                {
                    aPizza = new Pepperoni(aPizza);
                }

                if (pepper == true)
                {
                    aPizza = new Peppers(aPizza);
                }

                if (pineapple == true)
                {
                    aPizza = new Pineapple(aPizza);
                }

                if (sausage == true)
                {
                    aPizza = new Sausage(aPizza);
                }

                if (shrimp == true)
                {
                    aPizza = new Shrimp(aPizza);
                }


                //Created a variable to contain and manipulate the cost 
                totalCost = aPizza.GetCost();
                
                if (Session["cart"] == null)
                {
                    List<CartItem> cart = new List<CartItem>
                {
                    new CartItem {
                                   ID = 1,
                                   Pizza = aPizza,
                                   Quant = amt,
                                   ViewModel = (InfoViewModel)Session["info"]
                                 }
                };
                    Session["cart"] = cart;
                    Session["Total"] = cart.Sum(item => item.Pizza.GetCost() * item.Quant);
                }
                else
                {
                    List<CartItem> cart = (List<CartItem>)Session["cart"];
                    int index = IsExist(aPizza);
                    if (index != -1)
                    {
                        cart[index].Quant++;
                    }
                    else
                    {
                        int currentID = cart.Count();
                        cart.Add(new CartItem { ID = currentID, Pizza = aPizza, Quant = amt, ViewModel = (InfoViewModel)Session["info"] });
                    }
                    Session["cart"] = cart;
                    Session["Total"] = cart.Sum(item => item.Pizza.GetCost() * item.Quant);
                }
                

                return RedirectToAction("DisplayCart");
            }
            else
            {
                if (string.IsNullOrEmpty(size))
                {
                    TempData["Amt"] = "The amount must be a number";
                    TempData["Size"] = "A size must be selected";
                }

                return View("AddMorePizzaForm");
            }
        }

        public ActionResult DisplayCart()
        {
            double z = Math.Truncate((double)Session["Total"] * 100) / 100;

            CartViewModel cartView = new CartViewModel
            {
                CartItems = (List<CartItem>)Session["cart"],
                Total = z.ToString("F")
            };

            return View(cartView);
        }

        public ActionResult EditPizzaForm(int ID)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            PizzaViewModel pizzaView = new PizzaViewModel();
            CartItem anItem = cart.Find(item => item.ID.Equals(ID));

            if (anItem.Pizza.GetDescription().Contains("Bacon"))
            {
                pizzaView.Bacon = true;
            }

            if (anItem.Pizza.GetDescription().Contains("BBQ"))
            {
                pizzaView.BBQ = true;
            }

            if (anItem.Pizza.GetDescription().Contains("Cheese"))
            {
                pizzaView.Cheese = true;
            }

            return View(pizzaView);
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
                //int index = IsExist(id);
                //if (index != -1)
                //{
                //    cart[index].Quant++;
                //}
                //else
                //{
                //    cart.Add(new CartItem { Pizza = aPizza, Quant = 1 });
                //}
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
            Session["Total"] = cart.Sum(item => item.Pizza.GetCost() * item.Quant);
            TempData["Removed"] = "Pizza has been successfully removed";
            return RedirectToAction("DisplayCart");
        }
        private int IsExist(Pizza pizza)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Pizza.Equals(pizza))
                    return i;
            return -1;
        }
        private int IsExist(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].ID.Equals(id))
                    return i;
            return -1;
        }
        private bool IsNumber(int num)
        {
            bool result = false;

            if (num < 10 && num > 0)
            {
                result = true;
                return result;
            }

            return result;
        }

        //Create Checkout page and have it insert into database and display for confirmation
        public ActionResult Checkout()
        {
            CartViewModel cartView = new CartViewModel();
            InfoViewModel infoView = (InfoViewModel)Session["info"];
            List<CartItem> cartItems = (List<CartItem>)Session["cart"];
            DBConnection aConnection = new DBConnection();
            double total = Math.Truncate((double)Session["Total"] * 100) / 100;

            infoView.DeliveryTime = DateTime.Now;
            //If delivery was checked then cost is increase by 1 and the time for delivery is set to a standard 30 minutes or delivered free
            if (infoView.Delivery == true)
            {
                total++;
                infoView.DeliveryTime = infoView.DeliveryTime.AddMinutes(30.00);
            }
            else
            {
                infoView.Delivery = false;
                infoView.DeliveryTime = infoView.DeliveryTime.AddMinutes(50.00);
            }

            foreach (CartItem c in cartItems)
            {
                c.ViewModel.DeliveryTime = infoView.DeliveryTime;
                aConnection.InsertPizzaOrder(c, total);
            }

            cartView.DeliveryTime = infoView.DeliveryTime.ToShortTimeString();
            cartView.InfoView = infoView;
            cartView.CartItems = cartItems;
            cartView.Total = total.ToString("F");

            Session.Clear();

            return View(cartView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}