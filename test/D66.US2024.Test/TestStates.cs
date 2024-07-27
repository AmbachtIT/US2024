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

		[Test()]
		public void ReadStateShapes()
		{
			var shapes = States.ReadShapes();
			
			Assert.AreEqual(51, shapes.Count); // 50 states + DC
		}


		[Test(), TestCaseSource(nameof(AllData))]
		public void DataShouldHaveShape(State state)
		{
			var shape = _shapes.FirstOrDefault(s => s.GetOptionalId("id")?.ToString() == state.Code);
			Assert.NotNull(shape);
		}


		[Test(), TestCaseSource(nameof(AllShapes))]
		public void ShapeShouldHaveData(IFeature state)
		{
			var id = state.GetOptionalId("id")?.ToString();
			var data = _data.FirstOrDefault(s => s.Code == id);
			Assert.NotNull(data);
		}


		private static IEnumerable<State> AllData() => _data;
		private static IEnumerable<IFeature> AllShapes() => _shapes;


		private static readonly List<State> _data = States.ReadData().ToList();
		private static readonly FeatureCollection _shapes = States.ReadShapes();

	}
}