using System;
using System.Collections.Generic;
using System.Linq;

namespace MallLib
{
    public class PotterShoppingCart
    {
        public PotterShoppingCart()
        {
        }

        public decimal Check(List<PotterBook> books)
        {
            decimal totalPrice = 0;
            if (books.Count == 1)
            {
                totalPrice = books.Sum(x => x.Price);                
            }
            else if (books.Count == 2)
            {
                if (books.ElementAt(0).Volume == books.ElementAt(1).Volume)
                {
                    totalPrice = books.Sum(x => x.Price);
                }
                else
                {
                    totalPrice = 0.95m * books.Sum(x => x.Price);
                }
            }
            else
            {
                var groupedBookList = books.GroupBy(x => x.Volume);
                var groupCount = groupedBookList.Count();
                if (groupCount == 1)
                {
                    totalPrice = books.Sum(x => x.Price);
                }
                else if (groupCount == 3)
                {
                    totalPrice = 0.9m * books.Sum(x => x.Price);
                }
                else
                {
                    //groupCount == 2
                    for (int i = 0; i < groupCount; i++)
                    {
                        var groupedBooks = groupedBookList.ElementAt(i);
                        if (groupedBooks.Count() == 1)
                        {
                            totalPrice += groupedBooks.Sum(x => x.Price);
                        }
                        else
                        {
                            totalPrice += 0.95m * groupedBooks.Sum(x => x.Price);
                        }
                    }
                }
            }
            return totalPrice;
        }
    }
}