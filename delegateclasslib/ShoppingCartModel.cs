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

        public decimal GenerateTotal(MentionDiscount mentionDiscount,
            Func<List<ProductModel>, decimal,decimal> calculateDiscountTotal,
            Action<string> informUserApplyDiscount)
        {
            decimal subtotal = Items.Sum(x => x.Price);
            decimal returnVal;
            mentionDiscount(subtotal);

            informUserApplyDiscount("Applying discount...");

            returnVal = calculateDiscountTotal(Items, subtotal);
            
            mentionDiscount(subtotal - returnVal);

            return returnVal;
        }
    }
}
