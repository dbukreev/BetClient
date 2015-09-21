using System.Windows.Input;
using BetClient.Add;
using BetClient.Model;
using GalaSoft.MvvmLight.CommandWpf;

namespace BetClient.ViewModel
{
	public class AboutViewModel : NotifyPropertyChanged
	{
		public AboutViewModel()
		{
			OkCommand = new RelayCommand(OnOkCommand);
		}

		private bool? _dialogResult;

		public bool? DialogResult 
		{
			get
			{
				return _dialogResult;
			}
			set
			{
				_dialogResult = value;
				OnPropertyChanged("DialogResult");
			}
		}
		public ICommand OkCommand { get; set; }

		public void OnOkCommand()
		{
			DialogResult = true;
		}
	}
}