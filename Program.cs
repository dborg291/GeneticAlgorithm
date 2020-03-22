using CognitiveABM.FCM;
using CognitiveABM.Perceptron;
using System;

namespace CognitiveABM
{
	class Program
	{
		public static void Main()
		{
			PerceptronFactory perceptron = new PerceptronFactory(2, 2, 2, 1);

            perceptron.CalculatePerceptron(new double[]{0.3, 0.5, 1, 0, 0.2, 0.1, 0.7, 0.3, 0.5, 1, 0, 0.2, 0.1, 0.7, 0.3, 0.5, 1, 0, 0.2, 0.1, 0.7, 0.3, 0.5, 1, 0, 0.2, 0.1, 0.7, 0.3, 0.5, 1, 0, 0.2, 0.1, 0.7, 0.3, 0.5, 1, 0, 0.2, 0.1, 0.7}, new double[]{1, 0.5});

			// Console.WriteLine(perceptron.ToString());
			// HillClimberFCM fcm = new HillClimberFCM(1000, 423, 5000);
			// fcm.Run();
		}
	}
}
