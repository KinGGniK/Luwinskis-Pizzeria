using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapPizzaStore.Models
{
    public abstract class Pizza
    {
        public string description = "N/A";

        public virtual string GetDescription()
        {
            return this.description;
        }

        public abstract double GetCost();
    }
}