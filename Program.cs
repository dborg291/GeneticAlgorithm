using CognitiveABM.FCM;

namespace GeneticAlgorithm
{
    class Program
    {
        public static void Main()
        {
           FCMSplittingAlgorithm fcm = new FCMSplittingAlgorithm(5000,423,10000);
            fcm.Run();
        }
    }
}
