using System.Data.Entity.ModelConfiguration;
using BookStore.Dominio;

namespace BookStore.Mapeamento
{
    public class LivroMap : EntityTypeConfiguration<Livro>
    {
        public LivroMap()
        {
            ToTable("Livro");

            HasKey(chave => chave.Id);

            Property(prop => prop.Nome).HasMaxLength(70).IsRequired();
            Property(prop => prop.ISBN).HasMaxLength(30).IsRequired();
            Property(prop => prop.DataLancamento).IsRequired();
        }
    }
}