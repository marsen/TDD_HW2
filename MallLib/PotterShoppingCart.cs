using System;
using System.Collections.Generic;
using System.Linq;

namespace MallLib
{
    public class PotterShoppingCart
    {
        private Dictionary<int, decimal> discountLogic =
            new Dictionary<int, decimal>()
            {
                { 1 , 1.00m },
                { 2 , 0.95m },
                { 3 , 0.90m },
                { 4 , 0.80m },
                { 5 , 0.75m }

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
                    result += GetDiscount(groupBookList) * groupBookList.Sum(x => x.Price);
                }
            }
            return result;
        }

        private decimal GetDiscount(List<PotterBook> bookList)
        {
            return discountLogic[bookList.Count()];
        }
    }
}