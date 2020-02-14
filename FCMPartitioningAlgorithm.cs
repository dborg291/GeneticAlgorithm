using System;
using System.Collections.Generic;
using System.Linq;

namespace FCM
{
	class FCMSplittingAlgorithm : FCM
	{
		public FCMSplittingAlgorithm(int population, int numberOfValues, int iterations) : base(population, numberOfValues, iterations) { }

		public override List<double> Fitness(List<List<double>> agents)
		{
			List<double> agentFitnessValues = new List<double>();

			foreach (List<double> agent in agents)
			{
				double fitness = agent.Average();
				agentFitnessValues.Add(fitness);
			}

			return agentFitnessValues;
		}

		public override List<List<double>> GenerateOffspring(List<double> agentFitnessValues)
		{
			List<List<double>> offspring = new List<List<double>>();
			Random random = new Random();
			ToString();
			for (int i = 0; i < Population; i++)
			{
				Tuple<List<double>, List<double>> parents = PickParents(agentFitnessValues);
				int splitIndex = random.Next(0, NumberOfValues);
				List<double> child = parents.Item1.GetRange(0, splitIndex).Concat(parents.Item2.GetRange(splitIndex, parents.Item2.Count)).ToList();
				child[random.Next(child.Count)] = random.NextDouble();
				offspring.Add(child);

				if (child.Count != parents.Item2.Count)
				{
					Console.WriteLine("Error: child count != parent count");
				}

				if (child.Count != NumberOfValues)
				{
					Console.WriteLine("Error: child count != NumberOfValues");
				}
			}


			return offspring;
		}
	}
}