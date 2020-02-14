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

        public override List<double[]> MutationFunction(List<double> agentFitness)
        {
            throw new System.NotImplementedException();
        }
    }
}