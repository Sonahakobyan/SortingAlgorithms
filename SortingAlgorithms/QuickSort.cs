using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingAlgorithms
{
    class QuickSort : AbstractSort
    {
        private Int32[] arrayClone = Array;

        private void Swap(Int32[] arr, Int32 i, Int32 j)
        {
            Int32 tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

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
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();

            quickSort(arrayClone, 0, Size - 1);

            watch.Stop();
            this.Time = watch.ElapsedMilliseconds;

            //Memory
            return arrayClone;
        }
    }
}
