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
            decimal totalPrice;
            if (books.Count == 1)
            {
                totalPrice = books.Sum(x => x.Price);                
            }
            else
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
            return totalPrice;
        }
    }
}