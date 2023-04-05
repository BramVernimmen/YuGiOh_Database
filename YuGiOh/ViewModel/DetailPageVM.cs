using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOh.Model;

namespace YuGiOh.ViewModel
{
    internal class DetailPageVM : ObservableObject
    {
		private BasicCard _currentCard;

		public BasicCard CurrentCard
		{
			get { return _currentCard; }
			set { 
				_currentCard = value; 
				OnPropertyChanged(nameof(CurrentCard));
			}
		}


	}
}
