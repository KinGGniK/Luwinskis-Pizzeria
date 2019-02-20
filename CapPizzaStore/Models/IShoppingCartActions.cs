using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapPizzaStore.Models
{
    public interface IShoppingCartActions
    {
        void AddtoCart();
        void RemoveCart();
        void EditCart();
    }
}
