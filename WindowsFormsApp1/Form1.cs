using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using delegateclasslib;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ShoppingCartModel cart = new ShoppingCartModel();

        public Form1()
        {
            InitializeComponent();
            PopulateCartWithItems();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal((subtotal) => txtSubtotal.Text += $"{subtotal:C2}. ",
                (productlist, subtotal) => subtotal - productlist.Count(),
                (msg) => { }
                );
            txtTotalDisc.Text = $"after discount: ${total:C2}";
        }

        private void PopulateCartWithItems()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cherio", Price = 14.90M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.15M });
            cart.Items.Add(new ProductModel { ItemName = "Dragon Fruit", Price = 4.95M });
            cart.Items.Add(new ProductModel { ItemName = "Noodles", Price = 1.50M });
        }
    }
}
