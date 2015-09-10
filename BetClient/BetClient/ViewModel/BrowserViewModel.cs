using BetClient.Model;
using EFData;
using GalaSoft.MvvmLight;

namespace BetClient.ViewModel
{
	public class BrowserViewModel:ViewModelBase
	{
		public BrowserViewModel(forks fork)
		{
			BrowserModel = new BrowserModel(fork);
		}

		public BrowserModel BrowserModel { get; set; }
	}
}