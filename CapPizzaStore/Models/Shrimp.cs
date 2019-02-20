using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Shrimp : Topping
    {
        Pizza pizza = null;

        public Shrimp(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " shrimp";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .75;
        }
    }
}