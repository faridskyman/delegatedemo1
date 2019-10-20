using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateclasslib
{
    public class ShoppingCartModel
    {
        //declare a delegate
        public delegate void MentionDiscount(decimal subtotal);

        public List<ProductModel> Items { get; set; } = new List<ProductModel>();

        public decimal GenerateTotal(MentionDiscount mentionDiscount)
        {
            decimal subtotal = Items.Sum(x => x.Price);
            decimal returnVal;

            mentionDiscount(subtotal);

            if (subtotal > 100)
                returnVal = subtotal * 0.8M;
            else if (subtotal > 50)
                returnVal = subtotal * 0.85M;
            else if (subtotal > 10)
                returnVal = subtotal * 0.9M;
            else
                returnVal = subtotal;

            mentionDiscount(subtotal - returnVal);

            return returnVal;
        }
    }
}
