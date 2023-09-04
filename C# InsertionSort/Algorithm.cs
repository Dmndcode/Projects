using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using InsertionSort.Models;
using InsertionSort.Component;

namespace InsertionSort
{
    class Algorithm
    {
        static void Main()
        {
            string diretorio = @"C:\Projects\InsertionSort\";
            // Caminho para o arquivo JSON
            string livrosJson = "livrosq.json";
            string caminhoArquivo = Path.Combine(diretorio, livrosJson);
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                List<Livro> listaDeLivros = JsonSerializer.Deserialize<List<Livro>>(json);

                sort.InsertionSort(listaDeLivros);

                // Console.WriteLine("Lista de Livros Ordenada por Título:");
                Console.WriteLine("Lista de Livros Ordenada por Ano de Publicação:\n");
                foreach (var livro in listaDeLivros)
                {
                    Console.WriteLine($"Título: {livro.Titulo}");
                    Console.WriteLine($"Autor: {livro.Autor}");
                    Console.WriteLine($"Ano de Publicação: {livro.AnoPublicacao}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"O arquivo JSON não foi encontrado em {caminhoArquivo}.");
            }
        }
    }
}