using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BetClient.Add;
using BetClient.Model;
using BetInLive.Properties;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace BetClient.ViewModel
{
	public class LoginViewModel : NotifyPropertyChanged
	{
		public LoginViewModel()
		{
			LoginModel = new LoginModel();
			LoginCommand = new RelayCommand<object>(OnLoginCommand);
			Visible = Visibility.Hidden;
		}

		private Visibility _visible;

		public Visibility Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				_visible = value;
				OnPropertyChanged("Visible");
			}
		}

		public LoginModel LoginModel { get; set; }
		public ICommand LoginCommand { get; set; }

		public void OnLoginCommand(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			var login = loginTextBox.Text;

			var passwordBox = values[1] as PasswordBox;
			var password = passwordBox.Password;

			var rememberCheckBox = values[2] as CheckBox;
			var isRemember = rememberCheckBox.IsChecked;

			LoginModel.Login = login;
			LoginModel.Password = password;
			LoginModel.IsRemember = isRemember ?? false;

			if (LoginModel.Login == "user" && LoginModel.Password == "Qazxsw2!")
			{
				if (LoginModel.IsRemember)
				{
					Settings.Default.Login = LoginModel.Login;
					Settings.Default.Password = LoginModel.Password;
					Settings.Default.IsRemember = LoginModel.IsRemember;
					Settings.Default.Save();
				}
				else
				{
					Settings.Default.Login = string.Empty;
					Settings.Default.Password = string.Empty;
					Settings.Default.IsRemember = false;
					Settings.Default.Save();
				}

				LoginModel.IsLogin = true;
				CloseWindow();
			}
			else
			{
				Visible = Visibility.Visible;
			}
			
		}

		public void CloseWindow()
		{
			Messenger.Default.Send(new NotificationMessage(this, "CloseLoginWindow"));
		}
	}
}