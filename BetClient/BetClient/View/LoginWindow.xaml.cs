using BetInLive.Properties;
using GalaSoft.MvvmLight.Messaging;

namespace BetClient.View
{
	/// <summary>
	/// Логика взаимодействия для LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow 
	{
		public LoginWindow()
		{
			InitializeComponent();
			Messenger.Default.Register<NotificationMessage>(this, (nm) =>
			{
				if (nm.Notification == "CloseLoginWindow")
				{
					if (nm.Sender == this.DataContext)
						this.Close();
				}
			});

			if (Settings.Default.IsRemember)
			{
				LoginTextBox.Text = Settings.Default.Login;
				PasswordBox.Password = Settings.Default.Password;
				RememberCheckBox.IsChecked = true;
			}
		}
	}
}
