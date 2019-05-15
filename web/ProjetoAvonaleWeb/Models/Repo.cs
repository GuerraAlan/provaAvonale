using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAvonaleWeb.Models
{
    [Serializable]
    public class Repo
    {

        public string name { get; set; }

        public User owner { get; set; }

        public string description { get; set; }

        public string language { get; set; }

        public DateTime updated_at { get; set; }

        public bool favorito { get; set; }

        public List<User> contributors { get; set; }
    }
    public class User
    {
        public string login { get; set; }
    }

}