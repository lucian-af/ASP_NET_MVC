using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookStore.Context;
using BookStore.Dominio;
using BookStore.Repositorios.Interfaces;
using BookStore.ViewModels.Autor;

namespace BookStore.Repositorios
{
    public class AutorRepositorio : IAutorRepositorio
    {
        //  aqui abre a conexao
        private BookStoreDataContext _context;
        // gerando uma dependencia
        public AutorRepositorio(BookStoreDataContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            // Aqui encerra a conexao
            _context.Dispose();
        }
        public bool Inserir(Autor autor)
        {
            try
            {
                _context.Autores.Add(autor);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool Atualizar(Autor autor)
        {
            try
            {
                // O EF é inteligente o suficiente para interpretar o que mudou no autor em relação ao que está no banco
                _context.Entry<Autor>(autor).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool Excluir(int id)
        {
            try
            {
                Autor autor = _context.Autores.Find(id);
                _context.Autores.Remove(autor);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
        public Autor ObterPorId(int id)
        {
            return _context.Autores.Find(id);
        }
        public List<Autor> ObterPorNome(string nome)
        {
            return _context.Autores.Where(autor => autor.Nome.Contains(nome)).AsNoTracking()?.ToList();
        }
        public List<Autor> ObterTodos()
        {
            return _context.Autores.ToList();
        }
        public IEnumerable<EditorAutorViewModel> ObterTodosGrid()
        {
            return _context.Autores
                .Select(autor => new EditorAutorViewModel
                {
                    Id = autor.Id,
                    Nome = autor.Nome
                })
                .AsNoTracking().ToList();            
        }
    }
}