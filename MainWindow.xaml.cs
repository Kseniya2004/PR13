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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PR13.Classes;


namespace PR13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectHelper.pricies.Add(new PRICE("Пельмени", "Магнит", 199.90, 50));
            ConnectHelper.pricies.Add(new PRICE("Нагетсы", "Пятёрочка", 139.90, 64));
            ConnectHelper.pricies.Add(new PRICE("Колбаса в/к", "Чижик", 356.90, 14));
            ConnectHelper.pricies.Add(new PRICE("Яйца", "Светофор", 60.01, 1));
            ConnectHelper.pricies.Add(new PRICE("Московский картофель", "FixPrice", 50.00, 0));
            ConnectHelper.pricies.Add(new PRICE("Батон", "Дикси", 20.90, 86));
            ConnectHelper.pricies.Add(new PRICE("Творожок", "Чижик", 55.01, 46));
            ConnectHelper.pricies.Add(new PRICE("Йогурт", "Пятёрочка", 35.00, 35));

            DtgListPreparate.ItemsSource = ConnectHelper.pricies;
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.pricies.ToList();
            DtgListPreparate.SelectedIndex = -1;
        }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.pricies.OrderBy(x => x.Name).ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.pricies.OrderByDescending(x => x.Name).ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DtgListPreparate.ItemsSource = ConnectHelper.pricies.Where(x =>
                x.Name.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbFiltr.SelectedIndex == 0)
            {
                DtgListPreparate.ItemsSource = ConnectHelper.pricies.Where(x =>
                    x.Amount >= 0 && x.Amount <= 10).ToList();
                MessageBox.Show("Недостаточное количество препаратов на складе!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                if (CmbFiltr.SelectedIndex == 1)
            {
                DtgListPreparate.ItemsSource = ConnectHelper.pricies.Where(x =>
                    x.Amount >= 11 && x.Amount <= 50).ToList();
                MessageBox.Show("Необходимо пополнить запасы препаратов в ближайшее время",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DtgListPreparate.ItemsSource = ConnectHelper.pricies.Where(x =>
                   x.Amount >= 51).ToList();
                MessageBox.Show("Достаточное количество препаратов на складе!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPrice windowAdd = new WindowAddPrice();
            windowAdd.ShowDialog();
        }      

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DtgListPreparate.ItemsSource = null;
        }
    }
}
