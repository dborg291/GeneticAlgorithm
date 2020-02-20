using System.Collections.Generic;
using System;

namespace CognitiveABM.Perceptron
{
	public class PerceptronFactory
	{
		protected int Inputneurons { get; }
		protected int NumberOfHiddenLayers { get; }
		protected int NeuronsPerHiddenLayer { get; }
		protected int Outputneurons { get; }
		List<List<int>> Weights;

		public PerceptronFactory(int inputs, int hiddenLayers, int neuronsPerHiddenLayer, int outputs)
		{
			Inputneurons = inputs;
			NumberOfHiddenLayers = hiddenLayers;
			NeuronsPerHiddenLayer = neuronsPerHiddenLayer;
			Outputneurons = outputs;
			GenomeToWeights((inputs*inputs + (4*inputs*inputs) + (2 * inputs)));
		}
		public List<List<int>> GenomeToWeights(int genes)
		{
			int geneIndex = 0;
			Weights = new List<List<int>>();

			// int genomeIndex = 0;
			int neuronIndex = 0;

			for (int i = 0; i < Inputneurons; i++) // mapping weights from each input neuron to the first hidden layer neurons
			{
				List<int> neuronWeights = new List<int>();
				for (int j = neuronIndex; j < neuronIndex + NeuronsPerHiddenLayer; j++)
				{
					neuronWeights.Add(geneIndex);
					geneIndex++;
					// genomeIndex++;
				}
				// genomeIndex = 0;
				Weights.Add(neuronWeights);
				neuronIndex++;
			}

			// genomeIndex += Inputneurons;
			for (int i = 0; i < NumberOfHiddenLayers; i++) // mapping weights from each hiden layer neuron to itself, to the prvious neurons, and to the forward neurons
			{
				int self = neuronIndex;
				for (int j = 0; j < NeuronsPerHiddenLayer; j++)
				{
					self += j;
					List<int> neuronWeights = new List<int>();
					neuronWeights.Add(geneIndex); // add the weight to itself
					geneIndex++;

					// genomeIndex++;

					if (i == 0) //linking to input neurons
					{
						// genomeIndex = 0;
						for (int k = (self - Inputneurons); k < self; k++)
						{
							neuronWeights.Add(geneIndex);
							geneIndex++;
							// genomeIndex++;
						}
						// genomeIndex = self + j + 1;
					}
					else // linking to past hidden layer
					{
						// genomeIndex = Inputneurons + (NeuronsPerHiddenLayer * (i - 1));
						for (int k = (self - NeuronsPerHiddenLayer); k < self; k++)
						{
							neuronWeights.Add(geneIndex);
							geneIndex++;
							// genomeIndex++;
						}
						// genomeIndex = self + j + 1;
					}

					if (i != NumberOfHiddenLayers - 1)
					{
						for (int k = (neuronIndex + NeuronsPerHiddenLayer); k < neuronIndex + (NeuronsPerHiddenLayer * 2); k++) // add the weights to the forward neurons
						{
							neuronWeights.Add(geneIndex);
							geneIndex++;
						}
						Weights.Add(neuronWeights);
						neuronIndex++;
					}
					else
					{
						for (int k = (neuronIndex + NeuronsPerHiddenLayer); k < neuronIndex + NeuronsPerHiddenLayer + Outputneurons; k++) // add the weights to the forward neurons
						{
							neuronWeights.Add(geneIndex);
							geneIndex++;
						}
						Weights.Add(neuronWeights);
						neuronIndex++;
					}
				}
			}
			return Weights;
		}

		public override string ToString()
		{
			string output = "";
			for (int i = 0; i < Weights.Count; i++)
			{
				for (int j = 0; j < Weights[i].Count; j++)
				{

					output += (Weights[i][j] + " ");
				}
				output += ("\n");
			}
			return output;
		}
	}
}