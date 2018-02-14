using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    class Program
    {
        public static int[] getNumFromInput(string s)
        {
            string[] splitArr;
            int size;
            int[] nums;

            if (s.Contains('-'))
            {
                splitArr = s.Split('-');
                size = int.Parse(splitArr[1]) - int.Parse(splitArr[0]) + 1;
            }
            else
            {
                splitArr = s.Split(',');
                size = splitArr.Length;
            }

            nums = new int[size];

            if (s.Contains('-'))
            {
                int j = int.Parse(splitArr[0]);
                for (int i = 0; i < size; i++)
                {
                    nums[i] = j;
                    j++;
                }
            }

            else
            {
                for (int i = 0; i < size; i++)
                {
                    nums[i] = int.Parse(splitArr[i]);
                }
            }

            return nums;
        }

        static void PrintArray(Int32[] arr)
        {
            foreach (Int32 i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the size of an array that you want to sort: ");

            int size;
            Int32.TryParse(Console.ReadLine(), out size);
            AbstractSort.Size = size;

            Console.WriteLine("Select which algorithm you want to perform:" +
                                "\n\r1.Insertion sort" +
                                "\n\r2.Bubble sort" +
                                "\n\r3.Quick sort" +
                                "\n\r4.Heap sort" +
                                "\n\r5.Merge sort" +
                                "\n\r6.All");

            string inputNum = Console.ReadLine();
            int[] allNums = getNumFromInput(inputNum);

            List<AbstractSort> list = new List<AbstractSort>();
            if (allNums.Contains(6))
            {
                list.Add(new InsertionSort());
                list.Add(new BubbleSort());
                list.Add(new QuickSort());
                list.Add(new HeapSort());
                list.Add(new MergeSort());
            }
            else
            {
                foreach (int item in allNums)
                {
                    switch (item)
                    {
                        case 1:
                            list.Add(new InsertionSort());
                            break;
                        case 2:
                            list.Add(new BubbleSort());
                            break;
                        case 3:
                            list.Add(new QuickSort());
                            break;
                        case 4:
                            list.Add(new HeapSort());
                            break;
                        case 5:
                            list.Add(new MergeSort());
                            break;
                    }
                }
            }

            foreach (AbstractSort item in list)
            {
                item.Sort();
            }

            list = list.OrderBy(x => x.Time).ToList();

            foreach (AbstractSort item in list)
            {
                if (item == list.ElementAt(0))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}