using System.Collections.Generic;
using System;
using System.Numerics;
using Math;
using MatrixMultiplication;

namespace CognitiveABM.Perceptron
{
	public class PerceptronFactory
	{
		protected int NumberOfInputs { get; }

		protected int NumberOfOutputs { get; }

		protected int NumberOfHiddenLayers { get; }

		protected int NeuronsPerHiddenLayer { get; }

		public double[] Genomes { get; set; }

		private int _totalLayers;

		private int _weightIndex = 0;

		public PerceptronFactory(int numberOfInputs, int numberOfOutputs, int numberOfHiddenLayers, int neuronsPerHiddenLayer)
		{
			NumberOfInputs = numberOfInputs;
			NumberOfOutputs = numberOfOutputs;
			NumberOfHiddenLayers = numberOfHiddenLayers;
			NeuronsPerHiddenLayer = neuronsPerHiddenLayer;
			_totalLayers = 2 + numberOfHiddenLayers;
		}

		public double[] CalculatePerceptron(double[] inputs)
		{
			double[] outputs = new double[NumberOfOutputs];

			int previousLayerNeurons = NumberOfInputs;
			double[,] weights;


			for (int layerNumber = 0; layerNumber < _totalLayers - 1; layerNumber++)
			{
				int currentLayerNeurons = CalculateLayerHeight(layerNumber);
				int weightMatrixWidth = NumberOfInputs * 3 - (previousLayerNeurons - currentLayerNeurons);
				int weightMatrixHeight = currentLayerNeurons;
				weights = CreateWeightMatrix(weightMatrixWidth, weightMatrixHeight);
				double[] values = MatrixMult(inputs, weights);

				previousLayerNeurons = currentLayerNeurons;
			}

			return outputs;
		}

		private int CalculateLayerHeight(int layer)
		{
			if (layer == 0) // input layer
			{
				return NumberOfInputs;
			}
			else if (layer != _totalLayers - 1) // hidden layer
			{
				return NeuronsPerHiddenLayer;
			}
			else // output layer
			{
				return NumberOfOutputs;
			}
		}

		private double[,] CreateWeightMatrix(int width, int height)
		{
			double[,] weights = new double[height, width];

			for (int i = 0; i < weights.GetLength(0); i++)
			{
				for (int j = 0; j < weights.GetLength(1); j++)
				{
					weights[i, j] = Genomes[_weightIndex];
					_weightIndex++;
				}
			}
			return weights;
		}
		private double[] MatrixMult(double[] inputs, double[,] weights )
		{
			double[] output = new double[weights.GetLength(0)];
			
			// for each output
			Parallel.For(0, output.GetLength(0), i =>
				{
					double total = 0;
					// iterating over both the weights and the inputs
					for(int j = 0; j < weights.GetLength(1); j++)
					{
						// mult. the weight in the current row with the current input
						total += weights[i,j] * inputs[j];
					}
					output[i] = total;
				}
			
			);
			return output;
		}
	}
}