using System;
using System.Collections.Generic;
using System.Linq;

namespace FCM {
    class FCMSplittingAlgorithm : FCM
    {
        public FCMSplittingAlgorithm(int population, int numberOfValues, int iterations): base(population, numberOfValues, iterations)
        {

        }
        public override List<double> Fitness(List<double[]> agents)
        {
            List<double> agentFitnessValues = new List<double>();
            foreach(double[] agent in agents)
            {
                double fitness = agent.Average();
                agentFitnessValues.Add(fitness);
            }

            return agentFitnessValues;
            
        }

        public override List<double[]> GenerateOffspring(List<double> agentGenome, List<double[]> agents)
        {
            List<double[]> offspring = new List<double[]>();
            List<double> mutatedGenome = new List<double>(agentGenome);

            var random = new Random();
            int numberOfPossibleMutation = random.Next(agentGenome.Count);


            


            foreach(double agent in agentGenome)
            {

            }

            int i = 0;
            while(i < numberOfPossibleMutation)
            {
                int mutationChance = random.Next(2);
            }

            return offspring;
        }
    }
}