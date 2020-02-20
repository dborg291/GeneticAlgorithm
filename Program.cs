﻿using CognitiveABM.FCM;
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
			FCMSplittingAlgorithm fcm = new FCMSplittingAlgorithm(1000, 423, 100000);
			fcm.Run();
		}
	}
}
