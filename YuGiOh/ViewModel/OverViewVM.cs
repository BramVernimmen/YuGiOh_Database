using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOh.Model;
using YuGiOh.Repository;

namespace YuGiOh.ViewModel
{
    internal class OverViewVM : ObservableObject
    {
        private List<BasicCard> _cards;
        public List<BasicCard> Cards
        {
            get { return _cards; }
            set
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }


        private List<string> _cardTypes;
        public List<string> CardTypes {
            get { return _cardTypes; }
            set
            {
                _cardTypes = value;
                OnPropertyChanged(nameof(CardTypes));
            }
        }

        private string _selectedType;
        public string SelectedType
        { 
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                GetCardsOfTypeAsync();
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        private async void GetCardsOfTypeAsync()
        {
            Cards = await CardsApiRepository.GetCardsOfType(SelectedType);
        }



        public ICardsRepository CardsApiRepository { get; set; } = new CardsApiRepository();


        public OverViewVM()
        {
            GetCardsRemote();
        }

        private async void GetCardsRemote()
        {
            Cards = await CardsApiRepository.GetCardsAsync();
            CardTypes = await CardsApiRepository.GetCardTypes();
            SelectedType = "Select Type";

        }
    }
}
