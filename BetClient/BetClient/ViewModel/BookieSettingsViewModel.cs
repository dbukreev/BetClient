using System.Windows.Controls;
using System.Windows.Input;
using BetInLive.Properties;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace BetClient.ViewModel
{
	public class BookieSettingsViewModel: ViewModelBase
	{
		public BookieSettingsViewModel()
		{
			SaveCommandBaltbet = new RelayCommand<object>(OnSaveCommandBaltbet);
			ClearCommandBaltbet = new RelayCommand<object>(OnClearCommandBaltbet);
			SaveCommandFonbet = new RelayCommand<object>(OnSaveCommandFonbet);
			ClearCommandFonbet = new RelayCommand<object>(OnClearCommandFonbet);
			SaveCommandMarathon = new RelayCommand<object>(OnSaveCommandMarathon);
			ClearCommandMarathon = new RelayCommand<object>(OnClearCommandMarathon);
			SaveCommandXbet = new RelayCommand<object>(OnSaveCommandXbet);
			ClearCommandXbet = new RelayCommand<object>(OnClearCommandXbet);
			SaveCommandZenit = new RelayCommand<object>(OnSaveCommandZenit);
			ClearCommandZenit = new RelayCommand<object>(OnClearCommandZenit);

			OkCommand = new RelayCommand(OnOkCommand);

			BaltbetMessage = string.Empty;
			FonbetMessage = string.Empty;
			MarathonMessage = string.Empty;
			XbetMessage = string.Empty;
			ZenitMessage = string.Empty;
		}

		private string _baltbetMessage;
		private string _fonbetMessage;
		private string _marathonMessage;
		private string _xbetMessage;
		private string _zenitMessage;

		public string BaltbetMessage
		{
			get
			{
				return _baltbetMessage;
			}
			set
			{
				_baltbetMessage = value;
				RaisePropertyChanged();
			}
		}

		public string FonbetMessage
		{
			get
			{
				return _fonbetMessage;
			}
			set
			{
				_fonbetMessage = value;
				RaisePropertyChanged();
			}
		}

		public string MarathonMessage
		{
			get
			{
				return _marathonMessage;
			}
			set
			{
				_marathonMessage = value;
				RaisePropertyChanged();
			}
		}

		public string XbetMessage
		{
			get
			{
				return _xbetMessage;
			}
			set
			{
				_xbetMessage = value;
				RaisePropertyChanged();
			}
		}

		public string ZenitMessage
		{
			get
			{
				return _zenitMessage;
			}
			set
			{
				_zenitMessage = value;
				RaisePropertyChanged();
			}
		}

		public ICommand SaveCommandBaltbet { get; set; }

		public ICommand ClearCommandBaltbet { get; set; }

		public ICommand SaveCommandFonbet { get; set; }

		public ICommand ClearCommandFonbet { get; set; }

		public ICommand SaveCommandMarathon { get; set; }

		public ICommand ClearCommandMarathon { get; set; }

		public ICommand SaveCommandXbet{ get; set; }
									
		public ICommand ClearCommandXbet { get; set; }

		public ICommand SaveCommandZenit { get; set; }

		public ICommand ClearCommandZenit{ get; set; }

		public ICommand OkCommand { get; set; }

		public void OnOkCommand()
		{
			CloseWindow();
		}

		public void OnSaveCommandBaltbet(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			var login = loginTextBox.Text;

			var passwordBox = values[1] as PasswordBox;
			var password = passwordBox.Password;

			var autoLoginCheckBox = values[2] as CheckBox;
			var isAutoLogin = autoLoginCheckBox.IsChecked.Value;

			Settings.Default.BaltbetLogin = login;
			Settings.Default.BaltbetPassword = password;
			Settings.Default.BaltbetIsAutoLogin = isAutoLogin;
			Settings.Default.Save();

			BaltbetMessage = "Данные сохранены";
		}

		public void OnClearCommandBaltbet(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			loginTextBox.Text = string.Empty;

			var passwordBox = values[1] as PasswordBox;
			passwordBox.Password = string.Empty;

			var autoLoginCheckBox = values[2] as CheckBox;
			autoLoginCheckBox.IsChecked = false;

			Settings.Default.BaltbetLogin = string.Empty;
			Settings.Default.BaltbetPassword = string.Empty;
			Settings.Default.BaltbetIsAutoLogin = false;
			Settings.Default.Save();

			BaltbetMessage = "Данные очищены";
		}

		public void OnSaveCommandFonbet(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			var login = loginTextBox.Text;

			var passwordBox = values[1] as PasswordBox;
			var password = passwordBox.Password;

			var autoLoginCheckBox = values[2] as CheckBox;
			var isAutoLogin = autoLoginCheckBox.IsChecked.Value;

			Settings.Default.FonbetLogin = login;
			Settings.Default.FonbetPassword = password;
			Settings.Default.FonbetIsAutoLogin = isAutoLogin;
			Settings.Default.Save();

			FonbetMessage = "Данные сохранены";
		}

		public void OnClearCommandFonbet(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			loginTextBox.Text = string.Empty;

			var passwordBox = values[1] as PasswordBox;
			passwordBox.Password = string.Empty;

			var autoLoginCheckBox = values[2] as CheckBox;
			autoLoginCheckBox.IsChecked = false;

			Settings.Default.FonbetLogin = string.Empty;
			Settings.Default.FonbetPassword = string.Empty;
			Settings.Default.FonbetIsAutoLogin = false;
			Settings.Default.Save();

			FonbetMessage = "Данные очищены";
		}

		public void OnSaveCommandMarathon(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			var login = loginTextBox.Text;

			var passwordBox = values[1] as PasswordBox;
			var password = passwordBox.Password;

			var autoLoginCheckBox = values[2] as CheckBox;
			var isAutoLogin = autoLoginCheckBox.IsChecked.Value;

			Settings.Default.MarathonLogin = login;
			Settings.Default.MarathonPassword = password;
			Settings.Default.MarathonIsAutoLogin = isAutoLogin;
			Settings.Default.Save();

			MarathonMessage = "Данные сохранены";
		}

		public void OnClearCommandMarathon(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			loginTextBox.Text = string.Empty;

			var passwordBox = values[1] as PasswordBox;
			passwordBox.Password = string.Empty;

			var autoLoginCheckBox = values[2] as CheckBox;
			autoLoginCheckBox.IsChecked = false;

			Settings.Default.MarathonLogin = string.Empty;
			Settings.Default.MarathonPassword = string.Empty;
			Settings.Default.MarathonIsAutoLogin = false;
			Settings.Default.Save();

			MarathonMessage = "Данные очищены";
		}

		public void OnSaveCommandXbet(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			var login = loginTextBox.Text;

			var passwordBox = values[1] as PasswordBox;
			var password = passwordBox.Password;

			var autoLoginCheckBox = values[2] as CheckBox;
			var isAutoLogin = autoLoginCheckBox.IsChecked.Value;

			Settings.Default.XbetLogin = login;
			Settings.Default.XbetPassword = password;
			Settings.Default.XbetIsAutoLogin = isAutoLogin;
			Settings.Default.Save();

			XbetMessage = "Данные сохранены";
		}

		public void OnClearCommandXbet(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			loginTextBox.Text = string.Empty;

			var passwordBox = values[1] as PasswordBox;
			passwordBox.Password = string.Empty;

			var autoLoginCheckBox = values[2] as CheckBox;
			autoLoginCheckBox.IsChecked = false;

			Settings.Default.XbetLogin = string.Empty;
			Settings.Default.XbetPassword = string.Empty;
			Settings.Default.XbetIsAutoLogin = false;
			Settings.Default.Save();

			XbetMessage = "Данные очищены";
		}

		public void OnSaveCommandZenit(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			var login = loginTextBox.Text;

			var passwordBox = values[1] as PasswordBox;
			var password = passwordBox.Password;

			var autoLoginCheckBox = values[2] as CheckBox;
			var isAutoLogin = autoLoginCheckBox.IsChecked.Value;

			Settings.Default.ZenitLogin = login;
			Settings.Default.ZenitPassword = password;
			Settings.Default.ZenitIsAutoLogin = isAutoLogin;
			Settings.Default.Save();

			ZenitMessage = "Данные сохранены";
		}

		public void OnClearCommandZenit(object parameter)
		{
			var values = (object[])parameter;

			var loginTextBox = values[0] as TextBox;
			loginTextBox.Text = string.Empty;

			var passwordBox = values[1] as PasswordBox;
			passwordBox.Password = string.Empty;

			var autoLoginCheckBox = values[2] as CheckBox;
			autoLoginCheckBox.IsChecked = false;

			Settings.Default.ZenitLogin = string.Empty;
			Settings.Default.ZenitPassword = string.Empty;
			Settings.Default.ZenitIsAutoLogin = false;
			Settings.Default.Save();

			ZenitMessage = "Данные очищены";
		}

		public void CloseWindow()
		{
			Messenger.Default.Send(new NotificationMessage(this, "CloseBookieSettingsWindow"));
		}
	}
}