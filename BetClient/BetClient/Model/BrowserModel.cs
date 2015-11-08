using System;
using BetClient.Add;
using BetClient.Service;
using EFData;

namespace BetClient.Model
{
	public class BrowserModel: NotifyPropertyChanged
	{
		public BrowserModel(forks fork, double sum = 1000)
		{
			Fork = fork;

			Sum = sum;
			Site1 = GetFullSiteString(fork.site_1, fork.game_id_1);
			Site2 = GetFullSiteString(fork.site_2, fork.game_id_2);
			Bookie1 = fork.site_1;
			Bookie2 = fork.site_2;
			GameId1 = fork.game_id_1.ToString();
			GameId2 = fork.game_id_2.ToString();
		}

		private string _site1;

		private string _site2;

		private string _text1;

		private string _text2;

		private double _sum;
		private double _sum1;
		private double _sum2;
		private double _winGain1;
		private double _winGain2;
		private double _gain1;
		private double _gain2;
		private double _winPercent1;
		private double _winPercent2;

		public double Sum
		{
			get
			{
				return _sum;
			}
			set
			{
				_sum = value;
				OnPropertyChanged("Sum");
				CalcGain();
			}
		}

		public double Sum1
		{
			get
			{
				return _sum1;
			}
			set
			{
				_sum1 = value;
				OnPropertyChanged("Sum1");
			}
		}

		public double Sum2
		{
			get
			{
				return _sum2;
			}
			set
			{
				_sum2 = value;
				OnPropertyChanged("Sum2");
			}
		}

		public double Gain1
		{
			get
			{
				return _gain1;
			}
			set
			{
				_gain1 = value;
				OnPropertyChanged("Gain1");
			}
		}

		public double Gain2
		{
			get
			{
				return _gain2;
			}
			set
			{
				_gain2 = value;
				OnPropertyChanged("Gain2");
			}
		}

		public double WinGain1
		{
			get
			{
				return _winGain1;
			}
			set
			{
				_winGain1 = value;
				OnPropertyChanged("WinGain1");
			}
		}

		public double WinGain2
		{
			get
			{
				return _winGain2;
			}
			set
			{
				_winGain2 = value;
				OnPropertyChanged("WinGain2");
			}
		}

		public double WinPercent1
		{
			get
			{
				return _winPercent1;
			}
			set
			{
				_winPercent1 = value;
				OnPropertyChanged("WinPercent1");
			}
		}

		public double WinPercent2
		{
			get
			{
				return _winPercent2;
			}
			set
			{
				_winPercent2 = value;
				OnPropertyChanged("WinPercent2");
			}
		}

		public forks Fork { get; set; }

		public string Site1 {
			get
			{
				return _site1;
			}
			set
			{
				_site1 = value;
				OnPropertyChanged("Site1");
			}
		}

		public string Site2
		{
			get
			{
				return _site2;
			}
			set
			{
				_site2 = value;
				OnPropertyChanged("Site2");
			}
		}

		public string Text1
		{
			get
			{
				return _text1;
			}
			set
			{
				_text1 = value;
				OnPropertyChanged("Text1");
			}
		}

		public string Text2
		{
			get
			{
				return _text2;
			}
			set
			{
				_text2 = value;
				OnPropertyChanged("Text2");
			}
		}

		public string Bookie1 { get; set; }

		public string Bookie2 { get; set; }

		public string GameId1 { get; set; }

		public string GameId2 { get; set; }

		private string GetFullSiteString(string site, int gameId)
		{
			var dataService = new DataService();
			switch (site)
			{
				case "marathon":
					return @"https://www.betmarathon.com/su/live/" + string.Format("{0}?openedMarkets={0}", gameId);
				case "zenit":
					return @"https://zenitbet.com/line/live/#gid" + string.Format("{0}", gameId);
				case "baltbet":
					return @"http://www.baltbet.ru/Line1.aspx?game=" + string.Format("{0}", gameId);
				case "xbet":
					return dataService.GetXbetLink(gameId);
				case "fonbet":
					return @"https://live.fonbet.com/?locale=ru#" + string.Format("{0}", gameId);
				default:
					return @"http://www.google.ru/";
			}
		}

		public void CalcGain()
		{
			var marga = (Fork.k_1 + Fork.k_2) / (Fork.k_1 * Fork.k_2);
			var commonGain = Sum / marga;
			Sum1 = Math.Round(commonGain / Fork.k_1, 2, MidpointRounding.AwayFromZero);
			Sum2 = Math.Round(commonGain / Fork.k_2, 2, MidpointRounding.AwayFromZero);
			Gain1 = Math.Round(Fork.k_1 * Sum1, 2, MidpointRounding.AwayFromZero);
			Gain2 = Math.Round(Fork.k_2 * Sum2, 2, MidpointRounding.AwayFromZero);
			WinGain1 = Math.Round(Gain1 - Sum, 2, MidpointRounding.AwayFromZero);
			WinGain2 = Math.Round(Gain2 - Sum, 2, MidpointRounding.AwayFromZero);
			WinPercent1 = Math.Round(Gain1 * 100 / Sum - 100, 2, MidpointRounding.AwayFromZero);
			WinPercent2 = Math.Round(Gain2 * 100 / Sum - 100, 2, MidpointRounding.AwayFromZero);
		}

		//public void CalcGainBySum1()
		//{
		//	var commonGain = Math.Round(Sum1 * Fork.k_1, 2, MidpointRounding.AwayFromZero);
		//	Sum2 = Math.Round(commonGain / Fork.k_2, 2, MidpointRounding.AwayFromZero);
		//	Sum = Sum1 + Sum2;
		//	Gain1 = Math.Round(Fork.k_1 * Sum1, 2, MidpointRounding.AwayFromZero);
		//	Gain2 = Math.Round(Fork.k_2 * Sum2, 2, MidpointRounding.AwayFromZero);
		//	WinGain1 = Math.Round(Gain1 - Sum1, 2, MidpointRounding.AwayFromZero);
		//	WinGain2 = Math.Round(Gain2 - Sum2, 2, MidpointRounding.AwayFromZero);
		//	WinPercent1 = Math.Round(Gain1 * 100 / Sum - 100, 2, MidpointRounding.AwayFromZero);
		//	WinPercent2 = Math.Round(Gain2 * 100 / Sum - 100, 2, MidpointRounding.AwayFromZero);
		//}
	}
}