using System;
using System.Web.Mvc;
using BookStore.Dominio;
using BookStore.Repositorios.Interfaces;
using BookStore.ViewModels.Livro;
using static BookStore.Utils.Enum;

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
            ViewData.Add(nameof(eStatusForm), (int)eStatusForm.Novo);
            return View(model);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(EditorLivroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categorias = _repositorio.ObterTodasCategoria();
                model.CategoriaOptions = new SelectList(categorias, "Id", "Nome");
                return View(model);
            }

            Livro livro = new Livro
            {
                Nome = model.Nome,
                ISBN = model.ISBN,
                DataLancamento = model.DataLancamento,
                CategoriaId = model.CategoriaId
            };

            try
            {
                if (_repositorio.Inserir(livro))
                    return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Mensagem", ex.Message);
                var categorias = _repositorio.ObterTodasCategoria();
                model.CategoriaOptions = new SelectList(categorias, "Id", "Nome");
                return View(model);
            }

            return View(livro);
        }

        [Route("editar")]
        public ActionResult Edit(int id)
        {
            EditorLivroViewModel model = PreencherModelLivro(id);
            ViewData.Add(nameof(eStatusForm), (int)eStatusForm.Alterar);
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

        [Route("excluir")]
        public ActionResult Delete(int id)
        {
            EditorLivroViewModel model = PreencherModelLivro(id);
            ViewData.Add(nameof(eStatusForm), (int)eStatusForm.Excluir);
            return View(model);
        }

        [Route("excluir")]
        [HttpPost]
        public ActionResult DeleteConfirm(EditorLivroViewModel model)
        {
            Livro livro = _repositorio.ObterPorId(model.Id);

            if (_repositorio.Excluir(livro.Id))
                return RedirectToAction("Index");

            return View(livro);
        }

        [Route("visualizar/{id:int}")]
        [HttpGet]
        public ActionResult View(int id)
        {
            EditorLivroViewModel model = PreencherModelLivro(id);
            ViewData.Add(nameof(eStatusForm), (int)eStatusForm.Visualizar);
            return View(model);
        }

        private EditorLivroViewModel PreencherModelLivro(int id)
        {
            var categorias = _repositorio.ObterTodasCategoria();
            var livro = _repositorio.ObterPorId(id);
            var model = new EditorLivroViewModel
            {
                Id = livro.Id,
                Nome = livro.Nome,
                ISBN = livro.ISBN,
                DataLancamento = livro.DataLancamento,
                CategoriaId = livro.CategoriaId,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome")
            };
            return model;
        }
    }
}