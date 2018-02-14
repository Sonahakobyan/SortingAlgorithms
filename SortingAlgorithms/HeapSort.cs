using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortingAlgorithms
{
    class HeapSort : AbstractSort
    {
        private Int32[] arrayClone = Array;
        private Int32 heapSize = Size - 1;

        private void Swap(Int32[] arr, Int32 i, Int32 j)
        {
            Int32 tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
            return;
        }

        private void BuildHeap(Int32[] arr)
        { 
            for (Int32 i = heapSize/ 2; i >= 0; i--)
            {
                Heapify(arr, i);
            }
        }
        
        private void Heapify(Int32[] arr, Int32 index)
        {
            Int32 left = 2 * index;
            Int32 right = 2 * index + 1;
            Int32 maxIndex = index;

            if (left <= heapSize && arr[left] > arr[index])
            {
                maxIndex = left;
            }

            if (right <= heapSize && arr[right] > arr[maxIndex])
            {
                maxIndex = right;
            }

            if (maxIndex != index)
            {
                Swap(arr, index, maxIndex);
                Heapify(arr, maxIndex);
            }
        }

        public override Int32[] Sort()
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();

            BuildHeap(arrayClone);
            for (int i = heapSize; i >= 0; i--)
            {
                Swap(arrayClone, 0, i);
                heapSize--;
                Heapify(arrayClone, 0);
            }

            watch.Stop();
            this.Time = watch.ElapsedMilliseconds;

            //Memory
            Memory = Size * sizeof(Int32);

            return arrayClone;
        }        
    }
}
