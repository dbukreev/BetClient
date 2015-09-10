﻿using System;
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
			
			if (Settings.Default.IsRemember)
			{
				LoginTextBox.Text = Settings.Default.Login;
				PasswordBox.Password = Settings.Default.Password;
				RememberCheckBox.IsChecked = true;
			}
		}
	}
}
