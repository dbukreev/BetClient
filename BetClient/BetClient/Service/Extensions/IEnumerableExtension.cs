using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BetClient.Service.Extensions
{
	// ReSharper disable once InconsistentNaming
	public static class IEnumerableExtension
	{
		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
		{
			return new ObservableCollection<T>(collection);
		}
	}
}