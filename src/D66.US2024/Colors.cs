using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D66.US2024
{
	public static class Colors
	{

		public static string GetColor(this Lean lean) => lean switch
		{
			Lean.SafeR => Reps,
			Lean.LikelyR => Reps1,
			Lean.LeansR => Reps2,
			Lean.TossUp => Beige,
			Lean.LeansD => Dems2,
			Lean.LikelyD => Dems1,
			Lean.SafeD => Dems,
			_ => throw new NotImplementedException()
		};

		public const string Beige = "#f6e8c3";


		public static readonly string Reps = ColorBrewer.RdBu7[0];
		public static readonly string Reps1 = ColorBrewer.RdBu7[1];
		public static readonly string Reps2 = ColorBrewer.RdBu7[2];

		public static readonly string Dems = ColorBrewer.RdBu7[6];
		public static readonly string Dems1 = ColorBrewer.RdBu7[5];
		public static readonly string Dems2 = ColorBrewer.RdBu7[4];

	}
}
