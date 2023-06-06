using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Escreva uma série de números separados por virgula");
        string input = Console.ReadLine() ?? string.Empty;
        String[]? numbers = input?.Split(',');
        int max = int.MinValue;

        foreach (String number in numbers ?? Array.Empty<string>())
        {
            if (int.TryParse(number?.Trim(), out int currentNmbr)) 
            {
                if (currentNmbr > max) { max = currentNmbr; }
            }
            else { Console.WriteLine("Entrada inválida: " + number); break; }
            
        }
        Console.WriteLine("O maior numero da série é: " + max);
    }
}
