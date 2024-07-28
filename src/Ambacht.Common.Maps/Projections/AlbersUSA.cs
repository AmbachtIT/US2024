using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambacht.Common.Mathmatics;

namespace Ambacht.Common.Maps.Projections
{

	/// <summary>
	/// Albers projection specialized to display the contiguous 48 states. AK and HI are reprojected
	/// to fit in the same space.
	/// </summary>
	public class AlbersUSA : Projection
	{
		public override Vector2<double> Project(LatLng pos)
		{
			if (pos.Latitude > 50)
			{
				return Alaska.Project(pos) + new Vector2<double>(-300, 170);
			}

			if (pos.Longitude < -130)
			{
				return Hawaii.Project(pos) + new Vector2<double>(-200, 170);
			}

			return Lower48.Project(pos);
		}

		public override LatLng Invert(Vector2<double> pos)
		{
			throw new NotImplementedException();
		}



		public static Projection Lower48 = new AlbersProjection(new LatLng(38, -98), 29.5, 45.5, 1000);

		public static Projection Alaska = new AlbersProjection(new LatLng(60, -160), 55, 65, 330);

		public static Projection Hawaii = new AlbersProjection(new LatLng(20, -160), 8, 18, 1000);

	}
}
