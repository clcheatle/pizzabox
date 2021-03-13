using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class PepperoniPizza : APizza
    {
        protected override void AddCrust()
        {
            Crust = new Crust();
        }

        protected override void AddSize()
        {
            Size = new Size();
        }

        protected override void AddToppings()
        {
            Toppings = new List<Topping>
            {
                new Topping(),
                new Topping()
            };
        }
        protected override double CalculateTotal()
        {
            throw new System.NotImplementedException();
        }

        public PepperoniPizza()
        {
            Name = "Pepperoni Pizza";
        }

        public PepperoniPizza(string c, string s)
        {
            Name = "Pepperoni Pizza";
            Crust.Name = c;
            Size.Name = s;
        }
    }
}