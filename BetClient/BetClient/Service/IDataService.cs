using System.Collections.ObjectModel;
using EFData;

namespace BetClient.Service
{
	public interface IDataService
	{
		ObservableCollection<forks> GetForks();
	}
}