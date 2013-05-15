using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAlicanTeam.EN;
using System.Collections.Generic;

namespace TestCAD
{
    [TestClass]
    public class ENAdvertisementTest
    {
        [TestMethod]
        public void AdvertisementConnectingAndReadingAll()
        {
            var actual = new List<ENAdvertisement>();
            var advert = new ENAdvertisement();
            Assert.AreEqual(0, advert.Id);
            actual = advert.ReadAll();
        }
    }
}
