using System;
using _07_BBQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07_BBQ_Tests
{
    [TestClass]
    public class BBQTests
    {
        private EventRepo _eventRepo;
        private Burger _burgerBooth;
        private Treat _treatBooth;
        [TestInitialize]
        public void Arrange()
        {
            _eventRepo = new EventRepo();
            _burgerBooth = _eventRepo.GetBurgerBooth();
            _treatBooth = _eventRepo.GetTreatBooth();
            
        }
        [TestMethod]
        public void AddMealTest()
        {
            _eventRepo.RedeemTicket((BurgerTicket)1, (TreatTicket)1, 0.5m, 0.3m);
            Assert.AreEqual(_burgerBooth.HamCount, 1);
            Assert.AreEqual(_treatBooth.IceCreamCount, 1);
            Assert.AreEqual(_burgerBooth.MiscCost, 0.5m);
            Assert.AreEqual(_treatBooth.MiscCost, 0.3m);
        }

        [TestMethod]
        public void GetTreatBoothTest()
        {
            _eventRepo.RedeemTicket((BurgerTicket)1, (TreatTicket)1, 0.5m, 0.3m);
            Assert.AreEqual(_eventRepo.GetTreatBooth().IceCreamCount, 1);
        }
        [TestMethod]
        public void GetBurgerBooth()
        {
            _eventRepo.RedeemTicket((BurgerTicket)1, (TreatTicket)1, 0.5m, 0.3m);
            Assert.AreEqual(_eventRepo.GetBurgerBooth().HamCount, 1);
        }

    }
}
