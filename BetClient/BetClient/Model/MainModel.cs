using System.Collections.ObjectModel;
using BetClient.Service;
using EFData;

namespace BetClient.Model
{
	public class MainModel
	{
		public MainModel(IDataService dataService)
		{
			_dataService = dataService;
			GetForks();
		}

		private readonly IDataService _dataService;
		public ObservableCollection<forks> Forks { get; set; }

		public void GetForks()
		{
			Forks = _dataService.GetForks();
		}
	}
}