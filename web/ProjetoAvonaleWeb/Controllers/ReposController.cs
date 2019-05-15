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
        /// <summary>
        /// Caso o filtro esteja vazio exibe todos os repositorios, caso contrario aplica o texto como filtro
        /// </summary>
        /// <param name="filtro">texto a ser comparado</param>
        /// <returns></returns>
        public ActionResult Index(string filtro)
        {
            if (filtro == null)
            {
                return View(RepoCache.getRepositorios());
            }
            else
            {
                return View(RepoCache.getRepositorios().Where(a => a.name.ToUpper().Contains(filtro.ToUpper())).ToList());
            }
        }

        /// <summary>
        /// Carrega os contribuidores e define o repositorio a ser detalhado
        /// </summary>
        /// <param name="filtro">Nome do repositorio</param>
        /// <returns></returns>
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

            RepoCache.getRepositorios().Find(a => a.name.Equals(nome)).favorito = novoFavorito.Value;
            RepoCache.saveFav();
            return View("Index", RepoCache.getRepositorios());
        }

        /// <summary>
        /// Retorna os repositorios marcados como favoritos
        /// </summary>
        /// <returns></returns>
        public ActionResult ListaFavoritos()
        {
            return View(RepoCache.getRepositorios().Where(a => a.favorito == true).ToList());

        }
    }

}