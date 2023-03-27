using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOh.Model;
using YuGiOh.Repository;

namespace YuGiOh.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private List<BasicCard> _cards;
        public List<BasicCard> Cards { 
            get {  return _cards; } 
            set { 
                _cards = value; 
                OnPropertyChanged(nameof(Cards));
            }
        }

        public ICardsRepository CardsApiRepository { get; set; } = new CardsApiRepository();

        public MainViewModel()
        {
            GetCardsRemote();
        }

        private async void GetCardsRemote()
        {
            Cards = await CardsApiRepository.GetCardsAsync();
        }
    }
}
