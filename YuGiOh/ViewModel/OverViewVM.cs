using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
                GetFilteredCardsAsync();
                OnPropertyChanged(nameof(SelectedType));
            }
        }

       


        private List<string> _archeTypes;
        public List<string> ArcheTypes
        {
            get { return _archeTypes; }
            set
            {
                _archeTypes = value;
                OnPropertyChanged(nameof(ArcheTypes));
            }
        }

        private string _selectedArcheType;
        public string SelectedArcheType
        {
            get { return _selectedArcheType; }
            set
            {
                _selectedArcheType = value;
                GetFilteredCardsAsync();
                OnPropertyChanged(nameof(SelectedArcheType));
            }
        }




        private async void GetFilteredCardsAsync()
        {
            var cardsTypes = await CardsApiRepository.GetCardsOfType(SelectedType);
            var cardsArcheTypes = await CardsApiRepository.GetCardsFromArcheType(SelectedArcheType);

            Cards = cardsTypes.Intersect(cardsArcheTypes).ToList();
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
            ArcheTypes = await CardsApiRepository.GetArcheTypes();

            // first set the fields
            _selectedType = "Select Type";
            _selectedArcheType = "Select Archetype";

            // then set the props
            SelectedType = "Select Type";
            SelectedArcheType = "Select Archetype";
            // setting these will call a function
            // that function uses the fields as filter
            // if we hadn't set the fields first, null errors will be given

        }
    }
}
