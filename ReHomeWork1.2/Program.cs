using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Numerics;
using System.Collections;


namespace ReHomeWork1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputDataFunction(Algorithm.Factorial, "Factorial"); // logn 
            OutputDataArray(FindTimeTreeSort.TreeSort, "TreeSort"); //n^2 но это не точно
            OutputDataArray(Algorithm.CombSort, "CombSort"); //n 
            OutputDataArray(Algorithm.GnomeSort, "GnomeSort"); //nlogn 
            OutputDataMatrix(Algorithm.CompositionMatrix, "CompositionMatrix"); //k^n
            OutputDataFunction(Algorithm.CombinationNum, "CombinationNum", 11); //n!
        }

        public static void CreateArray(int[] array, int count)
        {
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                array[i] = rnd.Next(1, 9);
            }
        }
        static int FindAverage(List<int> time)
        {
            int sum = 0;
            for (int i = 0; i < time.Count; i++)
            {
                sum += time[i];
            }
            return sum / time.Count;
        }
        static void OutputDataFunction(Action<int> f, string nameAction, int max = 200) //Для Обычного числа
        {
            List<int> time = new List<int>();

            using (StreamWriter file = new StreamWriter("Time.txt", true))
            {
                file.Write($"{nameAction};;");

                for (int j = 0; j < max; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        FindTime(f, time, j);
                    }
                    int average = FindAverage(time);

                    file.Write($"{average};");
                    time.Clear();
                }

                file.WriteLine();
                file.Close();
            }
        }

        public static void FindTime(Action< int> f, List<int> time, int count)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            f(count);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}", ts.Ticks);
            Console.WriteLine(elapsedTime);

            time.Add(Convert.ToInt32(elapsedTime));
        }

        static void OutputDataArray(Action<int[], int> f, string nameAction) //Для массива
        {
            List<int> time = new List<int>();

            using (StreamWriter file = new StreamWriter("Time.txt", true))
            {
                file.Write($"{nameAction};;");

                for (int j = 1; j <= 200; j++)
                {
                    int[] array = new int[j];
                    CreateArray(array,j);

                    for (int i = 0; i < 5; i++)
                    {
                        FindTimeArr(array, f, time, j);
                    }
                    int average = FindAverage(time);

                    file.Write($"{average};");
                    time.Clear();
                }

                file.WriteLine();
                file.Close();
            }
        }

        public static void FindTimeArr(int[] array, Action<int[], int> f, List<int> time, int count)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            f(array, count);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}", ts.Ticks);
            Console.WriteLine(elapsedTime);

            time.Add(Convert.ToInt32(elapsedTime));
        }
        static void OutputDataMatrix(Action<int[][,], int> f, string nameAction)
        {
            List<int> time = new List<int>();

            using (StreamWriter file = new StreamWriter("Time.txt", true))
            {
                file.Write($"{nameAction};;");

                for (int j = 0; j < 20; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        FindTimeMatrix(f, time, j + i);
                    }
                    int average = FindAverage(time);

                    file.Write($"{average};");
                    time.Clear();
                }

                file.WriteLine();
                file.Close();
            }
        }
        public static void FindTimeMatrix(Action<int[][,], int> f, List<int> time, int count)
        {
            int[][,] matrix = new int[2][,];
            matrix[0] = CreateMatrix(count);
            matrix[1] = CreateMatrix(count);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            f(matrix, count);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}", ts.Ticks);
            Console.WriteLine(elapsedTime);

            time.Add(Convert.ToInt32(elapsedTime));
        }

        public static int[,] CreateMatrix(int count)
        {
            int[,] matrix = new int[count, count];
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    matrix[i, j] = rnd.Next(1, 9);
                }
            }
            return matrix;
        }
    }
}
