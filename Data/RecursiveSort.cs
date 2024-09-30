using Sorting_Algorithms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Data
{
    internal class RecursiveSort<T> : ISort<T> where T : IComparable<T>
    {
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
