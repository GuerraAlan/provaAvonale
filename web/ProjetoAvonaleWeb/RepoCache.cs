using ProjetoAvonaleWeb.Models;
using ProjetoAvonaleWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAvonaleWeb
{
    public class RepoCache
    {
        private static List<Repo> repositorios;

        public static List<Repo> getRepositorios()
        {
            if(repositorios == null)
            {
                repositorios = new GitApiService().getRepos();
            }
            return repositorios;
        }
    }
}