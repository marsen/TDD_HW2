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
            List<PotterBook> stubBooks = new List<PotterBook>
            {
                new PotterBook { Volume = 1 ,Price=100 }
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
            List<PotterBook> stubBooks = new List<PotterBook>
            {
                new PotterBook { Volume = 1 ,Price=100 },
                new PotterBook { Volume = 2 ,Price=100 }
            };
            decimal expected = 190;

            //act
            decimal actual = target.Check(stubBooks);
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}