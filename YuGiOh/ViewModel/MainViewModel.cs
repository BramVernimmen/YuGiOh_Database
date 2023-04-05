using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using YuGiOh.Model;
using YuGiOh.Repository;
using YuGiOh.View;

namespace YuGiOh.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public DetailPage DetailPage = new DetailPage();

        public OverViewPage MainPage = new OverViewPage();

        private Page _currentPage;

        public Page CurrentPage { 
            get { return _currentPage; } 
            set { 
                _currentPage = value; 
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public MainViewModel()
        {
            CurrentPage = MainPage;
        }

        public void SwitchToDetail(BasicCard card)
        {
            (DetailPage.DataContext as DetailPageVM).CurrentCard = card;
            CurrentPage = DetailPage;
        }

        public void SwitchToOverview()
        {
            CurrentPage = MainPage;
        }
        
    }
}
