using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BookStore.Filters;

namespace BookStore
{
    public class MvcApplication : HttpApplication
    {
        // Esse arquivo é responsável por toda a execução do projeto ASP.NET MVC
        protected void Application_Start() // Quando a aplicação inicia
        {
            // Esse filtro foi aplicado para todas as Actions na aplicação inteira. CUIDADO: Analisar a real aplicação aqui.
            // Performance pode ser afetada, pois o ActionFilter é síncrono ou seja, enquanto o métodos de ActionFilter não forem executados
            // sua Action não vai andar. Dica: usado para consultorias.
            GlobalFilters.Filters.Add(new LogActionFilter());

            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
