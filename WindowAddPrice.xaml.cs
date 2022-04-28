using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PR13.Classes;

namespace PR13
{
    /// <summary>
    /// Логика взаимодействия для WindowAddPrice.xaml
    /// </summary>
    public partial class WindowAddPrice : Window
    {
        public WindowAddPrice()
        {
            InitializeComponent();
        }

        private void BtnAddPrice_Click(object sender, RoutedEventArgs e)
        {
            PRICE pharmacy = new PRICE()
            {
                Name = TxbName.Text,
                Shop = TxbShop.Text,
                Price = double.Parse(TxbPrice.Text),
                Amount = int.Parse(TxbAmount.Text)
            };
            ConnectHelper.pricies.Add(pharmacy);
            this.Close();
        }
    }
}
