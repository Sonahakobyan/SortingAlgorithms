using System;
using System.Diagnostics;


namespace SortingAlgorithms
{
    class BubbleSort : AbstractSort
    {
        public override Int32[] Sort()
        {
            //Calculating running time 
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();

            Int32[] arrayClone = Array;

            int tmp = arrayClone[0];
            for (int i = 0; i < Size; i++)
            {
                for (int j = i + 1; j < Size; j++)
                {
                    if (arrayClone[i] > arrayClone[j])
                    {
                        tmp = arrayClone[i];
                        arrayClone[i] = arrayClone[j];
                        arrayClone[j] = tmp;
                    }
                }
            }

            watch.Stop();
            this.Time = watch.ElapsedMilliseconds;

            //Usage memory
            this.Memory = Size * sizeof(Int32);
            return arrayClone;
        }

        public override string ToString()
        {
            string s = this.GetType().Name + "\n\r";
            s += "Running Time: " + Time + "ms\n\r";
            s += "Memory usage: " + Memory + "byte\n\r";
            //for (int i = 0; i < Size; i++)
            //{
            //    s += Array[i] + " ";
            //}
            return s;
        }
    }
}
