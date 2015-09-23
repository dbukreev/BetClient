using System.Windows.Input;
using EFData;

namespace BetClient.Model
{
	public class BrowserModel
	{
		public BrowserModel(forks fork)
		{
			Site1 = GetFullSiteString(fork.site_1, fork.game_id_1);
			Site2 = GetFullSiteString(fork.site_2, fork.game_id_2);
			Сoefficient1 = fork.k_1;
			Сoefficient2 = fork.k_2;
		}

		public string Site1 { get; set; }
		public string Site2 { get; set; }

		public double Сoefficient1 { get; set; }
		public double Сoefficient2 { get; set; }

		private string GetFullSiteString(string site, int gameId)
		{
			switch (site)
			{
				case "marathon":
					return @"https://www.betmarathon.com/su/live/" + string.Format("{0}?openedMarkets={0}", gameId);
				case "zenit":
					return @"https://zenitbet.com/line/live/#gid" + string.Format("{0}", gameId);
				case "baltbet":
					return @"http://www.baltbet.ru/Line1.aspx?game=" + string.Format("{0}", gameId);
				default:
					return @"http://www.google.ru/";
			}
		}
	}
}