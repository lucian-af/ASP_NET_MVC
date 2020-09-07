using System.Collections.Generic;

namespace BookStore.Models
{
    public class Autor
    {
        public Autor()
        {
            this.Livros = new List<Livro>();
        }

        public int Id { get; set; }
        public int Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}