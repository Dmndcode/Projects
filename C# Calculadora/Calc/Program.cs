using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Selecione: \n1 - Adição\n2 - Multiplicação\n3 - Subtração\n4 - Divisão\n5 - Sair");
        string menu = Console.ReadLine() ?? string.Empty;
        int opcao;

        if (int.TryParse(menu, out opcao))
        {
            if (opcao == 1)
            {
                Console.WriteLine("Digite os valores separados por vírgula:");
                string valores = Console.ReadLine() ?? string.Empty;
                string[] nums = valores?.Split(',');
                int soma = 0;
                foreach (string num in nums ?? Array.Empty<string>())
                {
                    if (int.TryParse(num.Trim(), out int parsedNum))
                    {
                        soma += parsedNum;
                    }
                }
                Console.WriteLine("A soma dos valores é: " + soma);
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Digite os valores separados por vírgula:");
                string valores = Console.ReadLine() ?? string.Empty;
                string[] nums = valores?.Split(',');
                int multiplica = 1;
                foreach (string num in nums ?? Array.Empty<string>())
                {
                    if (int.TryParse(num.Trim(), out int parsedNum))
                    {
                        multiplica *= parsedNum;
                    }
                }
                Console.WriteLine("O resultado da multiplicação é: " + multiplica);
            }
            else if (opcao == 3)
            {
                Console.WriteLine("Digite os valores separados por vírgula:");
                string valores = Console.ReadLine() ?? string.Empty;
                string[] nums = valores?.Split(',');
                int subtrai = 0;
                bool primeiroValor = true;

                foreach (string num in nums ?? Array.Empty<string>())
                {
                    if (int.TryParse(num.Trim(), out int parsedNum))
                    {
                        if (primeiroValor)
                        {
                            subtrai = parsedNum;
                            primeiroValor = false;
                        }
                        else
                        {
                            subtrai -= parsedNum;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido: " + num);
                    }
                }

                if (!primeiroValor)
                {
                    Console.WriteLine("O resultado da subtração é: " + subtrai);
                }
                else
                {
                    Console.WriteLine("Nenhum valor válido foi fornecido para a subtração.");
                }
            }
            else if (opcao == 4)
            {
                Console.WriteLine("Digite os valores separados por vírgula:");
                string valores = Console.ReadLine() ?? string.Empty;
                string[] nums = valores?.Split(',');
                int soma = 0;
                bool primeiroValor = true;

                foreach (string num in nums ?? Array.Empty<string>())
                {
                    if (int.TryParse(num.Trim(), out int parsedNum))
                    {
                        if (primeiroValor)
                        {
                            soma = parsedNum;
                            primeiroValor = false;
                        }
                        else
                        {
                            soma += parsedNum;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido: " + num);
                    }
                }

                if (!primeiroValor)
                {
                    Console.WriteLine("A soma dos valores é: " + soma);

                    Console.WriteLine("Digite o valor pelo qual deseja dividir a soma:");
                    if (int.TryParse(Console.ReadLine(), out int divisor) && divisor != 0)
                    {
                        int resultado = soma / divisor;
                        Console.WriteLine("O resultado da divisão é: " + resultado);
                    }
                    else
                    {
                        Console.WriteLine("Divisor inválido. Certifique-se de digitar um valor inteiro não nulo.");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum valor válido foi fornecido para a soma.");
                }
            }
        }
    }
}
