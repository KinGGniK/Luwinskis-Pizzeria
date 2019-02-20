using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Pineapple : Topping
    {
        Pizza pizza = null;

        public Pineapple(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " pineapple";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .30;
        }
    }
}