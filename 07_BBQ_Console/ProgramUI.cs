using _07_BBQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_BBQ_Console
{
    class ProgramUI
    {
        private EventRepo _eventRepo = new EventRepo();
        public void Run()
        {
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.Write("Choose a menu item: " +
                    "\n1. Redeem employee tickets for food" +
                    "\n2. View event details" +
                    "\n3. Exit" +
                    "\nChoose an option: ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        RedeemTickets();
                        break;
                    case "2":
                        ShowEventDetails();
                        break;
                    case "3":
                        continueToRun = false;
                        break;
                }
            }
        }
        public void RedeemTickets()
        {
            Console.Write("Welcome to the Komodo Insurance Burger Booth TM.  What can I get you today?" +
                "\n1: Hamburger" +
                "\n2: Veggie Burger" +
                "\n3: Hotdog" +
                "\n4: Nothing" +
                "\nChoose an option: ");
            int userInput = int.Parse(Console.ReadLine());
            BurgerTicket burgerTicket = (BurgerTicket) userInput;
            decimal miscBurger;
            if (userInput != 4)
            {
                miscBurger = 0.1m;
            }
            else { miscBurger = 0m; }
            Console.Write("Welcome to the Komodo Insurance Ice Cream Booth TM.  What can I get you today?" +
                "\n1: Ice Cream Cone" +
                "\n2: Popcorn" +
                "\n3: Nothing" +
                "\nChoose an option: ");
            userInput = int.Parse(Console.ReadLine());
            decimal miscTreat;
            if (userInput != 4)
            {
                miscTreat = 0.1m;
            }
            else { miscTreat = 0m; }
            TreatTicket treatTicket = (TreatTicket)userInput;
            _eventRepo.RedeemTicket(burgerTicket, treatTicket, miscBurger, miscTreat);
            
        }
        public void ShowEventDetails()
        {
            Burger burger = _eventRepo.GetBurgerBooth();
            Treat treat = _eventRepo.GetTreatBooth();
            decimal totalBurgerCost = burger.HamCost * burger.HamCount + burger.HotdogCost * burger.HotdogCount + burger.VegCost * burger.VegCount + burger.MiscCost;
            decimal totalTreatCost = treat.IceCreamCost * treat.IceCreamCount + treat.PopcornCost * treat.PopcornCount + treat.MiscCost;

            Console.WriteLine($"Burger Booth Information" +
                $"\nHamburger total cost: ${burger.HamCost * burger.HamCount}" +
                $"\nVeggie burger total cost: ${burger.VegCost * burger.VegCount}" +
                $"\nHotdog total cost: ${burger.HotdogCost * burger.HotdogCount}" +
                $"\nMiscellaneous costs: ${burger.MiscCost}" +
                $"\nTotal number of tickets used at this booth: {burger.HamCount +burger.HotdogCount + burger.VegCount} tickets" +
                $"\n\nTreat Booth Information" +
                $"\nIce Cream total cost: ${treat.IceCreamCost * treat.IceCreamCount}" +
                $"\nPopcorn total cost: ${treat.PopcornCost*treat.PopcornCount}" +
                $"\nMiscellaneous costs: ${treat.MiscCost}" +
                $"\nTotal number of tickets used at this booth: {treat.IceCreamCount + treat.PopcornCount} tickets" +
                $"\n\nTotal Cost of Event: ${totalBurgerCost+totalTreatCost}" +
                $"\nTotal number of tickets used at any booth: {treat.IceCreamCount +treat.PopcornCount+ burger.HamCount + burger.HotdogCount + burger.VegCount} tickets");
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
