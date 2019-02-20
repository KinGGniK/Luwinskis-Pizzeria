using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class BBQ : Topping
    {
        Pizza pizza = null;

        public BBQ(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " BBQ";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .25;
        }
    }
}