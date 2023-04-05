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
using YuGiOh.ViewModel;

namespace YuGiOh.View
{
    /// <summary>
    /// Interaction logic for DetailPage.xaml
    /// </summary>
    public partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = MainWindow.GetWindow(this).DataContext as MainViewModel;
            vm.SwitchToOverview();
        }

        private void HideButton(object sender, RoutedEventArgs e)
        {
            ImageButton.Visibility = Visibility.Hidden;

            BigImageButton.Visibility = Visibility.Visible;

        }

        private void HideBigImage(object sender, RoutedEventArgs e)
        {
            ImageButton.Visibility = Visibility.Visible;

            BigImageButton.Visibility = Visibility.Collapsed;
        }
    }
}
