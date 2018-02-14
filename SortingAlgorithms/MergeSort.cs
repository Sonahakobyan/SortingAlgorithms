using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingAlgorithms
{
    class MergeSort : AbstractSort
    {
        private Int32[] arrayClone = Array;
        private Int32 m;
        private void Swap(Int32[] arr, Int32 i, Int32 j)
        {
            Int32 tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
            return;
        }

        //Merge Function
        private void Merge(Int32[] arr, Int32 begin, Int32 mid, Int32 end)
        {
            Int32 i, j, index;
            Int32 n1 = mid - begin + 1;
            Int32 n2 = end - mid;
            Int32[] a1 = new Int32[n1];
            Int32[] a2 = new Int32[n2];
            index = begin;

            for (i = 0; i < n1; i++)
            {
                a1[i] = arr[index];
                index++;
            }
            for (j = 0; j < n2; j++)
            {
                a2[j] = arr[index];
                index++;
            }

            i = 0;
            j = 0;
            index = begin;

            while (i < n1 && j < n2)
            {
                if (a1[i] < a2[j])
                {
                    arr[index] = a1[i];
                    ++i;
                }
                else
                {
                    arr[index] = a2[j];
                    ++j;
                }
                ++index;
            }

            while (i < n1)
            {
                arr[index] = a1[i];
                ++i;
                ++index;
            }

            while (j < n2)
            {
                arr[index] = a2[j];
                ++j;
                ++index;
            }

            m += (n1 + n2) * sizeof(Int32);
        }

        private void mergeSort(Int32[] arr, Int32 begin, Int32 end)
        {
            if (begin >= end)
            {
                return;
            }

            Int32 mid = begin + (end - begin) / 2;
            mergeSort(arr, begin, mid);
            mergeSort(arr, mid + 1, end);
            Merge(arr, begin, mid, end);
        }

        public override Int32[] Sort()
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();

            mergeSort(arrayClone, 0, Size - 1);

            watch.Stop();
            this.Time = watch.ElapsedMilliseconds;

            //Memory
            Memory = m + (Size * sizeof(Int32));
            return arrayClone;
        }

    }
}
