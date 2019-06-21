using _01_Cafe_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRunMenu = true;
            while (continueToRunMenu == true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option.\n" +
                    "1: List all meals.\n" +
                    "2: Add new meal to the menu.\n" +
                    "3: Remove a meal from the menu.\n" +
                    "4: Exit.");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListAllMeals();
                        break;
                    case "2":
                        CreateAndAddNewMeal();
                        break;
                    case "3":
                        RemoveMealFromMenu();
                        break;
                    case "4":
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option." +
                            "\n Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CreateAndAddNewMeal()
        {
            CafeMeal meal = new CafeMeal();
            Console.Write("Please enter a meal name: ");
            meal.Name = Console.ReadLine();

            Console.Write("Please enter a meal number: ");
            meal.Number = int.Parse(Console.ReadLine());

            Console.Write("Please enter a meal description: ");
            meal.Description = Console.ReadLine();

            Console.Write("Please enter all ingredients used in the meal: ");
            meal.Ingredients = Console.ReadLine();

            Console.Write("Please enter the price of the meal: ");
            meal.Price = decimal.Parse(Console.ReadLine());

            _menuRepo.AddNewMeal(meal);
        }

        private void ListAllMeals()
        {
            List<CafeMeal> _listOfMeals = _menuRepo.GetMealsList();

            foreach (CafeMeal meal in _listOfMeals)
            {
                Console.WriteLine($"{meal.Name} also called the number {meal.Number}");
            }
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private void RemoveMealFromMenu()
        {
            Console.Write("Please enter the name of the meal you would like to remove: ");
            CafeMeal meal = _menuRepo.GetMealByName(Console.ReadLine());
            _menuRepo.RemoveMeal(meal);
        }
    }
}
