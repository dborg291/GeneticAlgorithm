using System;
using System.Collections.Generic;
using System.Linq;

namespace FCM
{
	abstract class FCM
	{

		private List<List<double>> _agents;

		protected int NumberOfValues { get; }
		protected int Population { get; }

		int Iterations { get; }

		List<List<double>> Agents { get => _agents; set { _agents = value; } }

		public FCM(int population, int numberOfValues, int iterations)
		{
			Population = population;
			NumberOfValues = NumberOfValues;
			Iterations = iterations;
			_agents = new List<List<double>>(population);
			for (int i = 0; i < population; i++)
			{
				_agents.Add(CreateRandomArray(numberOfValues));
			}
		}

		public abstract List<double> Fitness(List<List<double>> agents);

		public abstract List<List<double>> GenerateOffspring(List<double> agentFitness);

		public void Run()
		{
			for (int epoch = 0; epoch < Iterations; epoch++)
			{

				List<double> agentFitness = Fitness(Agents);

				List<double> agentReproductionPercentages = CalculateReproductionPercent(agentFitness);

				Agents = GenerateOffspring(agentReproductionPercentages);
			}
		}

		protected Tuple<List<double>, List<double>> PickParents(List<double> agentReproductionProbabilites)
		{
			List<double> copy = new List<double>(agentReproductionProbabilites.Count);
			copy.Concat(agentReproductionProbabilites);
			int firstParentIndex = SelectRandomWeightedIndex(copy);

			agentReproductionProbabilites[firstParentIndex] = 0; // first parent cannot be picked twice

			int secondParentIndex = SelectRandomWeightedIndex(copy);

			return Tuple.Create(Agents.ElementAt(firstParentIndex), Agents.ElementAt(secondParentIndex));
		}

		private int SelectRandomWeightedIndex(List<double> weights)
		{
			Random random = new Random();
			double value = random.NextDouble() * weights.Sum();
			double sum = 0;
			for (int i = 0; i < weights.Count; i++)
			{
				sum += weights.ElementAt(i);
				if (value < sum)
					return i;
			}
			throw new Exception("SelectRandomWeightedIndex did not find index.");
		}

		private List<double> CreateRandomArray(int length)
		{
			Random random = new Random();
			return Enumerable.Repeat(0, length).Select(i => random.NextDouble()).ToList();
		}

		private List<double> CalculateReproductionPercent(List<double> agentFitness)
		{
			List<double> reproductionPercent = new List<double>();
			double allAgengtsFitness = agentFitness.Sum();

			foreach (double agent in agentFitness)
			{
				double agentReproductionPercent = agent / allAgengtsFitness;
				reproductionPercent.Add(agentReproductionPercent);
			}

			return reproductionPercent;
		}

		public override String ToString()
		{
			String output = "\n";
			for(int i = 0; i < Population; i++)
			{
				output +=  ("Agent[" + i+ "]: " + Agents[0].ToString() + "\n");
			}
			return output;
		}
	}
}