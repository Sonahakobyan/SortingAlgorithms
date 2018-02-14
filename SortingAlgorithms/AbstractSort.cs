using System;

namespace SortingAlgorithms
{
    public abstract class AbstractSort
    {
        private static Int32[] array;
        private static Int32 size;

        public static Int32 Size
        {
            get
            {
                return size;
            }
            set
            {
                array = null;
                size = value;
            }
        }

        protected static Int32[] Array
        {
            get
            {
                if (array == null)
                {
                    Random random = new Random(DateTime.Now.Millisecond);
                    array = new Int32[Size];
                    for (int i = 0; i < Size; i++)
                    {
                        array[i] = random.Next(10, 100);
                    }
                }

                return (Int32[])array.Clone();
            }
        }

        public long Time { get; protected set; }
        public long Memory { get; protected set; }

        public abstract Int32[] Sort();

        public override string ToString()
        {
            string s = this.GetType().Name + "\n\r";
            s += "Running Time: " + Time + "ms\n\r";
            s += "Memory usage: " + Memory + "byte\n\r";
            return s;
        }
    }
}