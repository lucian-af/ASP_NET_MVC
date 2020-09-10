using System;
using System.Collections.Generic;
using BookStore.Dominio;
using BookStore.ViewModels;

namespace BookStore.Repositorios.Interfaces
{
    public interface ILivroRepositorio : IDisposable
    {
        List<Livro> ObterTodos();
        IEnumerable<EditorLivroViewModel> ObterTodosGrid();
        Livro ObterPorId(int id);
        List<Livro> ObterPorNome(string nome);
        bool Inserir(Livro autor);
        bool Atualizar(Livro autor);
        void Excluir(int id);
        List<Categoria> ObterTodasCategoria();
    }
}