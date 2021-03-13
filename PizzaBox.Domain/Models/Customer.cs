using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public List<Order> Orders { get; set; }

        
    }
}