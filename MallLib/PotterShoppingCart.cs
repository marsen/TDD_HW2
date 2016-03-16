using System.Collections.Generic;
using System.Linq;

namespace MallLib
{
    /// <summary>
    /// PotterShoppingCart
    /// </summary>
    public class PotterShoppingCart
    {
        /// <summary>
        /// 折扣表
        /// </summary>
        private Dictionary<int, decimal> discountLogic =
            new Dictionary<int, decimal>() { { 1, 1.00m }, { 2, 0.95m }, { 3, 0.90m }, { 4, 0.80m }, { 5, 0.75m } };

        /// <summary>
        /// Initializes a new instance of the <see cref="PotterShoppingCart" /> class.
        /// </summary>
        public PotterShoppingCart()
        {
        }

        /// <summary>
        /// Check
        /// </summary>
        /// <param name="books">book list in cart</param>
        /// <returns>best price</returns>
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
                    result += this.GetDiscount(groupBookList) * groupBookList.Sum(x => x.Price);
                }
            }

            return result;
        }

        /// <summary>
        /// GetDiscount
        /// </summary>
        /// <param name="bookList">book</param>
        /// <returns>price after discount</returns>
        private decimal GetDiscount(List<PotterBook> bookList)
        {
            return this.discountLogic[bookList.Count()];
        }
    }
}