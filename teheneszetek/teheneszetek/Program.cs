using System;
using System.Collections.Generic;
using System.Linq;

namespace teheneszetek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //beolvasas
            int N, M;
            string[] tomb = Console.ReadLine().Split(' ');
            N = int.Parse(tomb[0]);
            M = int.Parse(tomb[1]);

            List<int> teheneszetek = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> folyamat = Enumerable.Repeat(-1, N).ToList();
            List<int> helyek = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<List<int>> arak = new List<List<int>>();

            for (int i = 0; i < N; i++)
            {
                arak.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            }

            int index = 0;
            int MinAr = int.MaxValue;
            List<int> valasz = new List<int>();

            while (true)
            {
                bool kihagy = false;
                if (index >= N)
                {
                    kihagy = true;
                    int osszeg = 0;
                    for (int i = 0; i < N; i++)
                    {
                        osszeg += arak[i][folyamat[i]] * teheneszetek[i];
                    }

                    if (osszeg <= MinAr)
                    {
                        valasz = folyamat.ToList();
                        MinAr = osszeg;
                    }

                    index -= 1;
                    helyek[folyamat[index]] += teheneszetek[index];
                    folyamat[index] = -1;
                    index -= 1;
                    helyek[folyamat[index]] += teheneszetek[index];
                }

                if (!kihagy)
                {
                    do
                    {
                        folyamat[index] += 1;
                    } while (folyamat[index] < M && helyek[folyamat[index]] - teheneszetek[index] < 0);

                    if (folyamat[index] >= M)
                    {
                        folyamat[index] = -1;
                        index -= 1;

                        if (index < 0)
                        {
                            break;
                        }
                        helyek[folyamat[index]] += teheneszetek[index];
                    }
                    else
                    {
                        helyek[folyamat[index]] -= teheneszetek[index];
                        index += 1;
                    }
                }
            }

            Console.WriteLine(MinAr);
            foreach (var item in valasz)
            {
                Console.Write(item + 1 + " ");
            }
            Console.WriteLine();
        }
    }
}
