using System;
using System.Collections.Generic;
using System.Linq;

namespace MallLib
{
    public class PotterShoppingCart
    {
        private List<KeyValuePair<int, decimal>> discountLogic =
            new List<KeyValuePair<int, decimal>>()
            {
                new KeyValuePair<int, decimal>(1,1.00m),
                new KeyValuePair<int, decimal>(2,0.95m),
                new KeyValuePair<int, decimal>(3,0.90m),
                new KeyValuePair<int, decimal>(4,0.80m)
            };
        public PotterShoppingCart()
        {
        }

        public decimal Check(List<PotterBook> books)
        {
            decimal totalPrice = 0;
            var bookCount = books.Count();
            var groupedBookList = books.GroupBy(x => x.Volume);
            var groupCount = groupedBookList.Count();
            if (groupCount == 1)
            {
                totalPrice = books.Sum(x => x.Price);
            }
            else if (groupCount == bookCount)
            {
                totalPrice = discountLogic.Find(x => x.Key == bookCount).Value * books.Sum(x => x.Price);
            }
            else
            {
                //groupCount == 2 or 3
                for (int i = 0; i < groupCount; i++)
                {
                    var groupedBooks = groupedBookList.ElementAt(i);
                    var groupedBooksCount = groupedBooks.Count();
                    if (bookCount >= groupedBooksCount && groupedBooksCount > 0)
                    {
                        totalPrice = discountLogic.Find(x => x.Key == groupedBooksCount).Value * books.Sum(x => x.Price);
                    }
                    else
                    {
                        throw new Exception("未知的書籍組合");
                    }
                }
            }
            
            return totalPrice;
        }
    }
}