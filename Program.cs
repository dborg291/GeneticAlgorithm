using CognitiveABM.FCM;
using CognitiveABM.Perceptron;
using System;

namespace CognitiveABM
{
	class Program
	{
		public static void Main()
		{
			PerceptronFactory perceptron = new PerceptronFactory(9, 2, 9, 9);
			Console.WriteLine(perceptron.ToString());
			HillClimberFCM fcm = new HillClimberFCM(1000, 423, 5000);
			fcm.Run();
		}
	}
}
