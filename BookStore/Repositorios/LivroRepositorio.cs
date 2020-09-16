using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BookStore.Context;
using BookStore.Dominio;
using BookStore.Repositorios.Interfaces;
using BookStore.ViewModels.Livro;

namespace BookStore.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private BookStoreDataContext _context;

        public LivroRepositorio(BookStoreDataContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public bool Inserir(Livro autor)
        {
            try
            {
                _context.Livros.Add(autor);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool Atualizar(Livro autor)
        {
            try
            {
                // O EF é inteligente o suficiente para interpretar o que mudou no autor em relação ao que está no banco
                _context.Entry(autor).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public void Excluir(int id)
        {
            Livro autor = _context.Livros.Find(id);
            _context.Livros.Remove(autor);
            _context.SaveChanges();
        }
        public Livro ObterPorId(int id)
        {
            return _context.Livros.Find(id);
        }
        public List<Livro> ObterPorNome(string nome)
        {
            return _context.Livros.Where(livro => livro.Nome.Contains(nome)).AsNoTracking()?.ToList();
        }
        public List<Livro> ObterTodos()
        {
            return _context.Livros.AsNoTracking().ToList();
        }
        public IEnumerable<EditorLivroViewModel> ObterTodosGrid()
        {
            return _context.Livros.Include(livro => livro.Categoria)
               .Select(livro => new EditorLivroViewModel
               {
                   Id = livro.Id,
                   Nome = livro.Nome,
                   ISBN = livro.ISBN,
                   DataLancamentoGrid = livro.DataLancamento,
                   Categoria = livro.Categoria,
                   CategoriaId = livro.CategoriaId
               })
               .AsNoTracking().ToList();
        }
        public List<Categoria> ObterTodasCategoria()
        {
            return _context.Categorias.ToList();
        }
    }
}