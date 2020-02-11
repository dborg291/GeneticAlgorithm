using System;

namespace GeneticAlgorithm
{
    public class Parent
    {
        public static int GenomeMatrixHeight { get; private set; }
        public static int GenomeMatrixWidth { get; private set; }
        public double[,] Genome { get; }
        Random rand = new Random();

        public Parent(int width = 10, int height = 10)
        {

            GenomeMatrixWidth = width;
            GenomeMatrixHeight = height;

            Genome = new double[GenomeMatrixHeight, GenomeMatrixWidth];

            int i, j;
            for (i = 0; i < Genome.GetLength(0); i++)
            {
                for (j = 0; j < Genome.GetLength(1); j++)
                {
                    Genome[i, j] = rand.NextDouble() + .01; //sets values to a random grater than 0.0 and less than or equal to 1
                }
            }
        }

        public Parent(double[,] genome)
        {
            Genome = genome;
            GenomeMatrixHeight = genome.GetLength(0);
            GenomeMatrixWidth = genome.GetLength(1);
        }

        public double getTraitValue(int row, int col)
        {
            return Genome[row, col];
        }

        public override string ToString()
        {
            int i, j;
            for (i = 0; i < Genome.GetLength(0); i++)
            {
                Console.WriteLine("\n[");
                for (j = 0; j < Genome.GetLength(1); j++)
                {
                    Console.Write(Genome[i, j].ToString() + " ");
                }

                Console.WriteLine("]");
            }

            Console.Write(" ]");

            return "";
        }
    }

}