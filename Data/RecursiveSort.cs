using Sorting_Algorithms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Data
{
    /// <summary>
    /// QuickSort
    /// courtesy of Daniel Simionescu
    /// https://danielsimionescu.com/csharp/arrays/quicksort-generics.html
    /// </summary>
    /// <typeparam name="T">make sure type T is comparable</typeparam>
    internal class RecursiveSort<T> : ISort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Traditional QuickSort with generic typing.
        ///     - Selects a pivot element (in this case, the middle element).
        ///     - Divides the array into two subarrays: 
        ///         * Left subarray: elements less than the pivot.
        ///         * Right subarray: elements greater than the pivot.
        ///     - Recursively sorts each subarray.
        /// </summary>
        /// <param name="array">List of T that is to be sorted</param>
        /// <param name="left">Starting index of the current subarray</param>
        /// <param name="right">Ending index of the current subarray</param>
        public void Sort(IList<T> array, int left, int right)
        {
            int i = left;
            int j = right;

            var pivot = array[left + (right - left) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                    i++;

                while (array[j].CompareTo(pivot) > 0)
                    j--;

                if (i <= j)
                {
                    var tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
                Sort(array, left, j);

            if (i < right)
                Sort(array, i, right);
        }
    }

}
