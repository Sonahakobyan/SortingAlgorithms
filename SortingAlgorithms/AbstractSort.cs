﻿using System;

namespace SortingAlgorithms
{
    /// <summary>
    /// Abstract class as sorting classes base class
    /// </summary>
    public abstract class AbstractSort
    {
        /// <summary>
        /// Container for sortable elements
        /// </summary>
        private static Int32[] array;
        /// <summary>
        /// Size of container
        /// </summary>
        private static Int32 size;
        /// <summary>
        /// Running time of sorting algorithm
        /// </summary>
        public long Time { get; protected set; }
        /// <summary>
        /// Usage memory of sorting algorithm
        /// </summary>
        public long Memory { get; protected set; }
        /// <summary>
        /// Empty the array and set size of new container
        /// </summary>
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
        /// <summary>
        /// Return array clone. Initialize
        /// </summary>
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
                        array[i] = random.Next(10,1000);
                    }
                }

                return (Int32[])array.Clone();
            }
        }

        /// <summary>
        /// Sorting algorithm defination
        /// </summary>
        /// <returns></returns>
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