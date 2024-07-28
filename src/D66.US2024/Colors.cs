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
			Lean.SafeR => ColorBrewer.RdBu7[0],
			Lean.LikelyR => ColorBrewer.RdBu7[1],
			Lean.LeansR => ColorBrewer.RdBu7[2],
			Lean.TossUp => Beige,
			Lean.LeansD => ColorBrewer.RdBu7[4],
			Lean.LikelyD => ColorBrewer.RdBu7[5],
			Lean.SafeD => ColorBrewer.RdBu7[6],
			_ => throw new NotImplementedException()
		};

		public const string Beige = "#f6e8c3";

	}
}
