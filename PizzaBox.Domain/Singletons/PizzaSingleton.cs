using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Domain.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    public class PizzaSingleton
    {
        private readonly string _path = @"pizza.xml";
        private static PizzaSingleton _PizzaSingleton;
        public List<APizza> Pizzas { get; set; }
        
        public static PizzaSingleton Instance 
        { 
            get
            {
                if (_PizzaSingleton == null)
                {
                    _PizzaSingleton = new PizzaSingleton();
                }

            return _PizzaSingleton;
            }
        }

        public void Seeding()
        {
            System.Console.WriteLine("Test");
            var pizzas = new List<APizza>
            {
                new CustomPizza(),
                new HawaiianPizza(),
                new CheesePizza(),
                new PepperoniPizza(),
                new SausagePizza(),
                new VeggiePizza()
            };

            var fs = new FileStorage();

            fs.WriteToXml<APizza>(pizzas, _path);

            Pizzas = fs.ReadFromXml<APizza>(_path).ToList();
        }
    }
}