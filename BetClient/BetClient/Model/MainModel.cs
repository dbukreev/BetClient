using System.Collections.ObjectModel;
using BetClient.Add;
using BetClient.Service;
using EFData;

namespace BetClient.Model
{
	public class MainModel:NotifyPropertyChanged
	{
		public MainModel(IDataService dataService)
		{
			_dataService = dataService;
			GetForks();
		}

		private readonly IDataService _dataService;
		private ObservableCollection<forks> _forks;
		private forks _selectedFork;

		public ObservableCollection<forks> Forks
		{
			get { return _forks; }
			set
			{
				_forks = value;
				OnPropertyChanged("Forks");
			}
		}

		public forks SelectedFork
		{
			get { return _selectedFork; }
			set
			{
				_selectedFork = value;
				OnPropertyChanged("SelectedFork");
			}
		}

		public void GetForks()
		{
			//Forks = _dataService.GetForks();
		}
	}
}