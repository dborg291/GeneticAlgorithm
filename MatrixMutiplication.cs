using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
	class MatrixMultiplication
	{
		public double[] MatrixMult(double[] inputs, double[,] weights )
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