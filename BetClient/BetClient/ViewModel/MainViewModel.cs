using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
			SelectionChangedCommand = new RelayCommand<IList>(OnSelectionChanged);
		}

	
		public MainModel MainModel { get; set; }

		public ICommand ExitCommand { get; set; }
		public ICommand OpenBrowserCommand { get; set; }
		public ICommand UpdateCommand { get; set; }
		public ICommand SelectionChangedCommand { get; set; }

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

		private void OnUpdateCommand()
		{
			MainModel.GetForks();
		}

		private void OnSelectionChanged(IList selectedFork )
		{
			if (selectedFork.Count != 0)
				MainModel.SelectedFork = selectedFork.Cast<forks>().First();
		}

	}
}