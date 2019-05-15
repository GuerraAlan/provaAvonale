using ProjetoAvonaleWeb.Models;
using ProjetoAvonaleWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAvonaleWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(RepoCache.getRepositorios());
        }

    }
}