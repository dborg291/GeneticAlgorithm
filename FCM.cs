using System;
using System.Collections.Generic;
using System.Linq;

namespace FCM
{
	abstract class FCM
	{

		private List<double[]> _agents;

		int NumberOfValues { get; }
		int Population { get; }

		int Iterations { get; }

		List<double[]> Agents { get => _agents; set { _agents = value; } }

		public FCM(int population, int numberOfValues, int iterations)
		{
			Population = population;
			NumberOfValues = NumberOfValues;
			Iterations = iterations;
			_agents = new List<double[]>(population);
			_agents[0] = CreateRandomArray(numberOfValues);
		}

		public abstract List<double> Fitness(List<double[]> agents);

		public abstract List<double[]> MutationFunction(List<double> agentFitness);

		private void Run()
		{
			for (int epoch = 0; epoch < Iterations; epoch++)
			{

				List<double> agentFitness = Fitness(Agents);
				Agents = MutationFunction(agentFitness);
			}
		}

		private double[] CreateRandomArray(int length)
		{
			Random random = new Random();

			return Enumerable
				.Repeat(0, length)
				.Select(i => random.NextDouble())
				.ToArray();
		}
	}
}
