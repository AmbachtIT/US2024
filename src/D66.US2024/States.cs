using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D66.US2024
{
	public static class States
	{

		/// <summary>
		/// Reads the state data from the assembly
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<State> Read()
		{
			var type = typeof(States);
			using var stream = type.Assembly.GetManifestResourceStream(type, "Data.States.txt");
			using var reader = new StreamReader(stream);
			using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

			return csv.GetRecords<State>().ToList();
		}

	}
}
