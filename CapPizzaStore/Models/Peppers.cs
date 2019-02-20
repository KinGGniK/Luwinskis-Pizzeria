using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Peppers : Topping
    {
        Pizza pizza = null;

        public Peppers(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " peppers";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .40;
        }
    }
}