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
        public ActionResult Index()
        {
            return View(RepoCache.getRepositorios());

        }
        public ActionResult Buscar(string filtro, bool? caseSensitive)
        {
            if (filtro == null)
            {
                return View(RepoCache.getRepositorios());
            }
            if (caseSensitive == true)
            {
                return View(RepoCache.getRepositorios().Where(a => a.name == filtro).ToList());
            }
            else
            {
                return View(RepoCache.getRepositorios().Where(a => a.name.ToUpper().Contains(filtro.ToUpper())).ToList());
            }

        }

        /// <summary>
        /// Seção de detalhes do repositório
        /// </summary>
        /// <param name="filtro"> Nome do repositório a ser detalhado </param>
        /// <returns></returns>
        public ActionResult Detalhar(string filtro)
        {
            return View(RepoCache.getRepositorios().Find(a => a.name == filtro));
        }

        /// <summary>
        /// Salva se um repositório é ou não favorito
        /// </summary>
        /// <param name="nome"> nome do repositório a ser salvo</param>
        /// <param name="novoFavorito"> Se true é favorito se null não é favorito</param>
        /// <returns> Retorna para view meus repositórios </returns>
        public ActionResult SalvarFavorito(string nome, bool? novoFavorito)
        {
            if (novoFavorito == null)
            {
                novoFavorito = false;
            }

            RepoCache.getRepositorios().Find(a => a.name == nome).favorito = novoFavorito.Value;

            return View("Index", RepoCache.getRepositorios());
        }

        public ActionResult ListarFavoritos()
        {
            return View(RepoCache.getRepositorios().Where(a => a.favorito == true).ToList());

        }
    }

}