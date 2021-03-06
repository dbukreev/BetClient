using BetClient.Service;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace BetClient.ViewModel
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator
	{
		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<IDataService, DataService>();
			SimpleIoc.Default.Register<MainViewModel>();
			//SimpleIoc.Default.Register<BrowserViewModel>();
			SimpleIoc.Default.Register<LoginViewModel>();
			//SimpleIoc.Default.Register<BookieSettingsViewModel>();
			SimpleIoc.Default.Register<AboutViewModel>();
			SimpleIoc.Default.Register<CalcViewModel>();
		}
		
		public MainViewModel Main
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}

		//public BrowserViewModel Browser
		//{
		//	get
		//	{
		//		return ServiceLocator.Current.GetInstance<BrowserViewModel>();
		//	}
		//}

		public LoginViewModel Login
		{
			get
			{
				return ServiceLocator.Current.GetInstance<LoginViewModel>();
			}
		}

		//public BookieSettingsViewModel BookieSettings
		//{
		//	get
		//	{
		//		return ServiceLocator.Current.GetInstance<BookieSettingsViewModel>();
		//	}
		//}

		public CalcViewModel Calc
		{
			get
			{
				return ServiceLocator.Current.GetInstance<CalcViewModel>();
			}
		}

		public AboutViewModel About
		{
			get
			{
				return ServiceLocator.Current.GetInstance<AboutViewModel>();
			}
		}
	}
}