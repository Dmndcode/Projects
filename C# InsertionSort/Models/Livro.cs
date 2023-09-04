using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort.Models
{
    public class Livro : IComparable<Livro>
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }

        public int CompareTo(Livro other)
        {
            if (other == null)
                return 1;

            // return string.Compare(Titulo, other.Titulo, StringComparison.Ordinal);
            return AnoPublicacao.CompareTo(other.AnoPublicacao);
        }
    }
}
