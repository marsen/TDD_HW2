using System.Collections.Generic;
using MallLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpecTest
{
    [TestClass]
    public class SeriesDiscount
    {
        [TestMethod]
        public void 哈利波特系列_第一集買了一本_其他都沒買_價格應為100元()
        {
            //arrange
            var target = new PotterShoppingCart();
            List<Book> stubBooks = new List<Book>
            {
                new Book { Series="Harry Potter", Volume = 1 ,Price=100 }
            };
            decimal expected = 100;

            //act
            decimal actual = target.Check(stubBooks);
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 哈利波特系列_第一集買了一本_第二集也買了一本_價格應為190元()
        {
            //arrange
            var target = new PotterShoppingCart();
            List<Book> stubBooks = new List<Book>
            {
                new Book { Series="Harry Potter", Volume = 1 ,Price=100 },
                new Book { Series="Harry Potter", Volume = 2 ,Price=100 }
            };
            decimal expected = 190;

            //act
            decimal actual = target.Check(stubBooks);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}