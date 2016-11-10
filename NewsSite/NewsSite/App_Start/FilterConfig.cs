﻿using System.Web;
using System.Web.Mvc;

namespace NewsSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PrintFilter());
            filters.Add(new AjaxPartialFilter());
        }

        public class AjaxPartialFilter : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {

                if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    var oldView = filterContext.Result as ViewResult;
                    if (oldView != null)
                    {
                        filterContext.Result = new PartialViewResult
                        {
                            ViewData = oldView.ViewData,
                            ViewName = oldView.ViewName
                        };
                    }
                }
            }

        }

        public class PrintFilter : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (filterContext.RouteData.Values.ContainsValue("print"))
                {
                    var oldView = filterContext.Result as ViewResult;
                    if (oldView != null)
                    {
                        var viewName = oldView.ViewName.Length == 0 ?
                            filterContext.ActionDescriptor.ActionName : oldView.ViewName;

                        filterContext.Result = new ViewResult()
                        {
                            ViewData = oldView.ViewData,
                            MasterName = oldView.MasterName,
                            ViewName = string.Format("Print/{0}", viewName)
                        };
                    }
                }
            }

        }
    }
}
