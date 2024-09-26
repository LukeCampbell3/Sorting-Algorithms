using Sorting_Algorithms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Data
{
    internal class IterativeSort<T> : ISort<T> where T : IComparable<T> 
    {
        public void Sort(List<T> array, int left, int right)
        {
            throw new NotImplementedException();
        }

        //public int CompareTo(T? other)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
