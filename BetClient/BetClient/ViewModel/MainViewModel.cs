using System;
using System.Windows.Input;
using BetClient.Model;
using BetClient.Service;
using BetClient.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace BetClient.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(IDataService dataService)
		{
			MainModel = new MainModel(dataService);
			ExitCommand = new RelayCommand(OnExitCommand);
			OpenBrowserCommand = new RelayCommand(OnOpenBrowserCommand);
			UpdateCommand = new RelayCommand(OnUpdateCommand);
		}
		
		public MainModel MainModel { get; set; }

		public ICommand ExitCommand { get; set; }
		public ICommand OpenBrowserCommand { get; set; }

		public ICommand UpdateCommand { get; set; }

		private void OnExitCommand()
		{
			Environment.Exit(0);
		}
		private void OnOpenBrowserCommand()
		{
			var browserWindow = new BrowserWindow();
			browserWindow.ShowDialog();
		}

		private void OnUpdateCommand()
		{
			MainModel.GetForks();
		}
	}
}