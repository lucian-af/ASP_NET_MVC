using System;
using System.Collections.Generic;
using BookStore.Dominio;
using BookStore.ViewModels.Autor;

namespace BookStore.Repositorios.Interfaces
{
    //IDisposable força ter um método de encerramento de conexao com o banco de dados
    public interface IAutorRepositorio : IDisposable
    {
        List<Autor> ObterTodos();
        IEnumerable<EditorAutorViewModel> ObterTodosGrid();
        Autor ObterPorId(int id);
        List<Autor> ObterPorNome(string nome);
        bool Inserir(Autor autor);
        bool Atualizar(Autor autor);
        bool Excluir(int id);
    }
}