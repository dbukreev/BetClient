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
			//return _entities.forks.Where(_=>_.plus > 0).OrderByDescending(_=>_.plus).Select(_ => _).ToObservableCollection();
			return _entities.forks.OrderByDescending(_ => _.plus).Select(_ => _).ToObservableCollection();
		}

		public string GetXbetLink(long gameId)
		{
			return _entities.game_names.First(_ => _.game == gameId.ToString()).link;
		}
	}
}