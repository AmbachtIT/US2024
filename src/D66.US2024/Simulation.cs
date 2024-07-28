using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D66.US2024
{
	public class Simulation(int seed, List<State> states)
	{

		public int Runs { get; set; } = 1000;

		private readonly Random _random = new Random(seed);
		private readonly List<State> _orderedStates = states.OrderBy(s => s.Code).ToList();


		public IEnumerable<SimulationResult> Simulate()
		{
			var result = new SimulationResult();
			for (var i = 0; i < Runs; i++)
			{
				result.Runs.Add(SimulateRun());
				yield return result;
			}
		}

		public RunResult SimulateRun()
		{
			var result = new RunResult();
			foreach (var state in _orderedStates)
			{
				result.States.Add(SimulateState(state));
			}
			return result;
		}

		private StateResult SimulateState(State state)
		{
			var result = new StateResult();
			var rounds = 1;
			var votes = state.ElectoralVotes;

			if (!IsWinnerTakesAll(state))
			{
				rounds = state.ElectoralVotes;
				votes = 1;
			}

			for (var i = 0; i < rounds; i++)
			{
				if (SimulateElection(state.Lean))
				{
					result.VotesD += votes;
				}
				else
				{
					result.VotesR += votes;
				}
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="lean"></param>
		/// <returns>True, if the democrats win, false if the republicans win</returns>
		private bool SimulateElection(Lean lean)
		{
			var roll = _random.NextDouble();
			return roll > GetTreshold(lean);
		}

		private double GetTreshold(Lean lean) => lean switch
		{
			Lean.SafeD => 0.01,
			Lean.LikelyD => 0.15,
			Lean.LeansD => 0.30,
			Lean.TossUp => 0.5,
			Lean.LeansR => 1 - GetTreshold(Lean.LeansD),
			Lean.LikelyR => 1 - GetTreshold(Lean.LikelyD),
			Lean.SafeR => 1 - GetTreshold(Lean.SafeD),
			_ => throw new NotImplementedException()
		};

		private bool IsWinnerTakesAll(State state)
		{
			if (state.Code == "ME" || state.Code == "NE")
			{
				return false;
			}

			return true;
		}


		public class SimulationResult
		{
			public List<RunResult> Runs { get; set; } = new List<RunResult>();


			public string Summary
			{
				get
				{
					var builder = new StringBuilder();
					foreach (var group in Runs.GroupBy(r => r.Winner).OrderByDescending(g => g.Key))
					{
						var percentage = 100.0 * group.Count() / Runs.Count;
						builder.AppendLine(group.Key.PadRight(13) + $": {percentage:0.0}%");
					}

					return builder.ToString();
				}
			}

		}


		public class RunResult
		{
			public List<StateResult> States { get; set; } = new List<StateResult>();

			public string Winner
			{
				get
				{
					var dems = VotesD();
					var reps = VotesR();
					if (dems < reps)
					{
						return $"Republicans";
					}

					if (reps < dems)
					{
						return $"Democrats";
					}

					return "Tie";
				}
			}

			public int VotesD() => States.Sum(s => s.VotesD);
			public int VotesR() => States.Sum(s => s.VotesR);
		}
		public class StateResult
		{
			public int VotesD { get; set; }
			public int VotesR { get; set; }
		}



	}
}
