using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;

namespace D66.US2024
{

	public static class Parties
	{

		public static readonly Party Democrats = new Party()
		{
			Name = "Democrats",
			Color = Colors.Dems,
			Align = "left"
		};

		public static readonly Party Republicans = new Party()
		{
			Name = "Republicans",
			Color = Colors.Reps,
			Align = "right"
		};

		public static readonly Party Tie = new Party()
		{
			Name = "Tie",
			Color = Colors.Beige,
			Align = "center"
		};

		public static IEnumerable<Party> All()
		{
			yield return Democrats;
			yield return Tie;
			yield return Republicans;
		}
	}

	public record class Party
	{

		public required string Name { get; init; }
		public required string Color { get; init; }

		/// <summary>
		/// Used for formatting, but incidentally also matches the political alignment ;)
		/// </summary>
		public required string Align { get; init; }

	}
}
