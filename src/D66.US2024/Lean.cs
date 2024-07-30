using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D66.US2024
{
	public enum Lean
	{
		SafeD,
		LikelyD,
		LeansD,
		TossUp,
		LeansR,
		LikelyR,
		SafeR
	}

	public static class LeanExtensions
	{
		public static Party Party(this Lean lean) => lean switch
		{
			Lean.LeansD => Parties.Democrats,
			Lean.LikelyD => Parties.Democrats,
			Lean.SafeD => Parties.Democrats,
			Lean.LeansR => Parties.Republicans,
			Lean.LikelyR => Parties.Republicans,
			Lean.SafeR => Parties.Republicans,
			Lean.TossUp => Parties.Tie,
			_ => throw new NotImplementedException()
		};
	}
}
