using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class HawaiianPizza : APizza
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
                new Topping("Ham", 1.00),
                new Topping("Pineapple", 1.00)
            };
        }

        protected override double CalculateTotal()
        {
            double total = 0.0;
            return total;
        }

        public HawaiianPizza()
        {
            Name = "Hawaiian Pizza";
        }

        public HawaiianPizza(string c, string s)
        {
            Name = "Hawaiian Pizza";
            Crust.Name = c;
            Size.Name = s;
        }
    }
}