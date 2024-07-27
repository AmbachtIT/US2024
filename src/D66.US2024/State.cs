namespace D66.US2024
{
	public record class State
	{

		public required string Code { get; set; }
		public required string Name { get; set; }

		public int ElectoralVotes { get; set; }

	}
}
