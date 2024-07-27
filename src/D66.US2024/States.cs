using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;

namespace D66.US2024
{
	public static class States
	{

		/// <summary>
		/// Reads the state data from the assembly
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<State> ReadData()
		{
			var type = typeof(States);
			using var stream = type.Assembly.GetManifestResourceStream(type, "Data.States.txt");
			using var reader = new StreamReader(stream);
			using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

			return csv.GetRecords<State>().ToList();
		}


		public static FeatureCollection ReadShapes()
		{
			var type = typeof(States);
			using var stream = type.Assembly.GetManifestResourceStream(type, "Data.States.geo.json");
			using var reader = new StreamReader(stream);

			var options = new JsonSerializerOptions();
			options.Converters.Add(new GeoJsonConverterFactory());

			

			var json = reader.ReadToEnd();
			return JsonSerializer.Deserialize<FeatureCollection>(json, options)!;
		}

	}
}
