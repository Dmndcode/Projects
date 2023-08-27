using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buscaBinaria.Helpers
{
    public static class BoundsHelper
    {
        public static bool IsOutsideBounds(int[] array, int target)
        {
            return target < array[0] || target > array[array.Length - 1];
        }
    }
}
