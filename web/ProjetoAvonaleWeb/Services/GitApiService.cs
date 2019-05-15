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
        public string BaseUrl
        {
            get {return "https://api.github.com/users/Skellbr/repos";}
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
    }
}