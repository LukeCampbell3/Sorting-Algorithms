using Sorting_Algorithms.Services;

namespace Sorting_Algorithms.Data
{
    /// <summary>
    /// BubbleSort
    /// coutesy of 
    /// 
    /// </summary>
    /// <typeparam name="T">Makes sure type T is comparable</typeparam>
    public class IterativeSort<T> : ISort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Small values bubble to the front of the array
        /// Each value is compared and swapped if smaller than current value
        /// (thus resulting in the O(n^2) complexity)
        /// </summary>
        /// <param name="values">List of T that is to be sorted</param>
        /// <param name="left">int of starting index</param>
        /// <param name="right">int of ending index</param>
        public void Sort(IList<T> values, int left, int right)
        {
            for (int i = left; i < right; i++)
            {
                for (int j = left; j < right - (i - left); j++)
                {
                    if (values[j].CompareTo(values[j + 1]) > 0)
                    {
                        // Swap values[j] and values[j + 1]
                        T temp = values[j];
                        values[j] = values[j + 1];
                        values[j + 1] = temp;
                    }
                }
            }
        }
    }
}
