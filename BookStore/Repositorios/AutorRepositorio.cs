using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookStore.Context;
using BookStore.Dominio;
using BookStore.Repositorios.Interfaces;

namespace BookStore.Repositorios
{
    public class AutorRepositorio : IAutorRepositorio
    {
        //  aqui abre a conexao
        private BookStoreDataContext _context = new BookStoreDataContext();

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
        public void Excluir(int id)
        {
            Autor autor = _context.Autores.Find(id);
            _context.Autores.Remove(autor);
            _context.SaveChanges();
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
    }
}