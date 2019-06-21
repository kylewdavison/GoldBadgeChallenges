using System;
using _02_Claim;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claim_Tests
{
    [TestClass]
    public class ClaimTests
    {
        private ClaimRepo _claimRepo;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepo();
            _claim = new Claim(1, ClaimType.Car, "its broke yo", 45m, DateTime.Parse("3-5-19"), DateTime.Parse("3-3-19"), true);
        }

        [TestMethod]
        public void AddMealToMenuTest()
        {
            _claimRepo.AddNewClaim(_claim);
            int expected = 1;
            int actual = _claimRepo.GetClaims().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
