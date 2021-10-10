using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Numerics;
using System.Collections;
using System.Linq;

namespace ReHomeWork1._2
{
    class Algorithm
    {
        public static void Factorial(int count) //
        {
            int result = 1;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j <= count; j++)
                {
                    result *= count;
                }
            }
        }
        public static void CombSort(int[] array, int count) //
        {
            var arrayLength = count;
            var currentStep = count - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }

                currentStep = GetNextStep(currentStep);
            }

            for (var i = 1; i < arrayLength; i++)
            {
                var swapFlag = false;
                for (var j = 0; j < arrayLength - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }
        }
        static void Swap(ref int value1, ref int value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }

        static int GetNextStep(int s)
        {
            s = s * 1000 / 1247;
            return s > 1 ? s : 1;
        }

        public static void GnomeSort(int[] inArray, int count) // 
        {
            int i = 1;
            int j = 2;
            while (i < count)
            {
                if (inArray[i - 1] < inArray[i])
                {
                    i = j;
                    j += 1;
                }
                else
                {
                    GnomeSwap(inArray, i - 1, i);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j += 1;
                    }
                }
            }
        }
        static void GnomeSwap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void CompositionMatrix(int[][,] array, int count) //
        {
            int[,] C = new int[count, count];

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    for (int k = 0; k < count; k++)
                    {
                        C[i, j] += array[0][i, k] * array[1][k, j];
                    }
                }
            }
        }

        public static void CombinationNum(int n) //
        {
            CombinationNum(n, Enumerable.Range(1, n).ToArray());
        }

        private static void SwapCombinationNum(ref int i, ref int j)
        {
            int t = i;
            i = j;
            j = t;
        }

        private static void CombinationNum(int n, int[] arr)
        {
            for (int i = 0; i < n; i++)
            {
                CombinationNum(n - 1, arr);
                int j = n % 2 == 0 ? 0 : i;
                SwapCombinationNum(ref arr[j], ref arr[n - 1]);
            }
        }
    }

    public class TreeNode //
    {
        public TreeNode(int data)
        {
            Data = data;
        }

        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }
        public int[] Transform(List<int> elements = null)
        {
            if (elements == null)
            {
                elements = new List<int>();
            }

            if (Left != null)
            {
                Left.Transform(elements);
            }

            elements.Add(Data);

            if (Right != null)
            {
                Right.Transform(elements);
            }

            return elements.ToArray();
        }
    }
    class FindTimeTreeSort
    {
        public static void TreeSort(int[] array, int count)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < count; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }
        }

    }
}
