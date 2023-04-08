using System;

namespace Csharpproject
{
    class Program
    {
        static void Main(string[] args)
        {
            int IslandCount;
            int[,] sea = new int[15,15];
            Random random = new Random();

            for(int i = 0; i < sea.GetLength(0); i++)
            {
                for(int j = 0; j < sea.GetLength(1); j++)
                {
                    sea[i,j] = random.Next(10) < 4 ? 1:0;
                    if (sea[i, j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    Console.Write("   ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();

            IslandCount = IslandCounter(sea);
            Console.WriteLine($"\nthere is {IslandCount} islnds");
        }
        static int IslandCounter(int[,] sea)
        {
            int result = 0;
            for(int i = 0; i < sea.GetLength(0); i++)
            {
                for(int j = 0; j < sea.GetLength(1); j++)
                {
                    if(sea[i,j] == 1)
                    {
                        CountOneIsland(sea, i, j);
                        result++;
                    }
                }
            }
            return result;
        }
        static void CountOneIsland(int[,] s, int i, int j)
        {
            if(s[i,j] == 1)
            {
                s[i,j] = 0;
                if(i > 0 && s[i-1, j] == 1)
                {
                    CountOneIsland(s, i-1, j );
                }
                if(i < s.GetLength(0) - 1 && s[i+1, j] == 1)
                {
                    CountOneIsland(s, i+1, j );
                }
                if(j > 0  && s[i, j-1] == 1)
                {
                    CountOneIsland(s, i,j-1  );
                }
                if(j < s.GetLength(1) - 1 && s[i, j+1] == 1)
                {
                    CountOneIsland(s, i, j+1 );
                }
            }
            
        }
    }
}