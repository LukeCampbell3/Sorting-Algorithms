using Sorting_Algorithms.Services;

namespace Sorting_Algorithms.Data
{
    public class IterativeSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> values, int left, int right)
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
