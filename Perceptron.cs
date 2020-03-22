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


			for (int layerNumber = 0; layerNumber < _totalLayers - 1; layerNumber++)
			{
				int currentLayerNeurons = CalculateLayerHeight(layerNumber);
				int weightMatrixWidth = NumberOfInputs * 3 - (previousLayerNeurons - currentLayerNeurons);
				int weightMatrixHeight = currentLayerNeurons;

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
	}
}