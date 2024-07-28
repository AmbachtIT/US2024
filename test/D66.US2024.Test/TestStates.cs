using NetTopologySuite.Features;

namespace D66.US2024.Test
{

	[TestFixture()]
	public class Tests
	{

		[Test()]
		public void ReadStateData()
		{
			var data = States.ReadData().ToList();
			Assert.AreEqual(51, data.Count); // 50 states + DC

			var totalElectoralVotes = data.Sum(s => s.ElectoralVotes);

			Assert.AreEqual(538, totalElectoralVotes);
		}



		private static IEnumerable<State> AllData() => _data;


		private static readonly List<State> _data = States.ReadData().ToList();

	}
}