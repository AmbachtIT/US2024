using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D66.US2024.Test
{
	[TestFixture()]
	public class TestSimulation
	{

		[Test()]
		public void RunSimulation()
		{
			var sim = new Simulation(19681, States.ReadData().ToList());
			var result = sim.Simulate().Last();
			Console.WriteLine(result.Summary);
		}

	}
}
