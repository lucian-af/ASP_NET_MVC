﻿using System;
using System.Web.Mvc;
using BookStore.Dominio;
using BookStore.Repositorios.Interfaces;
using BookStore.ViewModels.Autor;
using static BookStore.Utils.Enum;

namespace BookStore.Controllers
{
    [RoutePrefix("autores")]
    // o filtro passará em todas as actions
    // [LogActionFilter()] // O LogActionFilter foi registrado globalmente Global.asax
    public class AutorController : Controller
    {
        private IAutorRepositorio _repositorio;

        public AutorController(IAutorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [Route("listar")]
        // Pode ser feito o filtro somente em uma action
        //[LogActionFilter()]
        [HttpGet]
        public ActionResult Index()
        {
            return View(_repositorio.ObterTodosGrid());
        }

        [Route("criar")]
        public ActionResult Create()
        {
            var model = new EditorAutorViewModel { Nome = "" };
            ViewData.Add(nameof(eStatusForm), (int)eStatusForm.Novo);
            return View(model);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(EditorAutorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Autor autor = new Autor { Nome = model.Nome };

            try
            {

                if (_repositorio.Inserir(autor))
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Mensagem", ex.Message);
                return View(model);
            }

            return View(autor);
        }

        [Route("editar")]
        public ActionResult Edit(int id)
        {
            EditorAutorViewModel model = PreencherAutorModel(id);
            ViewData.Add(nameof(eStatusForm), (int)eStatusForm.Alterar);
            return View(model);
        }

        [Route("editar")]
        [HttpPost]
        public ActionResult Edit(EditorAutorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Autor autor = _repositorio.ObterPorId(model.Id);
            autor.Nome = model.Nome;

            try
            {
                if (_repositorio.Atualizar(autor))
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Mensagem", ex.Message);
                return View(model);
            }

            return View(autor);
        }

        [Route("excluir")]
        public ActionResult Delete(int id)
        {
            ViewData.Add(nameof(eStatusForm), (int)eStatusForm.Excluir);
            EditorAutorViewModel model = PreencherAutorModel(id);
            return View(model);
        }

        [Route("excluir")]
        [HttpPost]
        public ActionResult DeleteConfirm(EditorAutorViewModel model)
        {
            Autor autor = _repositorio.ObterPorId(model.Id);

            if (_repositorio.Excluir(autor.Id))
                return RedirectToAction("Index");

            return View(model);
        }

        [Route("visualizar/{id:int}")]
        [HttpGet]
        public ActionResult View(int id)
        {
            ViewData.Add(nameof(eStatusForm), (int)eStatusForm.Visualizar);
            EditorAutorViewModel model = PreencherAutorModel(id);
            return View(model);
        }
        private EditorAutorViewModel PreencherAutorModel(int id)
        {
            var autor = _repositorio.ObterPorId(id);
            var model = new EditorAutorViewModel { Id = autor.Id, Nome = autor.Nome };
            return model;
        }
    }
}