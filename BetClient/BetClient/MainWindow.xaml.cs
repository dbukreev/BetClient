using System;
using System.Diagnostics;
using BetClient.Model;
using BetClient.View;
using Microsoft.Win32;

namespace BetClient
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			var loginWindow = new LoginWindow();
			loginWindow.ShowDialog();
			if (LoginModel.IsLogin == false)
				Environment.Exit(0);
			InitializeComponent();
			SetBrowserEmulationMode();
		}

		public void SetBrowserEmulationMode()
		{
			var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

			if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
				return;
			UInt32 mode = 10000;
			SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, mode);
		}

		private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
		{
			using (var key = Registry.CurrentUser.CreateSubKey(
				String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
				RegistryKeyPermissionCheck.ReadWriteSubTree))
			{
				key.SetValue(appName, (UInt32)value, RegistryValueKind.DWord);
			}
		}
	}
}
