using Newtonsoft.Json;
using ProjetoAvonaleWeb.Models;
using ProjetoAvonaleWeb.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjetoAvonaleWeb
{
    public class RepoCache
    {
        public static List<Repo> repositorios;

        public static List<Repo> getRepositorios()
        {
            if(repositorios == null)
            {
                repositorios = new GitApiService().getRepos();
                loadFav();
            }
            return repositorios;
        }
        
        public static void saveFav()
        {
            List<Repo> favoritos = repositorios.Where(e => e.favorito).ToList();

            try
            {
                File.WriteAllText(@"favoritos.json", JsonConvert.SerializeObject(favoritos));
            } catch { }
           
        }

        private static void loadFav()
        {
            try
            {
                List<Repo> favoritos = JsonConvert.DeserializeObject(File.ReadAllText(@"favoritos.json")) as List<Repo>;
                favoritos.ForEach(elemento =>
                {
                    Repo encontrado = repositorios.Find(e => e.name == elemento.name);
                    if (encontrado != null)
                    {
                        encontrado.favorito = true;
                    }
                });
            } catch { }
           
        }
    }
}