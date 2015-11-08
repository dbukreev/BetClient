using BetClient.Properties;
using GalaSoft.MvvmLight.Messaging;

namespace BetClient.View
{
	/// <summary>
	/// Логика взаимодействия для BookieSettingsWindow.xaml
	/// </summary>
	public partial class BookieSettingsWindow 
	{
		public BookieSettingsWindow()
		{
			InitializeComponent();
			Messenger.Default.Register<NotificationMessage>(this, (nm) =>
			{
				if (nm.Notification == "CloseBookieSettingsWindow")
				{
					if (nm.Sender == this.DataContext)
						this.Close();
				}
			});

			InitializeBookies();
		}

		public void InitializeBookies()
		{
			LoginTextBoxBaltbet.Text = Settings.Default.BaltbetLogin;
			PasswordBoxBaltbet.Password = Settings.Default.BaltbetPassword;
			AutoLoginCheckBoxBaltbet.IsChecked = Settings.Default.BaltbetIsAutoLogin;

			LoginTextBoxFonbet.Text = Settings.Default.FonbetLogin;
			PasswordBoxFonbet.Password = Settings.Default.FonbetPassword;
			AutoLoginCheckBoxFonbet.IsChecked = Settings.Default.FonbetIsAutoLogin;

			LoginTextBoxMarathon.Text = Settings.Default.MarathonLogin;
			PasswordBoxMarathon.Password = Settings.Default.MarathonPassword;
			AutoLoginCheckBoxMarathon.IsChecked = Settings.Default.MarathonIsAutoLogin;

			LoginTextBoxXbet.Text = Settings.Default.XbetLogin;
			PasswordBoxXbet.Password = Settings.Default.XbetPassword;
			AutoLoginCheckBoxXbet.IsChecked = Settings.Default.XbetIsAutoLogin;

			LoginTextBoxZenit.Text = Settings.Default.ZenitLogin;
			PasswordBoxZenit.Password = Settings.Default.ZenitPassword;
			AutoLoginCheckBoxZenit.IsChecked = Settings.Default.ZenitIsAutoLogin;
		}
	}
}
