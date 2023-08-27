using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buscaBinaria.Helpers
{
    class ArrayHelper
    {
        public static int BinarySearch(int[] array, int target)
        {
            int left = 0;             // Índice esquerdo do intervalo de busca
            int right = array.Length - 1;  // Índice direito do intervalo de busca

            while (left <= right)  // Enquanto o intervalo de busca não estiver vazio
            {
                int mid = left + (right - left) / 2;  // Calcula o índice do elemento do meio

                if (array[mid] == target)  // Se o elemento do meio é o alvo
                    return mid;  // Retorna o índice onde esta o alvo

                if (array[mid] < target)  // Se o elemento do meio é menor que o alvo
                    left = mid + 1;  // Mover o índice esquerdo para a direita do meio
                else
                    right = mid - 1;  // Caso contrário, mover o índice direito para a esquerda do meio
            }

            return -1;  // Retorna -1 se o elemento não foi encontrado no array
        }
    }
}