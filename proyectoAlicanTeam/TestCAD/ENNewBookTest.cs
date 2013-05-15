using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAlicanTeam.EN;

namespace TestCAD
{
    [TestClass]
    public class ENNewBookTest
    {
        [TestMethod]
        public void VerifyingPrice()
        {
            var newBook = new ENNewBook();
            newBook = newBook.Read(1);
            var price = newBook.Price;
            //used to fail casting
        }
    }
}
