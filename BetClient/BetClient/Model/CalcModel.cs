using System;
using BetClient.Add;

namespace BetClient.Model
{
	public class CalcModel : NotifyPropertyChanged
	{
		public CalcModel(double koef1 = 2, double koef2 = 2, double sum = 100)
		{
			Koef1 = koef1;
			Koef2 = koef2;
			Sum = sum;
			CalcGain();
		}

		private double _sum;
		private double _sum1;
		private double _sum2;
		private double _koef1;
		private double _koef2;
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

		public double Koef1
		{
			get
			{
				return _koef1;
			}
			set
			{
				_koef1 = value;
				OnPropertyChanged("Koef1");
			}
		}

		public double Koef2
		{
			get
			{
				return _koef2;
			}
			set
			{
				_koef2 = value;
				OnPropertyChanged("Koef2");
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

		public void CalcGain()
		{
			var marga = (Koef1 + Koef2)/(Koef1*Koef2);
			var commonGain = Sum/marga;
			Sum1 = Math.Round(commonGain/Koef1, 2, MidpointRounding.AwayFromZero);
			Sum2 = Math.Round(commonGain/Koef2, 2, MidpointRounding.AwayFromZero);
			Gain1 = Math.Round(Koef1*Sum1, 2, MidpointRounding.AwayFromZero);
			Gain2 = Math.Round(Koef2*Sum2, 2, MidpointRounding.AwayFromZero);
			WinPercent1 = Math.Round(Gain1 * 100 / Sum - 100, 2, MidpointRounding.AwayFromZero);
			WinPercent2 = Math.Round(Gain2 * 100 / Sum - 100, 2, MidpointRounding.AwayFromZero);
		}

	}
}