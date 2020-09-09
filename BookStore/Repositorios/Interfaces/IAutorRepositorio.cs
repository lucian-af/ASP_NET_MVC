using System;
using System.Collections.Generic;
using BookStore.Dominio;

namespace BookStore.Repositorios.Interfaces
{
    //IDisposable força ter um método de encerramento de conexao com o banco de dados
    public interface IAutorRepositorio : IDisposable
    {
        List<Autor> ObterTodos();
        Autor ObterPorId(int id);
        List<Autor> ObterPorNome(string nome);
        bool Inserir(Autor autor);
        bool Atualizar(Autor autor);
        void Excluir(int id);
    }
}