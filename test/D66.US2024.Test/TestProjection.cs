using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambacht.Common.Maps;
using Ambacht.Common.Maps.Projections;

namespace D66.US2024.Test
{
	[TestFixture()]
	public class TestProjection
	{

		private LatLng _disney = new LatLng(33.807255, -117.91804);
		private LatLng _nyc = new LatLng(40.71427, -74.00597);


		[Test()]
		public void TestDisney()
		{
			var projection = AlbersUSA.Lower48;
			var v = projection.Project(_disney);
			Console.WriteLine(v.ToString());
		}

		[Test()]
		public void TestNYC()
		{
			var projection = AlbersUSA.Lower48;
			var v = projection.Project(_nyc);
			Console.WriteLine(v.ToString());
		}

	}
}
