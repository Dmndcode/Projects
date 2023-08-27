using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using buscaBinaria.Helpers;
using buscaBinaria.Models;

namespace buscaBinaria
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            int[] sortedArray = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };

            ArrayModel arrayModel = new ArrayModel(sortedArray);

            int target = 72;

            if (BoundsHelper.IsOutsideBounds(arrayModel.Data, target))
            {
                Console.WriteLine($"O elemento {target} está fora dos limites do array.");
            }
            else
            {
                int resultIndex = ArrayHelper.BinarySearch(arrayModel.Data, target);

                if (resultIndex != -1)
                    Console.WriteLine($"Valor {target} encontrado no índice {resultIndex}");
                else
                    Console.WriteLine($"Valor {target} não encontrado na lista");

            }

            Console.ReadLine();
        }
    }
}
