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

        [TestMethod]
        public void 哈利波特系列_一二三集各買了一本_價格應為270()
        {
            ////arrange
            var target = new PotterShoppingCart();
            List<PotterBook> stubBooks = new List<PotterBook>
            {
                new PotterBook { Volume = 1 ,Price=100 },
                new PotterBook { Volume = 2 ,Price=100 },
                new PotterBook { Volume = 3 ,Price=100 }
            };
            decimal expected = 270;
            ////act
            decimal actual = target.Check(stubBooks);
            ////assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 哈利波特系列_一二三四集各買了一本_價格應為320()
        {
            ////arrange
            var target = new PotterShoppingCart();
            List<PotterBook> stubBooks = new List<PotterBook>
            {
                new PotterBook { Volume = 1 ,Price=100 },
                new PotterBook { Volume = 2 ,Price=100 },
                new PotterBook { Volume = 3 ,Price=100 },
                new PotterBook { Volume = 4 ,Price=100 }
            };
            decimal expected = 320;
            ////act
            decimal actual = target.Check(stubBooks);
            ////assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 哈利波特系列_一二三四五集各買了一本_價格應為375()
        {
            ////arrange
            var target = new PotterShoppingCart();
            List<PotterBook> stubBooks = new List<PotterBook>
            {
                new PotterBook { Volume = 1 ,Price=100 },
                new PotterBook { Volume = 2 ,Price=100 },
                new PotterBook { Volume = 3 ,Price=100 },
                new PotterBook { Volume = 4 ,Price=100 },
                new PotterBook { Volume = 5 ,Price=100 }
            };
            decimal expected = 375;
            ////act
            decimal actual = target.Check(stubBooks);
            ////assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 哈利波特系列_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            ////arrange
            var target = new PotterShoppingCart();
            List<PotterBook> stubBooks = new List<PotterBook>
            {
                new PotterBook { Volume = 1 ,Price=100 },
                new PotterBook { Volume = 2 ,Price=100 },
                new PotterBook { Volume = 3 ,Price=100 },
                new PotterBook { Volume = 3 ,Price=100 }
            };
            decimal expected = 370;
            ////act
            decimal actual = target.Check(stubBooks);
            ////assert
            Assert.AreEqual(expected, actual);
        }
    }
}