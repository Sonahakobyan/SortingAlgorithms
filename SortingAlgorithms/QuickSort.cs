using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingAlgorithms
{
    /// <summary>
    /// Quick Sort class
    /// </summary>
    class QuickSort : AbstractSort
    {
        /// <summary>
        /// Clone of the defined array
        /// </summary>
        private Int32[] arrayClone = Array;

        /// <summary>
        /// Swap two elements in the array
        /// </summary>
        /// <param name="arr">Array</param>
        /// <param name="i">The first index to swap</param>
        /// <param name="j">The second index to swap</param>
        private void Swap(Int32[] arr, Int32 i, Int32 j)
        {
            Int32 tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        /// <summary>
        /// Return pivot for given array and indexes
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int Partition(Int32[] arr, Int32 begin, Int32 end)
        {
            int tmp = arr[begin];
            int j = end;
            int i = begin;

            while (true)
            {
                while (arr[j] > tmp)
                {
                    j--;
                }
                while (arr[i] < tmp)
                {
                    i++;
                }
                if (i < j)
                {
                    Swap(arr, i, j);
                }
                else
                {
                    return j;
                }
            }
        }

        /// <summary>
        /// Recursive Quick Sort method 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private void quickSort(Int32[] arr, int begin, int end)
        {
            if (begin >= end)
            {
                return;
            }
            Int32 pivot = Partition(arr, begin, end);
            quickSort(arr, begin, pivot);
            quickSort(arr, pivot + 1, end);
        }

        public override Int32[] Sort()
        {
            //Running Time
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();

            quickSort(arrayClone, 0, Size - 1);

            watch.Stop();
            this.Time = watch.ElapsedMilliseconds;

            //Usage Memory
            this.Memory = Size * sizeof(Int32);

            return arrayClone;
        }
    }
}
