using System;
using System.Windows.Input;
using BetClient.Model;
using EFData;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace BetClient.ViewModel
{
	public class BrowserViewModel:ViewModelBase
	{
		public BrowserViewModel(forks fork)
		{
			BrowserModel = new BrowserModel(fork);
			RefreshCommand1 = new RelayCommand(OnRefresh1);
			RefreshCommand2 = new RelayCommand(OnRefresh2);
		}

		public ICommand RefreshCommand1 { get; set; }

		public ICommand RefreshCommand2 { get; set; }

		public ICommand BackCommand { get; set; }

		public ICommand ForwardCommand { get; set; }

		public BrowserModel BrowserModel { get; set; }

		public void OnRefresh1()
		{
			var tmp = BrowserModel.Site1;
			BrowserModel.Site1 = String.Empty;
			BrowserModel.Site1 = tmp;
		}

		public void OnRefresh2()
		{
			var tmp = BrowserModel.Site2;
			BrowserModel.Site2 = String.Empty;
			BrowserModel.Site2 = tmp;
		}
	}
}