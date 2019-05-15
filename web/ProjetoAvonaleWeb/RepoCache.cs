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
    /// <summary>
    ///Classe auxiliar para manter o cache dos repositórios, assim como salvar e carregar os favoritos localmente
    /// </summary>
    public class RepoCache
    {
        private const string FAVORITOS = @"favoritos.json";
        public static List<Repo> repositorios;

        /// <summary>
        /// Método para carregamento dos repositórios na api do github
        /// </summary>
        /// <returns></returns>
        public static List<Repo> getRepositorios()
        {
            if(repositorios == null)
            {
                repositorios = new GitApiService().getRepos();
                loadFav();
            }
            return repositorios;
        }
        
        /// <summary>
        /// Salva os favoritos
        /// </summary>
        public static void saveFav()
        {
            List<Repo> favoritos = repositorios.Where(e => e.favorito).ToList();

            try
            {
                File.WriteAllText(FAVORITOS, JsonConvert.SerializeObject(favoritos));
            } catch { }
           
        }

        //Carrega os favoritos
        private static void loadFav()
        {
            try
            {
                List<Repo> favoritos = JsonConvert.DeserializeObject(File.ReadAllText(FAVORITOS)) as List<Repo>;
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