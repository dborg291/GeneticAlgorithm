using System;

namespace GeneticAlgorithm
{
	public class GenerateParents : Parent
    {
        int NumberOfIntialParents;
        int GenomeWidth = -1;
        int GenomeHeigth = -1;
        Parent[] ParentArray;

        public GenerateParents(int initialAmountOfParents)
        {
            if (initialAmountOfParents < 2)
            {
                Console.WriteLine("Error: Need atlest 2 inital parents to generate offspring");
                return;
            }

            NumberOfIntialParents = initialAmountOfParents;
            ParentArray = new Parent[initialAmountOfParents];
        }

        public void initalize()
        {
            int i;
            if (GenomeHeigth > 0 && GenomeWidth > 0)
            {
                for (i = 0; i < NumberOfIntialParents; i++)
                {
                    ParentArray[i] = new Parent(GenomeWidth, GenomeHeigth);
                }
            }
            else
            {
                for (i = 0; i < NumberOfIntialParents; i++)
                {
                    ParentArray[i] = new Parent();
                }
            }
        }

        public GenerateParents(int initialAmountOfParents, int genomeWidth, int genomeHeight)
        {
            if(genomeWidth < 1)
            {
                Console.WriteLine("Error: genomeWidth must be at least 1.");
                return;
            }

            if(genomeHeight < 1)
            {
                Console.WriteLine("Error: genomeHeight must be at least 1.");
                return;
            }

            GenomeWidth = genomeWidth;
            GenomeHeigth = genomeHeight;

            NumberOfIntialParents = initialAmountOfParents;
            ParentArray = new Parent[initialAmountOfParents];
        }

        public void generateOffspring()
        {
            Parent[] OffSpring = new Parent[NumberOfIntialParents];
            Random rand = new Random();
            int i,j,k;
            for(i = 0; i < NumberOfIntialParents; i++)
            {
                int parent1 = rand.Next(0, NumberOfIntialParents);
                int parent2 = rand.Next(0, NumberOfIntialParents);

                double[,] OffspringGenome = new double[Parent.GenomeMatrixHeight, Parent.GenomeMatrixWidth];
                for (j = 0; j < ParentArray.GetLength(0); j++)
                {
                    for(k = 0; k < ParentArray.GetLength(0); k++)
                    {
                        if ((rand.Next(0, 2)) == 0)
                        {
                            if((rand.Next(0, 101)) < 25)
                            {
                                double mutation = rand.NextDouble()+.01;
                                if((rand.Next(0, 2)) == 0)
                                {
                                    OffspringGenome[j, k] = ParentArray[parent1].getTraitValue(j, k)- mutation;
                                }
                                else
                                {
                                    OffspringGenome[j, k] = ParentArray[parent1].getTraitValue(j, k)+ mutation;
                                }
                            }
                        }
                        else
                        {
                            double mutation = rand.NextDouble() + .01;
                            if ((rand.Next(0, 2)) == 0)
                            {
                                OffspringGenome[j, k] = ParentArray[parent2].getTraitValue(j, k) - mutation;
                            }
                            else
                            {
                                OffspringGenome[j, k] = ParentArray[parent2].getTraitValue(j, k) + mutation;
                            }
                        }
                    }
                }

                OffSpring[i] = new Parent(OffspringGenome);
            }
            ParentArray = OffSpring;
        }

        //public override string ToString()
        //{
        //    int i;
        //    Console.Write("[ ");
        //    for (i = 0; i < ParentArray.Length; i++)
        //    {
        //        ParentArray[i].ToString();
        //    }

        //    Console.Write(" ]");

        //    return "";
        //}

        public override string ToString()
        {
            ParentArray[0].ToString();
            return "";
        }

    }

}
