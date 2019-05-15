using System.Collections.Generic;
using System.Net;
using ProjetoAvonaleWeb.Models;
using Newtonsoft.Json;
using System.IO;

namespace ProjetoAvonaleWeb.Services
{
    public class GitApiService
    {
        //Define usuário a ser buscado no github
        const string USER = "Skellbr";

        /// <summary>
        /// Obtem a lista de repositorios do usuario acima
        /// </summary>
        /// <returns></returns>
        public List<Repo> getRepos()
        {
            HttpWebRequest httpWebRequest = WebRequest.Create("https://api.github.com/users/" + USER + "/repos") as HttpWebRequest;

            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.UserAgent = "Anything";

            dynamic jsonObj = null;
            try
            {
                using (StreamReader responseReader = new StreamReader(
                    httpWebRequest.GetResponse().GetResponseStream()))
                {
                    string reader = responseReader.ReadToEnd();
                    jsonObj = JsonConvert.DeserializeObject<List<Repo>>(reader);
                }
            }
            catch
            {
                return jsonObj;
            }
            return jsonObj;
        }

        /// <summary>
        /// Obtem a lista dos contribuidores do repositório informado
        /// </summary>
        /// <param name="repo"></param>
        public void getContributors(Repo repo)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create("https://api.github.com/repos/" + USER + "/" + repo.name + "/contributors") as HttpWebRequest;

            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.UserAgent = "Anything";

            try
            {
                using (StreamReader responseReader = new StreamReader(
                    httpWebRequest.GetResponse().GetResponseStream()))
                {
                    repo.contributors = JsonConvert.DeserializeObject<List<User>>(responseReader.ReadToEnd());
                }
            }
            catch { }



        }
    }
}