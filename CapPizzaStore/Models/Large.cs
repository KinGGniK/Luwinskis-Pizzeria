using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public class Large : Pizza
    {
        public Large()
        {
            this.description = "Large pizza with ";
        }

        public override double GetCost()
        {
            return Math.Round(13.45, 2);
        }
    }
}