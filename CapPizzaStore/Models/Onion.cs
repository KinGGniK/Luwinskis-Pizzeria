using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Onion : Topping
    {
        Pizza pizza = null;

        public Onion(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " onion";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .35;
        }
    }
}