using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveABM.FCM
{
	abstract class FCM
	{
		protected const int SEED = 22222222;
		private List<List<double>> _agents;

		protected int NumberOfValues { get; }
		protected int Population { get; }

		protected int Iterations { get; }

		List<List<double>> Agents { get => _agents; set { _agents = value; } }

		public FCM(int population, int numberOfValues, int iterations)
		{
			Population = population;
			NumberOfValues = numberOfValues;
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
				// Console.WriteLine("Epoch: {0}\n" + ToString(), epoch);
				Console.WriteLine("Epoch: {0}\n Avg: {1,1:F4}, Max: {2,1:F4}", epoch, AverageFitness(), MaxFitness());
				List<double> agentReproductionPercentages = CalculateReproductionPercent(agentFitness.ToList());

				Agents = GenerateOffspring(agentReproductionPercentages);
			}
		}

		protected Tuple<List<double>, List<double>> PickParents(List<double> agentReproductionProbabilites)
		{
			// int one = agentReproductionProbabilites.FindIndex(x => x == agentReproductionProbabilites.Max());
			// double temp = agentReproductionProbabilites[one];

			// agentReproductionProbabilites[one] = 0; // first parent cannot be picked twice
			// int two = agentReproductionProbabilites.FindIndex(x => x == agentReproductionProbabilites.Max());
			// return Tuple.Create(Agents[one], Agents[two]);
			// agentReproductionProbabilites[one] = temp;

			int firstParentIndex = SelectRandomWeightedIndex(agentReproductionProbabilites);
			double temp = agentReproductionProbabilites[firstParentIndex];

			agentReproductionProbabilites[firstParentIndex] = 0; // first parent cannot be picked twice

			int secondParentIndex = SelectRandomWeightedIndex(agentReproductionProbabilites);

			agentReproductionProbabilites[firstParentIndex] = temp;

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
			Random random = new Random(SEED);
			return Enumerable.Repeat(0, length).Select(i => random.NextDouble()).ToList();
		}

		private List<double> CalculateReproductionPercent(List<double> agentFitness)
		{
			List<double> reproductionPercent = new List<double>();
			double sumOfFitnessValues = agentFitness.Sum();

			foreach (double agent in agentFitness)
			{
				double agentReproductionPercent = agent / sumOfFitnessValues;
				reproductionPercent.Add(agentReproductionPercent);
			}

			return reproductionPercent;
		}

		public override String ToString()
		{
			var fitness = Fitness(Agents);
			String output = "\n";
			for (int i = 0; i < Population; i++)
			{
				output += ("Agent[" + i + "] Fitness: " + fitness[i] + "\nValues: " + string.Join(",", Agents[i]) + "\n");
			}
			return output;
		}

		private double AverageFitness()
		{
			return Fitness(Agents).Sum() / Agents.Count;
		}

		private double MaxFitness()
		{
			return Fitness(Agents).Max();
		}
	}
}