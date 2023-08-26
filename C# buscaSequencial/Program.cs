using buscaSequencial.Models;
using buscaSequencial.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace buscaSequencial
{
    class Program
    {
        static bool BuscaCafe(TipoDeCafe cafe, string termoBusca)
        {
            string nomeSemAcentos = StringHelper.RemoverAcentos(cafe.Nome.ToLower());
            string termoSemAcentos = StringHelper.RemoverAcentos(termoBusca.ToLower());

            return nomeSemAcentos.Contains(termoSemAcentos);
        }

        static void Main(string[] args) 
        {
            List<TipoDeCafe> tiposDeCafes = new List<TipoDeCafe> {
                new TipoDeCafe { Nome = "Café Arábica", Descricao = "Um café de sabor suave e aromático, cultivado em regiões de alta altitude." },
                new TipoDeCafe { Nome = "Café Robusta", Descricao = "Conhecido por sua robustez e sabor intenso, frequentemente usado em blends de espresso." },
                new TipoDeCafe { Nome = "Café Kona", Descricao = "Originário do Havaí, este café possui notas frutadas e é cultivado em solos vulcânicos." },
                new TipoDeCafe { Nome = "Café Geisha", Descricao = "Uma variedade de café especial conhecida por seus sabores florais e complexidade." }
            };

            Console.Write("Insira o nome de um tipo de café: ");
            string nomeBuscado = Console.ReadLine().Trim().ToLower();

            bool encontrado = false;
            foreach (var cafe in tiposDeCafes)
            {
                if (BuscaCafe(cafe, nomeBuscado))
                {
                    Console.WriteLine($"Tipo de Café: {cafe.Nome}");
                    Console.WriteLine($"Descrição: {cafe.Descricao}");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Tipo de café não encontrado.");
            }
        }
    }
}
