using System;
using System.Diagnostics;

namespace SortingAlgorithms
{
    public class InsertionSort : AbstractSort
    {
        public override Int32[] Sort()
        {
            //Calculating running time 
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();

            Int32[] arrayClone = Array;
            for (int i = 0; i < Size - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (arrayClone[j - 1] > arrayClone[j])
                    {
                        int tmp = arrayClone[j - 1];
                        arrayClone[j - 1] = arrayClone[j];
                        arrayClone[j] = tmp;
                    }
                    j--;
                }
            }

            watch.Stop();
            this.Time = watch.ElapsedMilliseconds;

            //Usage memory
            this.Memory = Size * sizeof(Int32);
            return arrayClone;
        }
    }
}
