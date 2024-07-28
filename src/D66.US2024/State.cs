using NetTopologySuite.Geometries;

namespace D66.US2024
{
	public record class State
	{

		public required string Code { get; set; }
		public required string Name { get; set; }

		public required int ElectoralVotes { get; set; }
		public required Lean Lean { get; set; }

		public required Geometry Geometry { get; set; }

	}

	public record class StateData
	{
		public required string Code { get; set; }
		public required string Name { get; set; }

		public required int ElectoralVotes { get; set; }

		public required Lean Lean { get; set; }
	}
}
