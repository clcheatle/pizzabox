using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CustomPizza : APizza
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
        public override void CalculateTotal()
        {
            throw new System.NotImplementedException();
        }

        public CustomPizza()
        {
            Name = "Custom Pizza";
        }
        public CustomPizza(string c, string s)
        {
            Name = "Custom Pizza";
            Crust.Name = c;
            Size.Name = s;
        }
    }
}