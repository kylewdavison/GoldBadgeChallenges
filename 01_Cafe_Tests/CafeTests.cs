using System;
using _01_Cafe_Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class CafeTests
    {
        private MenuRepo _menuRepo;
        private CafeMeal _meal;
        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepo();
            _meal = new CafeMeal("Big Mac", 1, "tastes real good", "a few tasty things between buns", 5);
        }

        [TestMethod]
        public void AddMealToMenuTest()
        {
            _menuRepo.AddNewMeal(_meal);
            int expected = 1;
            int actual = _menuRepo.GetMealsList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveMealFromListTest()
        {
            _menuRepo.AddNewMeal(_meal);
            bool wasRemoved = _menuRepo.RemoveMeal(_meal);

            Assert.IsTrue(wasRemoved);
        }

        [TestMethod]
        public void GetMealByNameTest()
        {
            _menuRepo.AddNewMeal(_meal);
            CafeMeal expected = new CafeMeal("Big Mac", 1, "tastes real good", "a few tasty things between buns", 5);
            CafeMeal actual = _menuRepo.GetMealByName("big mac");
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }
}
