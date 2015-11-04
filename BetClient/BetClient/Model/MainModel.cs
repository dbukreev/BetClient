using System;
using System.Collections.ObjectModel;
using System.Threading;
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
		private DateTime _currentTime;

		public ObservableCollection<forks> Forks
		{
			get { return _forks; }
			set
			{
				_forks = value;
				OnPropertyChanged("Forks");
			}
		}

		public DateTime CurrentTime
		{
			get
			{
				return _currentTime;
				
			}
			set
			{
				_currentTime = value;
				OnPropertyChanged("CurrentTime");
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
			Action act = GetForksAsync;
			act.BeginInvoke(null, null);
		}

		public void GetForksAsync()
		{
			while (true)
			{
				Forks = _dataService.GetForks();
				CurrentTime = DateTime.Now;
				Thread.Sleep(2000);
			}
		}
	}
}