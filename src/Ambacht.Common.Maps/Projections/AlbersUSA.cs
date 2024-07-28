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
			throw new NotImplementedException();
		}

		public override LatLng Invert(Vector2<double> pos)
		{
			throw new NotImplementedException();
		}



		public static Projection Lower48 = new AlbersProjection(new LatLng(38, -98), 29.5, 45.5);

		public static Projection Alaska = new AlbersProjection(new LatLng(60, -160), 55, 65);

	}
}
