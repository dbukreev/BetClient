using System.Collections.ObjectModel;
using System.Linq;
using BetClient.Service.Extensions;
using EFData;

namespace BetClient.Service
{
	public class DataService: IDataService
	{
		private readonly ForksEntities _entities;

		public DataService()
		{
			_entities = new ForksEntities();
		}

		public ObservableCollection<forks> GetForks()
		{
			//return _entities.forks.Where(_=>_.plus > 0).Select(_ => _).ToObservableCollection();
			return _entities.forks.Select(_ => _).ToObservableCollection();
		}
	}
}