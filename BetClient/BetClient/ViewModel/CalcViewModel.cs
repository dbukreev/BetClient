using System.Windows.Input;
using BetClient.Model;
using GalaSoft.MvvmLight.CommandWpf;

namespace BetClient.ViewModel
{
	public class CalcViewModel
	{
		public CalcViewModel()
		{
			CalcModel = new CalcModel();
			CalcCommand = new RelayCommand(OnCalcCommand);
		}

		public CalcModel CalcModel { get; set; }

		public ICommand CalcCommand { get; set; }

		public void OnCalcCommand()
		{
			CalcModel.CalcGain();
		}
	}
}