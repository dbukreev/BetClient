using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using BetClient.Model;
using GalaSoft.MvvmLight.CommandWpf;

namespace BetClient.ViewModel
{
	public class LoginViewModel:INotifyPropertyChanged
	{
		public LoginViewModel()
		{
			LoginModel = new LoginModel();
			LoginCommand = new RelayCommand<object>(OnLoginCommand);
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
				NotifyPropertyChanged("DialogResult");
			}
		}

		public LoginModel LoginModel { get; set; }
		public ICommand LoginCommand { get; set; }

		public void OnLoginCommand(object parameter)
		{
			var passwordBox = parameter as PasswordBox;
			var password = passwordBox.Password;
			LoginModel.Password = password;

			if (LoginModel.Login == "user" && LoginModel.Password == "Qazxsw2!")
			{
				LoginModel.IsLogin = true;
				DialogResult = true;
			}
			
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void NotifyPropertyChanged(String info)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}
	}
}