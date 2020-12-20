using System;
using System.Diagnostics;
using System.Threading;

namespace ComparisonCountSortAndDistributionSort
{
    class Program
    {
        static int[] ComparisonCountingSort(int[] A)
        {
            int[] S = new int[A.Length];
            int[] counts = new int[A.Length];

           for(int i =0; i < counts.Length; i++)
            {
                counts[i] = 0;
            }
           for(int i = 0; i< A.Length-1;i++)
            {
                for(int j = i +1; j < A.Length;j++)
                {
                    if (A[i] < A[j])
                        counts[j]++;
                    else counts[i]++;
                }
            }
           for(int i = 0; i< A.Length;i++)
            {
                S[counts[i]] = A[i];
            }
            return S;

        }
        static int[] DistributionCountingSort(int[] A)
        {
            int l = A[0], u = A[0];
            for(int i = 0; i <A.Length;i++)
            {
                if (A[i] < l)
                {
                    l = A[i];
                }
                else if (A[i] > u)
                {
                    u = A[i];
                }
            }
            int[] D = new int[u];
            for(int i = 0; i < u;i++)
            {
                D[i] = 0;
            }
            for(int i = 0; i < A.Length; i++)
            {
                D[A[i] - l] = D[A[i] - l] + 1;
            }
            for(int i = 1;i< u;i++)
            {
                D[i] = D[i] + D[i - 1]; 
            }
            int[] S = new int[A.Length];
            for(int i = A.Length-1;i>=0;i--)
            {
                int j = A[i] - l;
                S[D[j] - 1] = A[i];
                D[j] = D[j] - 1;
            }
            return S;
        }
        static void Main(string[] args)
        {
               Random rand = new Random();
               int[] A = new int[1000000];

               int j = 0;
               while (j < 1000000)
               {
                   A[j] = rand.Next(1 << 10000);
                   j++;
               }

            Stopwatch watch = new Stopwatch();
            watch.Start();


            int[] SC = ComparisonCountingSort(A);

            watch.Stop();
            Console.WriteLine("Comparison Counting sort: " + watch.Elapsed);


          /*  foreach(int i in SC)
                    Console.WriteLine(i + " "); 

            */
            Stopwatch watch2 = new Stopwatch();
            watch2.Start();

            int[] SD = DistributionCountingSort(A);


            Console.WriteLine("Comparison Counting sort: " + watch2.Elapsed);

            watch2.Stop();
            /* foreach(int i in SD)
                Console.WriteLine(i + " "); */


            Console.ReadLine();
        }
    }
}
