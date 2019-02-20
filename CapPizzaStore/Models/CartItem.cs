namespace CapPizzaStore.Models
{
    public class CartItem
    {
        private int id;
        private Pizza pizza;
        private int quant;
        private InfoViewModel viewModel;

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public Pizza Pizza
        {
            get
            {
                return this.pizza;
            }
            set
            {
                this.pizza = value;
            }
        }

        public int Quant
        {
            get
            {
                return this.quant;
            }
            set
            {
                this.quant = value;
            }
        }

        public InfoViewModel ViewModel
        {
            get
            {
                return this.viewModel;
            }
            set
            {
                this.viewModel = value;
            }
        }

        public CartItem()
        {

        }

        public CartItem(int ID, Pizza Pizza, int Quant)
        {
            this.id = ID;
            this.pizza = Pizza;
            this.quant = Quant;
            this.viewModel = null;
        }
        public CartItem(int ID, Pizza Pizza, int Quant, InfoViewModel ViewModel)
        {
            this.id = ID;
            this.pizza = Pizza;
            this.quant = Quant;
            this.viewModel = ViewModel;
        }
        public CartItem(int ID, Pizza Pizza)
        {
            this.id = ID;
            this.pizza = Pizza;
            this.quant = 1;
            this.viewModel = null;
        }
        public CartItem(Pizza Pizza, int Quant)
        {
            this.id = -1;
            this.pizza = Pizza;
            this.quant = Quant;
            this.viewModel = null;
        }
        public CartItem(Pizza Pizza)
        {
            this.id = -1;
            this.pizza = Pizza;
            this.quant = 1;
            this.viewModel = null;
        }
    }
}