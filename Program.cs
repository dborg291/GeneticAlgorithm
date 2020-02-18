using FCM;
using PerceptronMaker;
using System;

namespace GeneticAlgorithm
{
    class Program
    {
        public static void Main()
        {
            /*GenerateParents parents = new GenerateParents(2);
            parents.initalize();

            parents.ToString();
            int i;
            for(i = 0; i < 10; i++)
            {
                parents.generateOffspring();
            }

            parents.ToString();*/


            Perceptron perceptron = new Perceptron(9,2,9,9);
            Console.WriteLine(perceptron.ToString());

            // FCMSplittingAlgorithm fcm = new FCMSplittingAlgorithm(5000,423,10000);
            // fcm.Run();
            // Console.WriteLine(fcm.ToString());
        }
    }
}
