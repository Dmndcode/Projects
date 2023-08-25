using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenorElemento
{
    class Encontrar
    {
        static void Main(string[] args)
        {
            // Exercício: Encontrando o Menor Peso de Sacas de Café

            // Você é um comerciante de café e recebeu uma entrega de sacas de café de diferentes pesos.
            // Cada saca de café tem um peso inteiro representando seu valor em quilogramas.
            int[] pesos = { 50, 42, 55, 38, 60 };
            // Você deseja escrever um algoritmo para encontrar a saca de café mais leve entre as entregues.

            int menorPeso = EncontrarMenorPeso(pesos);
            Console.WriteLine($"O peso da saca de café mais leve na entrega é: {menorPeso} kg");
        }
        static int EncontrarMenorPeso(int[] pesos)
        {
            int menorPeso = pesos[0];
            for (int i = 1; i < pesos.Length; i++) 
            {
                if (pesos[i] < menorPeso)
                {
                    menorPeso = pesos[i];
                }
            }
            return menorPeso;
        }
    }
}
