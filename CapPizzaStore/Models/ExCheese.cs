using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class ExCheese : Topping
    {
        Pizza pizza = null;

        public ExCheese(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " extra cheese";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .25;
        }
    }
}