using System;
using System.ComponentModel;
using System.Windows;
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
			Visible = Visibility.Hidden;
		}

		private bool? _dialogResult;

		private Visibility _visible;

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

		public Visibility Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				_visible = value;
				NotifyPropertyChanged("Visible");
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
			else
			{
				Visible = Visibility.Visible;
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