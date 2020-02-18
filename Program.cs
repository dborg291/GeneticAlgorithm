using CognitiveABM.FCM;
using PerceptronMaker;
using System;

namespace GeneticAlgorithm
{
	class Program
	{
		public static void Main()
		{
			Perceptron perceptron = new Perceptron(9, 2, 9, 9);
			Console.WriteLine(perceptron.ToString());
			FCMSplittingAlgorithm fcm = new FCMSplittingAlgorithm(5000, 423, 10000);
			fcm.Run();
		}
	}
}
