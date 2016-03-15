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
                new KeyValuePair<int, decimal>(4,0.80m),
                new KeyValuePair<int, decimal>(5,0.75m)
            };
        public PotterShoppingCart()
        {
        }

        public decimal Check(List<PotterBook> books)
        {
            books = books.OrderBy(x => x.Volume).ToList();
            PotterBook lastbook = null;
            int pointer = 0;
            List<PotterBook>[] template = new List<PotterBook>[books.Count];
            foreach (var book in books)
            {
                if (lastbook == null)
                {
                    template[pointer] = new List<PotterBook> { book };
                }
                else if (book.Volume == lastbook.Volume)
                {
                    pointer++;
                    if (template[pointer] == null)
                    {
                        template[pointer] = new List<PotterBook> { book };
                    }
                    else
                    {
                        template[pointer].Add(book);
                    }                    
                }
                else
                {
                    pointer = 0;
                    template[pointer].Add(book);
   
                }
                lastbook = book;
            }
            decimal result = 0m;
            foreach (var groupBookList in template)
            {
                if (groupBookList != null)
                {
                    result += discountLogic.Find(x => x.Key == groupBookList.Count()).Value * groupBookList.Sum(x => x.Price);
                }
            }
            return result;
        }
    }
}