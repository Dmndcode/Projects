using System;
class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        int numSecreto = rnd.Next(1, 7);
        int tentativas = rnd.Next(2, 4);
        Console.WriteLine("Número secreto: " + numSecreto); // Apenas para teste

        while (tentativas > 0)
        {
            Console.WriteLine("Digite um número entre 1 e 7: ");
            int palpite = int.Parse(Console.ReadLine());

            if ( palpite == numSecreto ) { Console.WriteLine("Você acertou, Parabéns!");return; }
            else { tentativas--; Console.WriteLine("Você errou! Tentativas restantes: " + tentativas); }
        }
        Console.WriteLine("Você perdeu! O número secreto era: " + numSecreto);
    }
}