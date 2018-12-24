using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_cards
{
    class Program
    {
        static void Main(string[] args)

        {

            Console.WriteLine("please enter matrix number");
            int sizeofmatrix = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[sizeofmatrix, sizeofmatrix];

            getmatrix(matrix, sizeofmatrix);
            printthematrix(matrix);
            twocardsreveal(matrix, sizeofmatrix);
            
        }

        private static void twocardsreveal(int[,] matrix,int  sizeofmatrix )
        {
            int pairsleft = 0;
            int score = 0;
            while (score < (sizeofmatrix * sizeofmatrix) / 2)
            {


                int[] carda = { -1, -1 };
                int[] cardb = { -1, -1 };
                do
                {
                    carda [0]=  -1;
                    carda [1] = -1;
                    cardb [0] = -1;
                    cardb [1] = -1;

                    while (carda[0] < 0 || carda[0] >= (sizeofmatrix))
                    {
                        Console.WriteLine($"please enter row for the first card: ");
                        carda[0] = (Convert.ToInt32(Console.ReadLine()) - 1);
                    }
                    while (carda[1] < 0 || carda[1] >= (sizeofmatrix))
                    {
                        Console.WriteLine($"please enter column for the first card ");
                        carda[1] = (Convert.ToInt32(Console.ReadLine()) - 1);
                    }

                } while (matrix[carda[0],carda[1]] < 1);
                
                                                    
                Console.WriteLine($"first card is {matrix[carda[0], carda[1]]}");

                while (cardb[0] < 0 || cardb[0] >= (sizeofmatrix))
                {
                    Console.WriteLine($"please enter row for the second card: ");
                    cardb[0] = (Convert.ToInt32(Console.ReadLine()) - 1);
                }
                while (cardb[1] <  0  || cardb[1] >= (sizeofmatrix))
                {
                        Console.WriteLine($"please enter column for the second card ");
                    cardb[1] = (Convert.ToInt32(Console.ReadLine()) - 1);
                }
                Console.WriteLine($"second card is {matrix[cardb[0], cardb[1]]}");

                if (matrix[carda[0], carda[1]] == matrix[cardb[0], cardb[1]] && score < ((sizeofmatrix * sizeofmatrix) / 2))
                {
                    matrix[carda[0], carda[1]] = 0;
                    matrix[cardb[0], cardb[1]] = 0;
                    score++;
                    pairsleft = (((sizeofmatrix * sizeofmatrix) / 2) - score);
                    Console.WriteLine($"you found pair!!  your score is {score}, {pairsleft} more pairs to find....");
                }
                   
                
                if (score == (sizeofmatrix * sizeofmatrix) / 2)
                {
                    break;
                }
                

            }
        }



        private static void printthematrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($" {matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }


        private static void getmatrix (int [,] matrix, int sizeofmatrix)
        {
            Random randomnumber = new Random();

            for (int h = 0; h < ((sizeofmatrix* sizeofmatrix)/2); h++)
            {
                
                int counter = 0;
                while (counter < 2 && h <= ((sizeofmatrix * sizeofmatrix) / 2))
                {
                    int x = randomnumber.Next(0, sizeofmatrix);
                    int y = randomnumber.Next(0, sizeofmatrix);

                    if (matrix[x, y] < 1)
                    {
                        matrix[x, y] = h+1;
                        counter++;
                    }
                    
                    
                }
            }
    }   }
}

