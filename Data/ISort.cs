using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Services
{
 /// <summary>
 /// Makes sure a Sort method gets implemented
 /// </summary>
 /// <typeparam name="T">makes sure T type is comparable</typeparam>
    public interface ISort<T> where T : IComparable<T> 
    {
        /// <summary>
        /// Outline for sorting algorithm
        /// implemented by both recursive and iterative classes
        /// </summary>
        /// <param name="array">Array of type T that should be sorted</param>
        /// <param name="left">int of where the left bound should be set</param>
        /// <param name="right">int of where the right bound should be set</param>
        public void Sort(IList<T> array, int left, int right);
    }
}
