using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Dominio;
using BookStore.Filters;
using BookStore.Repositorios;
using BookStore.Repositorios.Interfaces;

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
            return View(_repositorio.ObterTodos());
        }

        [Route("criar")]
        public ActionResult Create()
        {
            // Essa renderiza a tela para preencher os campos
            return View();
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult CreateConfirm(Autor autor)
        {
            // essa é para persistir os dados no banco
            if (_repositorio.Inserir(autor))
                return RedirectToAction("Index");

            return View(autor);
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View(_repositorio.ObterPorId(id));
        }

        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult EditConfirm(Autor autor)
        {
            if (_repositorio.Atualizar(autor))
                return RedirectToAction("Index");

            return View(autor);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View(_repositorio.ObterPorId(id));
        }

        [Route("excluir/{id:int}")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }

        [Route("visualizar/{id:int}")]
        [HttpGet]
        public ActionResult View(int id)
        {
            return View(_repositorio.ObterPorId(id));
        }
    }
}