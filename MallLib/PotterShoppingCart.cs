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

        public decimal Check(List<Book> stubBooks)
        {
            decimal totalPrice = stubBooks.Sum(x => x.Price);
            return totalPrice;
        }
    }
}