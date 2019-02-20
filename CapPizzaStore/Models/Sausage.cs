using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Sausage : Topping
    {
        Pizza pizza = null;

        public Sausage(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " sausage";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .35;
        }
    }
}