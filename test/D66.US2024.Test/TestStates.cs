namespace D66.US2024.Test
{

	[TestFixture()]
	public class Tests
	{

		[Test()]
		public void ReadStates()
		{
			var states = States.Read().ToList();
			Assert.AreEqual(51, states.Count); // 50 states + DC

			var totalElectoralVotes = states.Sum(s => s.ElectoralVotes);

			Assert.AreEqual(538, totalElectoralVotes);
		}

	}
}