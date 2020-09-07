using System;
using System.Web.Mvc;
using BookStore.Dominio;

namespace BookStore.Controllers
{
    /// <summary>
    /// Conhecendo a forma de rotas do asp.net mvc
    /// </summary>
    public class TesteController : Controller
    {
        public string Index()
        {
            return "Index";
        }

        /// <summary>
        /// A Interrogação torna o parâmetro "id" opcional
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet] // por padrao o método é Get mas é sempre interessante colocar por padrão
        public JsonResult ActionUm(int? id, string nome)
        {
            Autor autor = new Autor
            {
                Id = id ?? 0,
                Nome = nome
            };

            return Json(autor, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ActionDois(Autor autor) =>
            Json(autor, JsonRequestBehavior.AllowGet);

        public ViewResult Dados(Autor autor)
        {
            Autor aut = new Autor { Id = 1, Nome = "Lucian" };

            // ViewBag e ViewData são a mesma coisa, formas diferentes de escrita, ao rodar este código o ViewData irá sobrescrever o ViewBag
            // Evitar passar as informações dessa forma
            ViewBag.Categoria = "Produtos de Limpeza";
            ViewData["Categoria"] = "Produtos de Informática";
            TempData["Categoria"] = "Produtos de Escritório";
            Session["Categoria"] = "Móveis";

            return View(aut);
        }
    }
}