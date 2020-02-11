using System;

namespace GeneticAlgorithm
{
    class Program
    {
        public static void Main()
        {
            GenerateParents parents = new GenerateParents(4);
            parents.initalize();

            parents.ToString();
            int i;
            for(i = 0; i < 10; i++)
            {
                parents.generateOffspring();
            }

            parents.ToString();
        }
    }
}
