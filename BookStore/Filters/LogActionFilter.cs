using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        private void Log(string nomeMetodo, RouteData routeData)
        {
            var nomeController = routeData.Values["controller"];
            var nomeAction = routeData.Values["action"];
            var message = $"{nomeMetodo} controller: {nomeController} action: {nomeAction}";
            Debug.WriteLine(message, "Action Filter Log");
        }
        /// <summary>
        /// Quando a Action é executada
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }
        /// <summary>
        /// Quando o Result da Action dor executado
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }
        /// <summary>
        /// Quando a Action está sendo executada
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }
        /// <summary>
        /// Quando o Result da Action está sendo executado
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }
    }
}