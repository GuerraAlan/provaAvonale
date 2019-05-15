using ProjetoAvonaleWeb.Models;
using ProjetoAvonaleWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAvonaleWeb.Controllers
{
    public class ReposController : Controller
    {
        public ActionResult Index(string filtro)
        {
            if (filtro == null)
            {
                return View(RepoCache.getRepositorios());
            }  else
            {
                return View(RepoCache.getRepositorios().Where(a => a.name.ToUpper().Contains(filtro.ToUpper())).ToList());
            }
        }

        public ActionResult Detalhar(string filtro)
        {
            Repo repo = RepoCache.getRepositorios().Find(a => a.name == filtro);
            new GitApiService().getContributors(repo);
            return View(repo);
        }

        public ActionResult SalvarFavorito(string nome, bool? novoFavorito)
        {
            if (novoFavorito == null)
            {
                novoFavorito = false;
            }

            RepoCache.getRepositorios().Find(a => a.name == nome).favorito = novoFavorito.Value;
            RepoCache.saveFav();
            return View("Index", RepoCache.getRepositorios());
        }

        public ActionResult ListaFavoritos()
        {
            return View(RepoCache.getRepositorios().Where(a => a.favorito == true).ToList());

        }
    }

}