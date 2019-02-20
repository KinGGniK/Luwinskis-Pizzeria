using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Pepperoni : Topping
    {
        Pizza pizza = null;

        public Pepperoni(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " pepperoni";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .25;
        }
    }
}