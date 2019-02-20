using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Mushroom : Topping
    {
        Pizza pizza = null;

        public Mushroom(Pizza aPizza)
        {
            this.pizza = aPizza;
        }

        public override string GetDescription()
        {
            return this.pizza.GetDescription() + " mushroom";
        }

        public override double GetCost()
        {
            return this.pizza.GetCost() + .50;
        }
    }
}