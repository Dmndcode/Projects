using System;
using System.Collections.Generic;

namespace InsertionSort.Component
{
    public static class sort
    {
        public static void InsertionSort<T>(List<T> list) where T : IComparable<T>
        {
            int n = list.Count;
            for (int i = 1; i < n; i++)
            {
                T currentElement = list[i];
                int j = i - 1;

                while (j >= 0 && list[j].CompareTo(currentElement) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = currentElement;
            }
        }
    }
}
