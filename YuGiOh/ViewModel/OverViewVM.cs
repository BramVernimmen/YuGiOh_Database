using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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


        private BasicCard _selectedCard;

        public BasicCard SelectedCard
        {
            get { return _selectedCard; }
            set { _selectedCard = value; }
        }


        #region ------------- FILTERS -----------------------------------

        

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

        #endregion


        private async void GetFilteredCardsAsync()
        {
            var cardsTypes = await CardsRepository.GetCardsOfType(SelectedType);
            var cardsArcheTypes = await CardsRepository.GetCardsFromArcheType(SelectedArcheType);

            Cards = cardsTypes.Intersect(cardsArcheTypes).ToList();
        }


        // create 2 new ones at startup so we don't have to recreate them
        private CardsApiRepository _remoteRepos = new CardsApiRepository();
        private CardsLocalRepository _localRepos = new CardsLocalRepository(); 

        public ICardsRepository CardsRepository { get; set; }









        private string _switchButtonText;

        public string SwitchButtonText
        {
            get { return _switchButtonText; }
            set { 
                _switchButtonText = value;
                OnPropertyChanged(nameof(SwitchButtonText));
            }
        }

        public RelayCommand SwitchRepositoryCommand { get; private set; }





        public OverViewVM()
        {
            CardsRepository = _remoteRepos;
            SwitchRepositoryCommand = new RelayCommand(SwitchRepository);
            GetCardsAsync();
            SwitchButtonText = "Currently Online";

        }





        private async void GetCardsAsync()
        {
            Cards = await CardsRepository.GetCardsAsync();
            CardTypes = await CardsRepository.GetCardTypes();
            ArcheTypes = await CardsRepository.GetArcheTypes();

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

        

        void SwitchRepository()
        {
            if (CardsRepository.GetType() == typeof(CardsApiRepository))
            {
                // switch to offline
                CardsRepository = _localRepos;
                GetCardsAsync();
                SwitchButtonText = "Currently Offline";
            }
            else
            {
                // switch to online
                CardsRepository = _remoteRepos;
                GetCardsAsync();
                SwitchButtonText = "Currently Online";
            }

            

        }

    }
}
