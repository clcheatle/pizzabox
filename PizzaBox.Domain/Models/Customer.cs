using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; }

        public Customer()
        {

        }
        public Customer(string n, string e)
        {
            Name = n;
            Email = e;
            Orders = new List<Order>();
        }

        
    }
}