using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Bacon : Topping
    {
        Pizza pizza = null;

        public Bacon(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " bacon";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .35;
        }
    }
}