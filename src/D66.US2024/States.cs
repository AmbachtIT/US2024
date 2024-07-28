using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ambacht.Common.Maps.Nts;
using Ambacht.Common.Maps.Projections;
using CsvHelper.Configuration;
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
			var shapes = ReadShapes().ToDictionary(s => s.GetOptionalId("id").ToString());

			var type = typeof(States);
			using var stream = type.Assembly.GetManifestResourceStream(type, "Data.States.txt");
			using var reader = new StreamReader(stream);
			using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

			return csv.GetRecords<StateData>().Select(state =>
			{
				var result = new State()
				{
					Code = state.Code,
					Lean = state.Lean,
					Name = state.Name,
					ElectoralVotes = state.ElectoralVotes,
					Geometry = shapes[state.Code].Geometry
				};
				result.Geometry.Project(_projection);
				return result;
			}).ToList();
		}


		private static FeatureCollection ReadShapes()
		{
			var type = typeof(States);
			using var stream = type.Assembly.GetManifestResourceStream(type, "Data.States.geo.json");
			using var reader = new StreamReader(stream);

			var options = new JsonSerializerOptions();
			options.Converters.Add(new GeoJsonConverterFactory());

			var json = reader.ReadToEnd();
			return JsonSerializer.Deserialize<FeatureCollection>(json, options)!;
		}

		private static readonly Projection _projection = new AlbersUSA();

		private class StateClassMap : ClassMap<State>
		{
			public StateClassMap()
			{
				AutoMap(CultureInfo.InvariantCulture);
				Map(s => s.Geometry).Ignore();
			}
		}
	}

	
}
