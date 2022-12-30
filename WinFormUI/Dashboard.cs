using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Dashboard : Form
    {
        ShoppingCartModel cart = new ShoppingCartModel();

        public Dashboard()
        {
            InitializeComponent();
            PopulateCartWithDemoData();
        }

        private void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }

        private void messageBoxDemoButton_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal(SubTotalAlert, CalculateLevedDiscount, PrintOutDiscountAlert);

            MessageBox.Show($"The total is {total:C2}");
        }

        private void textBoxDemoButton_Click(object sender, EventArgs e)
        {
            decimal total = cart.GenerateTotal((subtotal) => subTotalTextBox.Text = $"${subtotal}",
                (Items, subtotal) => subtotal * 0.5M,
                (message) => MessageBox.Show(message));

            string stringTotal = total.ToString();
            totalTextBox.Text = $"${stringTotal}";
        }

        private void PrintOutDiscountAlert(string message)
        {
            MessageBox.Show(message);
        }

        private void SubTotalAlert(decimal subTotal)
        {
            MessageBox.Show($"The subtotal is {subTotal:C2}");
        }

        private decimal CalculateLevedDiscount(List<ProductModel> products, decimal subTotal)
        {
            return subTotal - products.Count();
        }
    }
}
