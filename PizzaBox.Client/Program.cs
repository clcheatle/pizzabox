using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using PizzaBox.Storing;

namespace PizzaBox.Client
{
    /// <summary>
    /// Driver class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Driver
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WelcomeUser();
        }

        /// <summary>
        /// Displays stores for user to select from
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

            MainMenu(Cart, userStore.Name);

        }

        /// <summary>
        /// Displays main menu for user
        /// </summary>
        /// <param name="c"></param>

        public static void MainMenu(List<APizza> c, string s)
        {
            var userChoice2 = 0;

            while(userChoice2 != 4)
            {
                System.Console.WriteLine("1. Add a Pizza");
                System.Console.WriteLine("2. View Cart");
                System.Console.WriteLine("3. View Order History");
                System.Console.WriteLine("4. Exit");

                userChoice2 = int.Parse(System.Console.ReadLine());

                switch (userChoice2)
                {
                    case 1:
                        // Place Order
                        PizzaMenu(c);
                        break;
                    case 2:
                        // View Cart
                        CartPreview(c);
                        Checkout(c,s);
                        break;
                    case 3:
                        // View Order History

                        break;
                    case 4:
                        // Exit
                        System.Console.WriteLine("Thank you, have a nice day!");
                        break;
                }
            }
        }

        /// <summary>
        /// Displays Pizza Menu for user
        /// </summary>
        /// <param name="c"></param>

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
                    HawaiianPizza hp = new HawaiianPizza (crustChoice, sizeChoice);
                    c.Add(hp);
                    break;

                case "pepperoni pizza":
                    crustChoice = CrustMenu();
                    sizeChoice = SizeMenu();
                    PepperoniPizza pp = new PepperoniPizza (crustChoice, sizeChoice);
                    c.Add(pp);
                    break;

                case "sausage pizza":
                    crustChoice = CrustMenu();
                    sizeChoice = SizeMenu();
                    SausagePizza sp = new SausagePizza (crustChoice, sizeChoice);
                    c.Add(sp);
                    break;

                case "veggie pizza":
                    crustChoice = CrustMenu();
                    sizeChoice = SizeMenu();
                    VeggiePizza vp = new VeggiePizza (crustChoice, sizeChoice);
                    c.Add(vp);
                    break;
            }

        }

        /// <summary>
        /// Displays Crust Menu
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Displays Size Menu for User
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Displays Topping Menu for User
        /// </summary>
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

        /// <summary>
        /// Displays all pizzas currently in the cart
        /// </summary>
        /// <param name="cart"></param>
        public static void CartPreview(List<APizza> cart)
        {
            var pizzaTotal = 0.0;
            Console.WriteLine("List of Pizza that you ordered: ");
            foreach(var p in cart)
            {
                p.CalculateTotal();
                pizzaTotal += p.Total;
                System.Console.WriteLine("{0}: {1}", p.Name, p.Total);
            }

            System.Console.WriteLine("Subtotal: {0}", pizzaTotal);

        }

        /// <summary>
        /// Goes through checkout process with user to place their order
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="s"></param>
        public static void Checkout(List<APizza> cart, string s)
        {
            Console.WriteLine("Would you like to checkout? 1 for yes, 2 for no: ");
            var userChoice = int.Parse(Console.ReadLine());
            if(userChoice == 1)
            {
                Console.WriteLine("Please enter your name: ");
                var custName = Console.ReadLine();
                Console.WriteLine("Please enter your email: ");
                var custEmail = Console.ReadLine();

                Customer cust = new Customer(custName, custEmail);
                Order userOrder = new Order(cart, s, cust);
                var total = userOrder.calcTotal();
                userOrder.Total = total;
                userOrder.SaveOrderToXML(userOrder);
                Console.WriteLine("Your total is {0}. Thank you {1} for ordering! " , total, custName);
                cust.Orders.Add(userOrder);

            }
            else
            {
                Console.WriteLine("Returning you to main menu...");
            }
        }

        public static void ViewOrderHistory()
        {

        }
    }
}
