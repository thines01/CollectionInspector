using System.Collections.Generic;
using System.Linq;

namespace CollectionInspector
{
	public class CCollectionInspector
	{
		public static Dictionary<string, int> GetInspectedMap0<T>(IEnumerable<T> arr) where T : class
		{
			return
			(arr.ElementAt(0)).GetType().GetProperties().Select( (pi,i) => 
				new KeyValuePair<string, int>
				(
					pi.Name,
					arr.Max(obj => obj.GetType().GetProperty(pi.Name)
						.GetValue(obj, new object[]{i}).ToString().Length)
				)
			).ToDictionary(k => k.Key, v => v.Value);
		}

		public static Dictionary<string, int> GetInspectedMap<T>(IEnumerable<T> arr) where T : class
		{
			return
			(arr.ElementAt(0)).GetType().GetProperties().Select(pi => pi.Name)
				.Select((strPropertyName) =>
				new KeyValuePair<string, int>
				(
					strPropertyName,
					arr.Max(obj => obj.GetType().GetProperty(strPropertyName)
						.GetValue(obj, null).ToString().Length)
				)
			).ToDictionary(k => k.Key, v => v.Value);
		}
	}
}
