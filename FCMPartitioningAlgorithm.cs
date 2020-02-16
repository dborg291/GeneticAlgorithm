using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace FCM
{
	class FCMSplittingAlgorithm : FCM
	{
		public FCMSplittingAlgorithm(int population, int numberOfValues, int iterations) : base(population, numberOfValues, iterations) { }

		public override List<double> Fitness(List<List<double>> agents)
		{
			List<double> agentFitnessValues = new List<double>();
			foreach (List<double> agent in agents)
				agentFitnessValues.Add(agent.Average());
			return agentFitnessValues;
		}

		public override List<List<double>> GenerateOffspring(List<double> agentFitnessValues)
		{
			List<List<double>> offspring = new List<List<double>>();
			ConcurrentBag<List<double>> bag = new ConcurrentBag<List<double>>();
			Random random = new Random();

			Parallel.For(0, Population, index => {
				Tuple<List<double>, List<double>> parents = PickParents(agentFitnessValues.ToList());
				int splitIndex = random.Next(0, NumberOfValues);

				List<double> child = parents.Item1.GetRange(0, splitIndex).Concat(parents.Item2.GetRange(splitIndex, parents.Item2.Count - splitIndex)).ToList();

				var randomIndex = random.Next(child.Count);
				child[randomIndex] += random.NextDouble() - 0.5;

				if (child[randomIndex] > 1)
					child[randomIndex] = 1;

				if (child[randomIndex] < 0)
					child[randomIndex] = 0;


				bag.Add(child);
			});

			return bag.ToList();

			// for (int i = 0; i < Population; i++)
			// {
			// 	Tuple<List<double>, List<double>> parents = PickParents(agentFitnessValues);
			// 	int splitIndex = random.Next(0, NumberOfValues);

			// 	List<double> child = parents.Item1.GetRange(0, splitIndex).Concat(parents.Item2.GetRange(splitIndex, parents.Item2.Count - splitIndex)).ToList();

			// 	var index = random.Next(child.Count);
			// 	child[index] += random.NextDouble() - 0.5;

			// 	if (child[index] > 1)
			// 		child[index] = 1;

			// 	if (child[index] < 0)
			// 		child[index] = 0;

			// 	offspring.Add(child);
			// }

			return offspring;
		}
	}
}