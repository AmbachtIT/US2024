using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambacht.Common.Mathmatics;

namespace Ambacht.Common.Maps.Projections
{

	/// <summary>
	/// See: https://en.wikipedia.org/wiki/Albers_projection
	/// </summary>
	/// <param name="reference"></param>
	/// <param name="parallel1"></param>
	/// <param name="parallel2"></param>
	public class AlbersProjection(LatLng reference, double parallel1, double parallel2) : Projection
	{
		private const double R = Earth.Radius / 1000;
		private double sinLatitude0 = Math.Sin(MathUtil.DegreesToRadians(reference.Latitude));
		private double sinParallel1 = Math.Sin(MathUtil.DegreesToRadians(parallel1));
		private double sinParallel2 = Math.Sin(MathUtil.DegreesToRadians(parallel2));
		private double cosParallel1 = Math.Cos(MathUtil.DegreesToRadians(parallel1));
		private double cosParallel1_2 => cosParallel1 * cosParallel1;
		private double C => cosParallel1_2 + 2 * n * sinParallel1;

		private double Rho(double sine) => Math.Sqrt(C - 2 * n * sine) * R / n;

		
		private double n => (sinParallel1 + sinParallel2) / 2;




		public override Vector2<double> Project(LatLng pos)
		{
			var sinLatitude = Math.Sin(MathUtil.DegreesToRadians(pos.Latitude));
			var rho = Rho(sinLatitude);
			var rho0 = Rho(sinLatitude0);
			var theta = MathUtil.DegreesToRadians(n * (pos.Longitude - reference.Longitude));

			var x = rho * Math.Sin(theta);
			var y = rho0 - rho * Math.Cos(theta);

			return new Vector2<double>(x, -y);
		}

		public override LatLng Invert(Vector2<double> pos)
		{
			throw new NotImplementedException();
		}
	}
}
