using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BetClient.Model;
using BetClient.Service;
using BetClient.View;
using EFData;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace BetClient.ViewModel
{
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
			SelectionChangedCommand = new RelayCommand<IList>(OnSelectionChanged);
			AboutCommand = new RelayCommand(OnAboutCommand);
			CalcCommand = new RelayCommand(OnCalcCommand);
		}

	
		public MainModel MainModel { get; set; }

		public ICommand ExitCommand { get; set; }
		public ICommand AboutCommand { get; set; }
		public ICommand OpenBrowserCommand { get; set; }
		public ICommand SelectionChangedCommand { get; set; }

		public ICommand CalcCommand { get; set; }

		private void OnExitCommand()
		{
			Environment.Exit(0);
		}
		private void OnOpenBrowserCommand()
		{
			if (MainModel.SelectedFork == null)
			{
				MessageBox.Show("Не выбрана вилка.");
				return;
			}

			var browserWindow = new BrowserWindow
			{
				DataContext = new BrowserViewModel(MainModel.SelectedFork)
			};
			browserWindow.ShowDialog();
		}

		private void OnSelectionChanged(IList selectedFork )
		{
			if (selectedFork.Count != 0)
				MainModel.SelectedFork = selectedFork.Cast<forks>().First();
		}

		private void OnAboutCommand()
		{
			var aboutWindow = new AboutWindow();
			aboutWindow.ShowDialog();
		}

		private void OnCalcCommand()
		{
			var calcWindow = new CalcWindow();
			calcWindow.ShowDialog();
		}
	}
}