﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Dominio;
using BookStore.Repositorios.Interfaces;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    [RoutePrefix("livros")]
    public class LivroController : Controller
    {
        // Injeção de dependência
        private ILivroRepositorio _repositorio;

        public LivroController(ILivroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [Route("listar")]
        public ActionResult Index()
        {
            return View(_repositorio.ObterTodosGrid());
        }

        [Route("criar")]
        public ActionResult Create()
        {
            var categorias = _repositorio.ObterTodasCategoria();
            var model = new EditorLivroViewModel
            {
                Nome = "",
                ISBN = "",
                CategoriaId = 0,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome")
            };
            return View(model);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(EditorLivroViewModel model)
        {
            Livro livro = new Livro
            {
                Nome = model.Nome,
                ISBN = model.ISBN,
                DataLancamento = model.DataLancamento,
                CategoriaId = model.CategoriaId
            };

            if (_repositorio.Inserir(livro))
                return RedirectToAction("Index");

            return View(livro);
        }

        [Route("editar")]
        public ActionResult Edit(int id)
        {
            var categorias = _repositorio.ObterTodasCategoria();
            var livro = _repositorio.ObterPorId(id);
            var model = new EditorLivroViewModel
            {
                Nome = livro.Nome,
                ISBN = livro.ISBN,
                DataLancamento = livro.DataLancamento,
                CategoriaId = livro.CategoriaId,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome")
            };
            return View(model);
        }

        [Route("editar")]
        [HttpPost]
        public ActionResult Edit(EditorLivroViewModel model)
        {
            Livro livro = _repositorio.ObterPorId(model.Id);
            livro.Nome = model.Nome;
            livro.ISBN = model.ISBN;
            livro.DataLancamento = model.DataLancamento;
            livro.CategoriaId = model.CategoriaId;

            if (_repositorio.Atualizar(livro))
                return RedirectToAction("Index");

            return View(livro);
        }
    }
}