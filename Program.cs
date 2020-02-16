using FCM;
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

            FCMSplittingAlgorithm fcm = new FCMSplittingAlgorithm(500,100,10000);
            fcm.Run();
            Console.WriteLine(fcm.ToString());
        }
    }
}
