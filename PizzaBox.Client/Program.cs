using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WelcomeUser();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void WelcomeUser()
        {
            var ss = StoreSingleton.Instance;

            ss.Seeding();

            // Print stores to user for selection
            Console.WriteLine("\nPlease select a store: ");
            System.Console.WriteLine("--------------------------");

            var storeCount = 1;
            foreach(var item in ss.Stores)
            {
                System.Console.WriteLine(storeCount + ".) " + item);
                storeCount += 1;
            }

            // get user store selection
            var userChoice = int.Parse(System.Console.ReadLine());
            var userStore = ss.Stores[userChoice - 1];
            Console.WriteLine("\nUser store: " + userStore);

            // User cart to store pizzas
            List<APizza> Cart = new List<APizza>();

            MainMenu(Cart);

        }

        public static void MainMenu(List<APizza> c)
        {
            System.Console.WriteLine("1. Place Order");
            System.Console.WriteLine("2. View Order History");
            System.Console.WriteLine("3. Exit");

            var userChoice2 = System.Console.ReadLine();
            switch (userChoice2)
            {
                case "1":
                    // Place Order
                    PizzaMenu(c);
                    System.Console.WriteLine("Number of Pizzas: {0} \nPizza Name: {1}, Pizza Crust: {2}, Crust Price: {3}, Pizza size, {4}, Size Price, {5}", 
                                                c.Count, c[0].Name, c[0].Crust.Name,c[0].Crust.Price, c[0].Size.Name, c[0].Size.Price);
                    break;
                case "2":
                    // View Order History
                    break;
                case "3":
                    // Exit
                    System.Console.WriteLine("Thank you, have a nice day.");
                    break;
            }
        }

        public static void PizzaMenu(List<APizza> c)
        {
            var ps = PizzaSingleton.Instance;

            ps.Seeding();

            System.Console.WriteLine("\nSelect a Pizza");
            System.Console.WriteLine("--------------------------");

            var pizzaSelCount = 1;
            foreach(var item in ps.Pizzas)
            {
                System.Console.WriteLine(pizzaSelCount + ".) " + item);
                pizzaSelCount += 1;
            }

            var userChoice = int.Parse(System.Console.ReadLine());
            var userPizzaChoice = ps.Pizzas[userChoice-1].Name;
            System.Console.WriteLine("Pizza chosen: {0}", userPizzaChoice);

            
            
            switch(userPizzaChoice.ToLower())
            {
                case "custom pizza":
                    var crustChoice = CrustMenu();
                    var sizeChoice = SizeMenu();
                    ToppingsMenu();
                    CustomPizza cp = new CustomPizza();
                    c.Add(cp);
                    break;
                case "cheese pizza":
                    crustChoice = CrustMenu();
                    sizeChoice = SizeMenu();
                    CheesePizza userPizza = new CheesePizza (crustChoice, sizeChoice);
                    c.Add(userPizza);
                    break;
                case "hawaiian pizza":
                    crustChoice = CrustMenu();
                    sizeChoice = SizeMenu();
                    break;
                case "pepperoni pizza":
                    crustChoice = CrustMenu();
                    sizeChoice = SizeMenu();
                    break;
                case "sausage pizza":
                    crustChoice = CrustMenu();
                    sizeChoice = SizeMenu();
                    break;
                case "veggie pizza":
                    crustChoice = CrustMenu();
                    sizeChoice = SizeMenu();
                    break;
            }

        }
        public static void PresetMenu()
        {
            var crustChoice = CrustMenu();
            var sizeChoice = SizeMenu();
        }

        public static void CreatePepperoni(string c, string s)
        {
            PepperoniPizza p = new PepperoniPizza();
            p.Crust.Name = c;
            p.Size.Name = s;
        }

        public static Crust CrustMenu()
        {
            var ps = PizzaSingleton.Instance;
            ps.Seeding();

            System.Console.WriteLine("\nPick a crust");
            System.Console.WriteLine("--------------------------");
            var crustSelCount = 1;
            foreach(var item in ps.Crusts)
            {
                System.Console.WriteLine(crustSelCount + ".) " + item.Name);
                crustSelCount += 1;
            }

            var userChoice = int.Parse(System.Console.ReadLine());
            var userCrustChoice = ps.Crusts[userChoice-1];
            System.Console.WriteLine("Crust chosen: {0}", userCrustChoice.Name);
            System.Console.WriteLine("Crust Price: {0}", userCrustChoice.Price);

            return userCrustChoice;

        }

        public static Size SizeMenu()
        {
            var ps = PizzaSingleton.Instance;
            ps.Seeding();

            System.Console.WriteLine("\nPick a size");
            System.Console.WriteLine("--------------------------");
            
            var sizeSelCount = 1;
            foreach(var item in ps.Sizes)
            {
                System.Console.WriteLine(sizeSelCount + ".) " + item.Name);
                sizeSelCount += 1;
            }

            var userChoice = int.Parse(System.Console.ReadLine());
            var userSizeChoice = ps.Sizes[userChoice-1];
            System.Console.WriteLine("Size chosen: {0}", userSizeChoice.Name);
            System.Console.WriteLine("Size Price: {0}", userSizeChoice.Price);

            return userSizeChoice;
        }

        public static void ToppingsMenu()
        {
            var ps = PizzaSingleton.Instance;
            ps.Seeding();

            System.Console.WriteLine("\nPick a topping");
            System.Console.WriteLine("--------------------------");

            var toppingSelCount = 1;
            foreach(var item in ps.PizzaToppings)
            {
                System.Console.WriteLine(toppingSelCount + ".) " + item.Name);
                toppingSelCount += 1;
            }

            var userChoice = int.Parse(System.Console.ReadLine());
            var userSizeChoice = ps.PizzaToppings[userChoice-1];
            System.Console.WriteLine("Topping chosen: {0}", userSizeChoice.Name);
            System.Console.WriteLine("Topping Price: {0}", userSizeChoice.Price);
            
        }
    }
}
