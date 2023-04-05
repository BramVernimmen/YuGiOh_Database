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
using YuGiOh.Model;
using YuGiOh.ViewModel;

namespace YuGiOh.View
{
    /// <summary>
    /// Interaction logic for OverViewPage.xaml
    /// </summary>
    public partial class OverViewPage : Page
    {
        public OverViewPage()
        {
            InitializeComponent();
        }

        private void Check_Details(object sender, RoutedEventArgs e)
        {

            BasicCard card = (this.DataContext as OverViewVM).SelectedCard;

            if (card == null)
                return;

            MainViewModel vm = MainWindow.GetWindow(this).DataContext as MainViewModel;
            vm.SwitchToDetail(card);
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Check_Details(sender, e);
        }
    }
}
