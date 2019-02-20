using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Small : Pizza
    {
        public Small()
        {
            this.description = "Small pizza with ";
        }

        public override double GetCost()
        {
            return Math.Round(7.45, 2);
        }
    }
}