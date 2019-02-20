using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Medium : Pizza
    {
        public Medium()
        {
            this.description = "Medium pizza with ";
        }

        public override double GetCost()
        {
            return Math.Round(10.45, 2);
        }
    }
}