using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using BetClient.Model;
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
		}

		public void OnLoaded1(WebBrowser browser)
		{
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
					AuthorizationZenit(browser);
					break;
				}
			}
		}

		public void OnNavigation2(WebBrowser browser)
		{
			BrowserModel.Text2 = browser.Source.AbsoluteUri;
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
						AuthorizationZenit(browser);
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

			((mshtml.HTMLDocument)browser.Document).getElementById("TextBoxLogin").setAttribute("value", "dbukreev");

			((mshtml.HTMLDocument)browser.Document).getElementById("TextBoxPwd").setAttribute("value", "Qazqwerty21");

			((mshtml.HTMLDocument)browser.Document).getElementById("in").click();
		}

		private void AuthorizationMarathon(WebBrowser browser)
		{
			if (browser.Document == null)
				return;

			var inButton = (((mshtml.HTMLDocument)browser.Document)
				.getElementsByTagName("a")
				.OfType<mshtml.IHTMLElement>()
				.FirstOrDefault(_ => _.className == "but-login"));

			if (inButton == null)
				return;

			((mshtml.HTMLDocument)browser.Document).getElementById("auth_login").setAttribute("value", "8017852");

			((mshtml.HTMLDocument)browser.Document).getElementById("auth_login_password").setAttribute("value", "Qazqwerty21");

			inButton.click();
		}

		private void AuthorizationZenit(WebBrowser browser)
		{
			if (browser.Document == null)
				return;

			var inButton = (((mshtml.HTMLDocument) browser.Document).getElementById("auth"));

			if (inButton == null)
				return;

			((mshtml.HTMLDocument)browser.Document).getElementById("ilogin").setAttribute("value", "2817394");

			((mshtml.HTMLDocument)browser.Document).getElementById("password").setAttribute("value", "Qazqwerty21");

			inButton.click();


			//(((mshtml.HTMLDocument)browser.Document).getElementById("gid" + BrowserModel.GameId1)).click();
			(((mshtml.HTMLDocument)browser.Document).getElementById("do")).click();
		}
	}
}