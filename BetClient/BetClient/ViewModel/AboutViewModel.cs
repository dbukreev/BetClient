using System.Windows.Input;
using BetClient.Add;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace BetClient.ViewModel
{
	public class AboutViewModel : NotifyPropertyChanged
	{
		public AboutViewModel()
		{
			OkCommand = new RelayCommand(OnOkCommand);
		}


		public ICommand OkCommand { get; set; }

		public void OnOkCommand()
		{
			CloseWindow();
		}

		public void CloseWindow()
		{
			Messenger.Default.Send(new NotificationMessage(this, "CloseAboutWindow"));
		}
	}
}