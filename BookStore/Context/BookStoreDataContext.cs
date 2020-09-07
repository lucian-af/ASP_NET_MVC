using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BookStore.Dominio;
using BookStore.Mapeamento;

namespace BookStore.Context
{
    public class BookStoreDataContext : DbContext
    {
        public BookStoreDataContext()
            : base(@"Server=localhost,1433;Database=BookStore;User ID=sa;Password=sql@2017")
        { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.Add(new AutorMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new LivroMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}