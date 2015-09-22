using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BetClient.Properties;
using GalaSoft.MvvmLight.Messaging;

namespace BetClient.View
{
	/// <summary>
	/// Логика взаимодействия для LoginWindow.xaml
	/// </summary>
	public partial class AboutWindow 
	{
		public AboutWindow()
		{
			InitializeComponent();
			Messenger.Default.Register<NotificationMessage>(this, (nm) =>
			{
				if (nm.Notification == "CloseAboutWindow")
				{
					if (nm.Sender == this.DataContext)
						this.Close();
				}
			});
		}
	}
}
