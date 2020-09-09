using System;
using System.Web.Mvc;
using BookStore.Dominio;

namespace BookStore.Controllers
{
    /// <summary>
    /// Conhecendo a forma de rotas do asp.net mvc
    /// </summary>
    [RoutePrefix("book")]    
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

        [Route("~/rotaignorada/{id:int}")]
        public string MinhaActionIgnorada(int? id)
        {
            return "OK! Cheguei na rota ignorada";
        }

        [Route("minharota/{categoria:minlength(3)}")]
        public string MinhaAction3(string categoria)
        {
            return $"OK! Cheguei na rota {categoria}";
        }

        // Esse seria o exemplo de rota personalizada constraint. Ver RouteConstraint/ValuesContraint
        //[Route("estacao/{estacao:(primavera|verao|outono|inverno)}")]
        [Route("estacao/{estacao:alpha:minlength(3)}")]
        public string MinhaAction4(string estacao)
        {
            return $"Olá estamos no(a) {estacao}";
        }
    }
}