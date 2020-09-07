using System.Data.Entity.ModelConfiguration;
using BookStore.Dominio;

namespace BookStore.Mapeamento
{
    public class AutorMap : EntityTypeConfiguration<Autor>
    {
        public AutorMap()
        {
            ToTable("Autor");
            HasKey(chave => chave.Id);
            Property(prop => prop.Nome).HasMaxLength(60).IsRequired();

            // Um autor tem muitos livros e um livro tem mais de um autor (NxN)
            HasMany(autor => autor.Livros)
                .WithMany(livro => livro.Autores)
                .Map(livroAutor => livroAutor.ToTable("LivroAutor"));
        }
    }
}