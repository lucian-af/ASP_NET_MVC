using System;
using System.Collections.Generic;

namespace BookStore.Dominio
{
    public class Livro
    {
        public Livro()
        {
            this.Autores = new List<Autor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string ISBN { get; set; }
        public DateTime DataLancamento { get; set; }

        public int CategoriaId { get; set; }
        /// <summary>
        /// Usar o virtual antes do tipo do atributo, faz com que ele traga a Categoria sobre demanda, 
        /// ou seja, somente se você precisar da Categoria na sua consulta ele trará a Categoria;
        /// </summary>
        public Categoria Categoria { get; set; }

        public ICollection<Autor> Autores { get; set; }
    }
}