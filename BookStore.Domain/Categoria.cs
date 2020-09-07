using System.Collections.Generic;

namespace BookStore.Dominio
{
    public class Categoria
    {
        public Categoria()
        {
            this.Livros = new List<Livro>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }
}