using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BetClient.Add;
using BetClient.Model;
using BetClient.Properties;
using BetClient.View;
using EFData;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using mshtml;

namespace BetClient.ViewModel
{
	public class BrowserViewModel:ViewModelBase
	{
		public BrowserViewModel(forks fork)
		{
			BrowserModel = new BrowserModel(fork);
			RefreshCommand1 = new RelayCommand<WebBrowser>(OnRefresh1);
			BackCommand1 = new RelayCommand<WebBrowser>(OnBack1);
			ForwardCommand1 = new RelayCommand<WebBrowser>(OnForward1);
			NavigationCommand1 = new RelayCommand<WebBrowser>(OnNavigation1);
			LoadedCommand1 = new RelayCommand<WebBrowser>(OnLoaded1);

			RefreshCommand2 = new RelayCommand<WebBrowser>(OnRefresh2);
			BackCommand2 = new RelayCommand<WebBrowser>(OnBack2);
			ForwardCommand2 = new RelayCommand<WebBrowser>(OnForward2);
			NavigationCommand2 = new RelayCommand<WebBrowser>(OnNavigation2);
			LoadedCommand2 = new RelayCommand<WebBrowser>(OnLoaded2);

			CalcCommand = new RelayCommand(OnCalcCommand);
			AllCommand = new RelayCommand( OnAllVisibility);
			FirstCommand = new RelayCommand(OnFirstVisibility);
			SecondCommand = new RelayCommand(OnSecondVisibility);
			OnAllVisibility();
		}

		private bool _separetorVisibility;
		private bool _firstVisibility;
		private bool _secondVisibility;

		public bool SeparetorVisibility
		{
			get
			{
				return _separetorVisibility;
			}
			set
			{
				_separetorVisibility = value;
				RaisePropertyChanged();
			}
		}

		public bool FirstVisibility
		{
			get
			{
				return _firstVisibility;
			}
			set
			{
				_firstVisibility = value;
				RaisePropertyChanged();
			}
		}

		public bool SecondVisibility
		{
			get
			{
				return _secondVisibility;
			}
			set
			{
				_secondVisibility = value;
				RaisePropertyChanged();
			}
		}

		public RelayCommand<WebBrowser> BackCommand1 { get; set; }

		public RelayCommand<WebBrowser> ForwardCommand1 { get; set; }

		public RelayCommand<WebBrowser> RefreshCommand1 { get; set; }

		public RelayCommand<WebBrowser> NavigationCommand1 { get; set; }

		public RelayCommand<WebBrowser> LoadedCommand1 { get; set; }

		public RelayCommand<WebBrowser> BackCommand2 { get; set; }

		public RelayCommand<WebBrowser> ForwardCommand2 { get; set; }

		public RelayCommand<WebBrowser> RefreshCommand2 { get; set; }

		public RelayCommand<WebBrowser> NavigationCommand2 { get; set; }

		public RelayCommand<WebBrowser> LoadedCommand2 { get; set; }

		public ICommand CalcCommand { get; set; }

		public ICommand AllCommand { get; set; }

		public ICommand FirstCommand { get; set; }

		public ICommand SecondCommand { get; set; }

		public BrowserModel BrowserModel { get; set; }

		public void OnRefresh1(WebBrowser browser)
		{
			browser.Refresh();
		}

		public void OnBack1(WebBrowser browser)
		{
			if(browser.CanGoBack)
			browser.GoBack();
		}

		public void OnForward1(WebBrowser browser)
		{
			if (browser.CanGoForward)
				browser.GoForward();
		}

		public void OnNavigation1(WebBrowser browser)
		{
			BrowserModel.Text1 = browser.Source.AbsoluteUri;
			//SetSilentClass.SetSilent(browser, true);
			HideScriptErrors(browser, true);
		}

		public void OnLoaded1(WebBrowser browser)
		{
			//HideScriptErrors(browser, true);
			switch (BrowserModel.Bookie1)
			{
				case "baltbet":
				{
					AuthorizationBaltbet(browser);
					break;
				}
				case "marathon":
				{
					AuthorizationMarathon(browser);
					break;
				}
				case "zenit":
				{
					AuthorizationZenit(browser, 1);
					break;
				}
				case "fonbet":
				{
					AuthorizationFonbet(browser);
					break;
				}
				case "xbet":
				{
					AuthorizationXbet(browser);
					break;
				}
			}
		}

		public void OnNavigation2(WebBrowser browser)
		{
			BrowserModel.Text2 = browser.Source.AbsoluteUri;
			HideScriptErrors(browser, true);
			//SetSilentClass.SetSilent(browser, true);
		}

		public void OnRefresh2(WebBrowser browser)
		{
			browser.Refresh();
		}

		public void OnBack2(WebBrowser browser)
		{
			if (browser.CanGoBack)
				browser.GoBack();
		}

		public void OnForward2(WebBrowser browser)
		{
			if (browser.CanGoForward)
				browser.GoForward();
		}

		public void OnLoaded2(WebBrowser browser)
		{
			switch (BrowserModel.Bookie2)
			{
				case "baltbet":
					{
						AuthorizationBaltbet(browser);
						break;
					}
				case "marathon":
					{
						AuthorizationMarathon(browser);
						break;
					}
				case "zenit":
					{
						AuthorizationZenit(browser, 2);
						break;
					}
				case "fonbet":
					{
						AuthorizationFonbet(browser);
						break;
					}
				case "xbet":
					{
						AuthorizationXbet(browser);
						break;
					}
			}
		}

