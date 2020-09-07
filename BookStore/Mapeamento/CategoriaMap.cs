using System.Data.Entity.ModelConfiguration;
using BookStore.Dominio;

namespace BookStore.Mapeamento
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");
            HasKey(chave => chave.Id);
            Property(prop => prop.Nome).HasMaxLength(30).IsRequired();

            // Uma categoria tem muitos livros e um livro tem uma categoria obrigatoria (1xN)
            HasMany(categoria => categoria.Livros).WithRequired(livro => livro.Categoria);
        }
    }
}