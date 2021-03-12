using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(NewYorkStore))]
    public class AStore
    {
        public string Name { get; set; }    //property

        //public List<Order> Orders { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}