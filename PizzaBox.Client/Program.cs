using System;
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
            
            MainMenu();

            var userChoice2 = System.Console.ReadLine();
            switch (userChoice2)
            {
                case "1":
                    // Place Order
                    PizzaMenu();
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

        public static void MainMenu()
        {
            System.Console.WriteLine("1. Place Order");
            System.Console.WriteLine("2. View Order History");
            System.Console.WriteLine("3. Exit");
        }

        public static void PizzaMenu()
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

            
            
            // switch(userPizzaChoice.ToLower())
            // {
            //     case "custom pizza":
            //         var crustChoice = CrustMenu();
            //         var sizeChoice = SizeMenu();
            //         break;
            //     case "cheese pizza":
            //         var crustChoice = CrustMenu();
            //         var sizeChoice = SizeMenu();
            //         break;
            //     case "hawaiian pizza":
            //         break;
            //     case "pepperoni pizza":
            //         break;
            //     case "sausage pizza":
            //         break;
            //     case "veggie pizza":
            //         break;
            // }

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

        public static string CrustMenu()
        {
            System.Console.WriteLine("\nPick a crust");
            System.Console.WriteLine("--------------------------");
            System.Console.WriteLine("1.) Regular");
            System.Console.WriteLine("2.) Thin");
            System.Console.WriteLine("3.) Stuffed");

            var userChoice = System.Console.ReadLine();
            var crustType = "";

            switch (userChoice)
            {
                case "1":
                    crustType = "Regular";
                    break;
                case "2":
                    crustType = "Thin";
                    break;
                case "3":
                    crustType = "Stuffed";
                    break;
            }

            return crustType;

        }

        public static string SizeMenu()
        {
            System.Console.WriteLine("\nPick a size");
            System.Console.WriteLine("--------------------------");
            System.Console.WriteLine("1.) Small");
            System.Console.WriteLine("2.) Medium");
            System.Console.WriteLine("3.) Large");

            var userChoice = System.Console.ReadLine();
            var sizeType = "";

            switch (userChoice)
            {
                case "1":
                    sizeType = "Small";
                    break;
                case "2":
                    sizeType = "Medium";
                    break;
                case "3":
                    sizeType = "Large";
                    break;
            }

            return sizeType;
        }

        public static void ToppingsMenu()
        {
            System.Console.WriteLine("\nPick a topping");
            System.Console.WriteLine("--------------------------");
            System.Console.WriteLine("1.) Pepperoni");
            System.Console.WriteLine("2.) Sausage");
            System.Console.WriteLine("3.) Ham");
            System.Console.WriteLine("4.) Bacon");
            System.Console.WriteLine("5.) Black Olives");
            System.Console.WriteLine("6.) Green Peppers");
            System.Console.WriteLine("7.) Diced Tomatoes");
            System.Console.WriteLine("8.) Mushrooms");
            System.Console.WriteLine("9.) Spinach");
            System.Console.WriteLine("10.) Mixed Onions");
            System.Console.WriteLine("11.) Pineapple");
        }
    }
}
