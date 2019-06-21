using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Menu
{
    public class MenuRepo
    {
        private List<CafeMeal> _listOfMeals = new List<CafeMeal>();

        public void AddNewMeal(CafeMeal meal)
        {
            _listOfMeals.Add(meal);
        }

        public List<CafeMeal> GetMealsList()
        {
            return _listOfMeals;
        }

        public CafeMeal GetMealByName(string name)
        {
            foreach (CafeMeal meal in _listOfMeals)
            {
                if (meal.Name.ToLower() == name.ToLower())
                {
                    return meal;
                }
            }
            return null;
        }

        public bool RemoveMeal(CafeMeal meal)
        {
            int initialCount = _listOfMeals.Count();
            _listOfMeals.Remove(meal);
            if (initialCount > _listOfMeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