		private void OnCalcCommand()
		{
			var calcWindow = new CalcWindow();
			calcWindow.ShowDialog();
		}

		private void AuthorizationBaltbet(WebBrowser browser)
		{
			if (Settings.Default.BaltbetIsAutoLogin)
			{
					if (browser.Document == null)
				return;
			/*нажимаем кнопку "Войти", для открытия окна авторизации*/

			var inButton = (((mshtml.HTMLDocument)browser.Document)
				.getElementsByTagName("a")
				.OfType<mshtml.IHTMLElement>()
				.FirstOrDefault(_ => _.className == "btn-g-e"));
			if(inButton == null)
				return;

			inButton.click();

			((mshtml.HTMLDocument)browser.Document).getElementById("TextBoxLogin").setAttribute("value", Settings.Default.BaltbetLogin);

			((mshtml.HTMLDocument)browser.Document).getElementById("TextBoxPwd").setAttribute("value", Settings.Default.BaltbetPassword);

			((mshtml.HTMLDocument)browser.Document).getElementById("in").click();
			}
		}

		private void AuthorizationMarathon(WebBrowser browser)
		{
			if (Settings.Default.MarathonIsAutoLogin)
			{
				if (browser.Document == null)
					return;

				var inButton = (((mshtml.HTMLDocument) browser.Document)
					.getElementsByTagName("a")
					.OfType<mshtml.IHTMLElement>()
					.FirstOrDefault(_ => _.className == "but-login"));

				if (inButton == null)
					return;

				((mshtml.HTMLDocument)browser.Document).getElementById("auth_login").setAttribute("value", Settings.Default.MarathonLogin);

				((mshtml.HTMLDocument)browser.Document).getElementById("auth_login_password").setAttribute("value", Settings.Default.MarathonPassword);

				inButton.click();
			}
		}

		private void AuthorizationZenit(WebBrowser browser, int game)
		{
			if (Settings.Default.ZenitIsAutoLogin)
			{
				if (browser.Document == null)
					return;

				var inButton = (((mshtml.HTMLDocument) browser.Document).getElementById("auth"));

				if (inButton != null)
				{
					((mshtml.HTMLDocument) browser.Document).getElementById("ilogin").setAttribute("value", Settings.Default.ZenitLogin);

					((mshtml.HTMLDocument) browser.Document).getElementById("password").setAttribute("value", Settings.Default.ZenitPassword);

					inButton.click();
				}

				var checkbox =
					(((mshtml.HTMLDocument) browser.Document).getElementById("gid" +
					                                                         (game == 1 ? BrowserModel.GameId1 : BrowserModel.GameId2)));
				if (checkbox != null)
				{
					checkbox.click();
					(((mshtml.HTMLDocument) browser.Document).getElementById("do")).click();
				}
			}

		}

		private void AuthorizationFonbet(WebBrowser browser)
		{
			if (Settings.Default.FonbetIsAutoLogin)
			{
				if (browser.Document == null)
					return;

				var inButton = (((mshtml.HTMLDocument) browser.Document).getElementById("loginButtonLogin"));

				if (inButton == null)
					return;

				((mshtml.HTMLDocument)browser.Document).getElementById("editLogin").setAttribute("value", Settings.Default.FonbetLogin);

				((mshtml.HTMLDocument)browser.Document).getElementById("editPassword").setAttribute("value", Settings.Default.FonbetPassword);

				inButton.click();
			}
		}

		private void AuthorizationXbet(WebBrowser browser)
		{
			if (Settings.Default.XbetIsAutoLogin)
			{
				if (browser.Document == null)
					return;

				var inButton = (((mshtml.HTMLDocument) browser.Document)
					.getElementsByTagName("div")
					.OfType<mshtml.IHTMLElement>()
					.FirstOrDefault(_ => _.className == "loginDropTop_con"));
				if (inButton == null)
					return;

				inButton.click();

				((mshtml.HTMLDocument) browser.Document).getElementById("userLogin").setAttribute("value", Settings.Default.XbetLogin);

				((mshtml.HTMLDocument) browser.Document).getElementById("userPassword").setAttribute("value", Settings.Default.XbetPassword);

				((mshtml.HTMLDocument) browser.Document).getElementById("userConButton").click();
			}
		}

		public void HideScriptErrors(WebBrowser wb, bool Hide)
		{
			FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
			if (fiComWebBrowser == null) return;
			object objComWebBrowser = fiComWebBrowser.GetValue(wb);
			if (objComWebBrowser == null) return;
			objComWebBrowser.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
		}

		public void OnAllVisibility()
		{
			FirstVisibility = true;
			SecondVisibility = true;
			SeparetorVisibility = true;
		}

		public void OnFirstVisibility()
		{
			FirstVisibility = true;
			SecondVisibility = false;
			SeparetorVisibility = false;
		}

		public void OnSecondVisibility()
		{
			FirstVisibility = false;
			SecondVisibility = true;
			SeparetorVisibility = false;
		}
	}
}