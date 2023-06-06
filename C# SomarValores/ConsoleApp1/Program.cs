using System;
class Program
{
    public static void Main(string[] args)
    {
        int sum = 0;
        int multiply = 1;
        decimal divide = 0;
        string input;

        while (true)
        {
            Console.WriteLine("Insira um número ou digite 'ok' para sair: ");
            input = Console.ReadLine();

            if (input.ToLower() == "ok") {
                break;
            }

            int number;
            if (int.TryParse(input, out number) && number != 0)
            {
                sum += number;
                multiply *= number;
                divide = (decimal)multiply / sum;
            }
            else
            {
                if (number == 0) { Console.WriteLine("Uma divisão por zero não possui um valor numérico válido."); }
                else { Console.WriteLine("Valor Inválido, Por gentileza insira um númeo ou digite 'ok'. "); }
            }
        }
        Console.WriteLine("A soma dos valors é: " + sum);
        Console.WriteLine("A multiplicação dos valors é: " + multiply);
        Console.WriteLine("A divisão do total de soma por total de multiplicação é: " + divide);
    }
}