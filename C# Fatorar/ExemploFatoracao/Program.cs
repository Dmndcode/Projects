using System;
using System.Numerics;

class Program
{
    public static void Main(string[] args)
    {
        BigInteger fatorial = 1;

        Console.WriteLine("Insira um número: ");
        int numero = int.Parse(Console.ReadLine());

        int i = numero;
        while (i >= 1) { fatorial *= i; i--; }
        string escreva = "o fatorial de " + numero + " é " + fatorial;
        Console.WriteLine(escreva);
    }
}