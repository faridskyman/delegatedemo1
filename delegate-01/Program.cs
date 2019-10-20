using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using delegateclasslib;

namespace delegate_01
{
    class Program
    {
        static ShoppingCartModel cart = new ShoppingCartModel();
        static int counter = 0;

        static void Main(string[] args)
        {
            PopulateCartWithItems();
            Console.WriteLine($"Total cost for the items (after discount) {cart.GenerateTotal(SubtotalAlert):C2}");
            Console.ReadLine();
        }

        public static void SubtotalAlert(decimal subtotal)
        {
            counter++;
            if (counter== 1)
                Console.WriteLine($"{counter}: Sub-Total of items is '{subtotal:C2}'");
            else if (counter ==2)
                Console.WriteLine($"{counter}: Discount given '{subtotal:C2}'");
        }

        private static void PopulateCartWithItems()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cherio", Price = 14.90M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.15M });
            cart.Items.Add(new ProductModel { ItemName = "Dragon Fruit", Price = 4.95M });
            cart.Items.Add(new ProductModel { ItemName = "Noodles", Price=1.50M });
        }
    }
}
