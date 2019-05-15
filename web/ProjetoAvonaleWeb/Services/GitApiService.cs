using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using ProjetoAvonaleWeb.Models;
using Newtonsoft.Json;
using System.IO;

namespace ProjetoAvonaleWeb.Services
{
    public class GitApiService
    {
        const string USER = "Skellbr";
        public string BaseUrl
        {
            get {return "https://api.github.com/users/" + USER + "/repos";}
        }

        public List<Repo> getRepos()
        {
            HttpWebRequest httpWebRequest = WebRequest.Create(BaseUrl) as HttpWebRequest;

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

        public void getContributors(Repo repo)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create("https://api.github.com/repos/"+ USER + "/" + repo.name + "/contributors") as HttpWebRequest;

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
            catch {}
            


        }
    }
}