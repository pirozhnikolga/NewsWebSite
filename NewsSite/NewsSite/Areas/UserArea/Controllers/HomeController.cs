using DomainObjects;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSite.Areas.NewsArea.Controllers
{
    public class HomeController : Controller
    {
        DataService service = new DataService();

        // GET: AdminArea/News
        public ActionResult Index(string name)
        {
            var _news = service.GetAllNews();
            return View(_news);
        }

        [HttpPost]
        public ActionResult Index(List<News> _news)
        {
            return View(_news);
        }

        public ActionResult Details(int? id)
        {
            var news = service.GetNewsById(id.Value);
            return View(news);
        }

        [HttpPost]
        public ActionResult NewsSearch(string name)
        {
            List<News> _news;
            if (name == String.Empty)
            {
                _news = service.GetAllNews();
            }
            else
            {
                _news = service.GetNewsByName(name);
            }
            return PartialView("NewsSearchView", _news);
        }
    }
}